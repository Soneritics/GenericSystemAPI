using System.Collections.Generic;

namespace GenericSystemAPI.Models
{
    public class OrderState
    {
        public string state { get; set; }
        public List<string> result { get; set; }
        public List<Order> orders { get; set; }
    }
}
