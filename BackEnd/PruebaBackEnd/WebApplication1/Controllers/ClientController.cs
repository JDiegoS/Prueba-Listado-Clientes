using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;


namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private IConfiguration _config;
        public ClientController(IConfiguration configuration)
        {
            _config = configuration;
        }

        [HttpGet]
        [Route("GetClients")]
        public JsonResult GetClients()
        {
            string query = "select * from dbo.Client_Detail";
            DataTable dt = new DataTable();
            string sqlDatasource = _config.GetConnectionString("PruebaDBConn");
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(sqlDatasource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myReader = myCommand.ExecuteReader();
                    dt.Load(myReader);
                    myReader.Close();
                    myConn.Close();
                }
            }

            return new JsonResult(dt);
        }

        [HttpGet]
        [Route("AddClient")]
        public JsonResult AddClient(string name, string location, string phone, string comments)
        {
            string sqlDatasource = _config.GetConnectionString("PruebaDBConn");
            using (SqlConnection myConn = new SqlConnection(sqlDatasource))
            {
                myConn.Open();
                SqlCommand myCommand = new SqlCommand("SP_ADD_CLIENT", myConn);
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Parameters.Add("@NAME", SqlDbType.VarChar).Value = name;
                myCommand.Parameters.Add("@LOCATION", SqlDbType.VarChar).Value = location;
                myCommand.Parameters.Add("@PHONE", SqlDbType.VarChar).Value = phone;
                myCommand.Parameters.Add("@COMMENTS", SqlDbType.VarChar).Value = comments;
                myCommand.Parameters.Add("@DATEC", SqlDbType.Date).Value = DateTime.Now;
                //myCommand.Parameters.AddWithValue("@CLIENTID", SqlDbType.Int).Value = newClient.ClientID;
                myCommand.ExecuteNonQuery();
                myConn.Close();
            }

            return new JsonResult("Cliente Agregado Exitosamente");
        }

        [HttpGet]
        [Route("DeleteClient")]
        public JsonResult DeleteClient(string name)
        {
            string sqlDatasource = _config.GetConnectionString("PruebaDBConn");
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(sqlDatasource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand("SP_DELETE_CLIENT", myConn))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.Add("@NAME", SqlDbType.VarChar).Value = name;
                    myCommand.ExecuteNonQuery();
                    myConn.Close();
                }
            }

            return new JsonResult("Cliente Eliminado Exitosamente");
        }
    }
}
