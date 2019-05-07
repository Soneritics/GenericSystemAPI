using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericSystemAPI.Business;
using GenericSystemAPI.Models;

namespace GenericSystemAPI
{
    public class ScanBarcodeApi : Api<ApiResult<OrderState>>
    {
        protected override string Url { get; set; } = "/api/packingslip/process-barcode";

        public ScanBarcodeApi(Config config, string barcode, int employeeId) : base(config)
        {
            Data["barcode"] = barcode;
            Data["employee"] = employeeId.ToString();
            GenerateToken();
        }
    }
}
