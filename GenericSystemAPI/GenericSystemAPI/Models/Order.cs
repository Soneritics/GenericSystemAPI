namespace GenericSystemAPI.Models
{
    public class Order
    {
        public int id { get; set; }
        public string module { get; set; }
        public string module_id { get; set; }
        public string module_order_id { get; set; }
        public int placed { get; set; }
        public decimal total { get; set; }
        public string shipment_method_id { get; set; }
    }
}