using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IConfiguration _config;
        public UserController(IConfiguration configuration)
        {
            _config = configuration;
        }

        [HttpGet]
        [Route("GetUsers")]
        public JsonResult GetUsers()
        {
            string query = "select * from dbo.Users";
            DataTable dt = new DataTable();
            string sqlDatasource = _config.GetConnectionString("PruebaDBConn");
            SqlDataReader myReader;
            using(SqlConnection myConn = new SqlConnection(sqlDatasource))
            {
                myConn.Open();
                using(SqlCommand myCommand = new SqlCommand(query, myConn))
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
        [Route("GetUser")]
        public JsonResult GetUser(string username, string password)
        {
            string query = "select * from dbo.Users where Username = '" + username + "' and Password = '" + password + "'";
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
    }
}
