using System.Data.SqlClient;
using EmailThing._10_Core.Domain.Model;
using EmailThing._10_Core.Domain.Services;

namespace EmailThing._10_Core.Domain.Repository
{
    public class EmailRepositoryDb : Repository<Email> ,IEmailRepository 
    {
        public EmailRepositoryDb(SqlConnection connection) :base(connection)
        {
        }
    }
}