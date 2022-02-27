using System.Collections.Generic;

namespace GenericSystemAPI.Models
{
    public class ErrorModel
    {
        public string error { get; set; }
        public List<Order> orders { get; set; }
    }
}