using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaAspNetCore.Nucleo.DTOs;
using PruebaAspNetCore.Nucleo.Repositorios;
using System;
using System.Threading.Tasks;

namespace PruebaAspNetCore.Controllers
{
    [Route("api/empleados")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IRepositorioEmpleado _repositorioEmpleado;

        public EmpleadoController(IRepositorioEmpleado repositorioEmpleado)
        {
            _repositorioEmpleado = repositorioEmpleado;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerEmpleados()
        {
            try
            {
                return Ok(await _repositorioEmpleado.ObtenerEmpleados());
            }
            catch (Exception) { return BadRequest(); }
        }


        [HttpGet("{idEmpleado}")]
        public async Task<IActionResult> ObtenerEmpleadoPorId(int idEmpleado)
        {
            try
            {
                return Ok(await _repositorioEmpleado.ObtenerEmpleadoPorId(idEmpleado));
            }
            catch (Exception ex)
            {
                return BadRequest(new DTOBase
                {
                    StatusCode = 500,
                    Success = false,
                    Message = ex.Message ?? "Lo siento a ocurrido un error..!"
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AgregarEmpleado([FromBody] DTOEmpleado empleado)
        {
            try
            {
                return Ok(await _repositorioEmpleado.AgregarEmpleado(empleado));
            }
            catch (Exception ex)
            {
                return BadRequest(new DTOBase
                {
                    StatusCode = 500,
                    Success = false,
                    Message = ex.Message ?? "Lo siento a ocurrido un error..!"
                });
            }
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarEmpleado([FromBody] DTOEmpleado empleado)
        {
            try
            {
                await _repositorioEmpleado.ActualizarEmpleado(empleado);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new DTOBase
                {
                    StatusCode = 500,
                    Success = false,
                    Message = ex.Message ?? "Lo siento a ocurrido un error..!"
                });
            }
        }

        [HttpDelete("{idEmpleado}")]
        public async Task<IActionResult> EliminarEmpleado(int idEmpleado)
        {
            try
            {
                await _repositorioEmpleado.EliminarEmpleado(idEmpleado);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new DTOBase
                {
                    StatusCode = 500,
                    Success = false,
                    Message = ex.Message ?? "Lo siento a ocurrido un error..!"
                });
            }
        }

    }
}
