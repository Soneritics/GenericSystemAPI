using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericSystemAPI.Business;
using GenericSystemAPI.Models;

namespace GenericSystemAPI
{
    public class LoginApi : Api<ApiResult<bool>>
    {
        protected override string Url { get; set; } = "/api/packingslip/is-valid-login";

        public LoginApi(Config config, int employee, string pin) : base(config)
        {
            Data["employee"] = employee.ToString();
            Data["pin"] = pin;
            GenerateToken();
        }
    }
}
