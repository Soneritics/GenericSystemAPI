using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GenericSystemAPI.Business
{
    public abstract class Api<T>
    {
        protected Config Config { get; }
        protected Dictionary<string, string> Data { get; set; } = new Dictionary<string, string>();
        protected abstract string Url { get; set; }
        private string Token;

        protected Api(Config config)
        {
            this.Config = config ?? throw new ArgumentNullException(nameof(config));

            if (!Config.IsValid())
                throw new ArgumentNullException(nameof(config), "Not all config fields have been filled");

            Data["username"] = Config.Username;
        }

        protected void GenerateToken()
        {
            Token = TokenGenerator.GetApiToken(Config.Hash, Data);
        }

        public T Call()
        {
            Data["token"] = Token;
            var dataString = JsonConvert.SerializeObject(Data, Formatting.None);
            Data.Remove("token");

            if (!Config.SslMustBeValid)
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

            if (Token == null)
                throw new ArgumentNullException(Token, "Token has not been generated. Use the GenerateToken() method before calling the API.");

            using (var wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";

                try
                {
                    var result = wc.UploadString(Config.Uri + Url, dataString);

                    if (typeof(T) == typeof(string))
                        return (T)Convert.ChangeType(result, typeof(T));
                    else
                        return JsonConvert.DeserializeObject<T>(result);
                }
                catch (WebException exception)
                {
                    string responseText;

                    using (var reader = new StreamReader(exception.Response.GetResponseStream() ?? throw new InvalidOperationException()))
                    {
                        responseText = reader.ReadToEnd();
                    }

                    var errorObject = JsonConvert.DeserializeObject<JObject>(responseText);
                    throw new Exception((string)errorObject["error"]);
                }
            }
        }
    }
}
