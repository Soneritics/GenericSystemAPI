using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericSystemAPI.Models
{
    public class ApiResult<T>
    {
        public T result { get; set; }
    }
}
