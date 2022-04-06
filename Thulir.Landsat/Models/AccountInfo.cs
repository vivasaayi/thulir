using System.Text.Json.Serialization;

namespace Thulir.Landsat.Models
{
    public class AccountInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AccountId { get; set; }
        public string UserName { get; set; }
    }
}