using PruebaAspNetCore.Nucleo.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaAspNetCore.Nucleo.Repositorios
{
    public interface IRepositorioEmpleado
    {
        Task<List<DTOEmpleado>> ObtenerEmpleados();
        Task<DTOEmpleado> ObtenerEmpleadoPorId(int idEmpleado);
        Task<DTOEmpleado> AgregarEmpleado(DTOEmpleado empleado);
        Task ActualizarEmpleado(DTOEmpleado empleado);
        Task EliminarEmpleado(int idEmpleado);
    }
}
