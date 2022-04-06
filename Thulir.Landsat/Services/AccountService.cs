using System.Threading.Tasks;
using Thulir.Landsat.Models;

namespace Thulir.Landsat.Services
{
    public class AccountService
    {
        public async Task<AccountInfo> GetAccountInfo(string userName)
        {
            // return await _catalogRepository.GetCatalog("dataproducts");
            return new AccountInfo()
            {
                AccountId = "sas",
                FirstName = "Rajan",
                LastName = "Panneer",
                UserName = "ABCD"
            };
        }   
    }
}