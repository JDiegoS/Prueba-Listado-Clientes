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
            string query = "select * from dbo.Clients";
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

        [HttpPost]
        [Route("AddClient")]
        public JsonResult AddClient([FromBody] Client_Detail newClient)
        {
            string sqlDatasource = _config.GetConnectionString("PruebaDBConn");
            using (SqlConnection myConn = new SqlConnection(sqlDatasource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand("SP_ADD_CLIENT", myConn))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@STATUS", SqlDbType.NVarChar).Value = newClient.Status;
                    myCommand.Parameters.AddWithValue("@NAME", SqlDbType.NVarChar).Value = newClient.Name;
                    myCommand.Parameters.AddWithValue("@LOCATION", SqlDbType.NVarChar).Value = newClient.Location;
                    myCommand.Parameters.AddWithValue("@PHONE", SqlDbType.NVarChar).Value = newClient.Phone_Number;
                    myCommand.Parameters.AddWithValue("@COMMENTS", SqlDbType.NVarChar).Value = newClient.Comments;
                    myCommand.Parameters.AddWithValue("@DATEC", SqlDbType.Date).Value = DateTime.Now;
                    myCommand.Parameters.AddWithValue("@CLIENTID", SqlDbType.Int).Value = newClient.ClientID;
                    myCommand.ExecuteNonQuery();
                    myConn.Close();
                }
            }

            return new JsonResult("Cliente Agregado Exitosamente");
        }

        [HttpDelete]
        [Route("DeleteClient")]
        public JsonResult DeleteClient(int clientId)
        {
            string sqlDatasource = _config.GetConnectionString("PruebaDBConn");
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(sqlDatasource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand("SP_DELETE_CLIENT", myConn))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@CLIENTID", SqlDbType.Int).Value = clientId;
                    myCommand.ExecuteNonQuery();
                    myConn.Close();
                }
            }

            return new JsonResult("Cliente Agregado Exitosamente");
        }
    }
}
