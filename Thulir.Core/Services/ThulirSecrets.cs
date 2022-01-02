using System;
using System.Text.Json;
using System.Threading.Tasks;
using Thulir.Aws;
using Thulir.Core.Models;

namespace Thulir.Core.Services
{
    public class ThulirSecrets
    {
        public async Task<ThulirGlobals> GetThulirGlobals()
        {
            string thulirGlobalsStr = SecretsClient.GetSecret("thulir-globals");
            
            return JsonSerializer.Deserialize<ThulirGlobals>(thulirGlobalsStr);
        }
    }
}