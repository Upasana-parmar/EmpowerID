using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpowerID.Base.CustomModel
{
    public class Response
    {
        public Response() { }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public object Result { get; set; } 
        public string color { get; set; }   
    }
}
