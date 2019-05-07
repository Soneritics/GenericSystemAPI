using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericSystemAPI.Business;
using GenericSystemAPI.Models;

namespace GenericSystemAPI
{
    public class GetEmployeesApi : Api<ApiResult<List<Employee>>>
    {
        protected override string Url { get; set; } = "/api/packingslip/get-employees";

        public GetEmployeesApi(Config config) : base(config)
        {
            GenerateToken();
        }
    }
}
