using System.Threading.Tasks;
using Thulir.Core.Models;
using Thulir.Core.Services;

namespace Thulir.Core.Utils
{
    public class ConfigLoader
    {
        private static ConfigLoader Instance;
        private bool initialized;

        private readonly static object _lock = new object();
        
        private ThulirSecrets _secrets = new ThulirSecrets();

        public static ConfigLoader GetInstance()
        {
            lock (_lock)
            {
                if (Instance == null)
                {
                    Instance = new ConfigLoader();
                }
            }

            return Instance;
        }

        public async Task Init()
        {
            if (initialized)
            {
                // We cannot await inside a lock statement.
                // This will be called only during program startup. 
                // Hope we are good.
                return;
            }

            initialized = true;

            await InitConfig();
        }

        private async Task InitConfig()
        {
            await GetGlobals();
        }

        public async Task<ThulirGlobals> GetGlobals()
        {
            return await _secrets.GetThulirGlobals();
        } 
    }
}