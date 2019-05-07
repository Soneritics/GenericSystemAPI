using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GenericSystemAPI.Business
{
    internal static class TokenGenerator
    {
        public static string GetApiToken(string hash, Dictionary<string, string> request)
        {
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(request, Newtonsoft.Json.Formatting.None);
            var shaM = new SHA512Managed();
            var calculatedHash = shaM.ComputeHash(Encoding.UTF8.GetBytes(jsonString + hash));

            return calculatedHash.Aggregate(string.Empty, (current, t) => current + t.ToString("X2"));
        }
    }
}
