using System;
using System.Data;
using System.Threading.Tasks;
using Thulir.Core.Dals;


using Dapper;
using Nest;

namespace Thulir.Core.Repositories
{
    class Credentials
    {
        
    }
    public class UsersRepository
    {
        public async Task GetAllUsers()
        {
            var dal = PostgresDal.GetInstance();
            
            var result = await dal.ExecuteQuery<Credentials>("SELECT * FROM Credentials", new {});

            Console.WriteLine(result);
        }
    }
}