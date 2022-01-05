using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaAspNetCore.Nucleo.DTOs
{
    public class DTOBase
    {
        public int StatusCode { get; set; } = 200;
        public bool Success { get; set; } = true;
        public string Message { get; set; } = "";
    }
}
