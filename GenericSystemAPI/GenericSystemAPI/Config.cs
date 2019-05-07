using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace GenericSystemAPI
{
    public class Config
    {
        public string Username { get; set; }
        public string Hash { get; set; }
        public string Uri { get; set; }
        public bool SslMustBeValid { get; set; } = true;

        public bool IsValid()
        {
            return
                !string.Empty.Equals(Username) &&
                !string.Empty.Equals(Hash) &&
                !string.Empty.Equals(Uri);
        }
    }
}
