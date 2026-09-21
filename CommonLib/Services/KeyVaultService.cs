using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using CommonLib.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib.Services
{
    public class KeyVaultService: IKeyVaultService
    {
        private readonly SecretClient _client;

        public KeyVaultService(string vaultUri)
        {
            _client = new SecretClient(new Uri(vaultUri), new DefaultAzureCredential());
        }

        public string GetSecret(string secretName)
        {
            return _client.GetSecret(secretName).Value.Value;
        }
    }
}
