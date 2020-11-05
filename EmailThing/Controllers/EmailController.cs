using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EmailThing._10_Core.Domain.Repository;
using EmailThing._10_Core.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailThing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        public EmailController()
        {
            var connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=KevinTestDB;Integrated Security=True;";
            var conn = new SqlConnection(connStr);
            var emailRepo = new EmailRepositoryDb(conn);
        }
        
    }
}
