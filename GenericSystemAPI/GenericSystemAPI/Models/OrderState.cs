using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace GenericSystemAPI.Models
{
    public class OrderState
    {
        public string state { get; set; }
        public List<string> result { get; set; }
    }
}
