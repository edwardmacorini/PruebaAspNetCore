using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaAspNetCore.Nucleo.DTOs
{
    public class DTOEmpleado
    {
        public int Id { get; set; } = 0;
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Foto { get; set; }
        public DateTime FechaContratacion { get; set; }
    }
}
