using System;

namespace GenericSystemAPI.Debug
{
    class Program
    {
        private static Config Config = new Config()
        {
            SslMustBeValid = true,
            Hash = "",
            Username = "",
            Uri = ""
        };

        static void Main(string[] args)
        {
            var api = Barcode();
            //var api = Employees();
            //var api = Login();

            try
            {
                var result = api.Call();
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }

            Console.ReadKey();
        }

        private static ScanBarcodeApi Barcode()
        {
            return new ScanBarcodeApi(Config, "PS196", 1);
        }

        private static GetEmployeesApi Employees()
        {
            return new GetEmployeesApi(Config);
        }

        private static LoginApi Login()
        {
            return new LoginApi(Config, 2, "1234");
        }
    }
}
