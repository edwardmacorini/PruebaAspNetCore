using PruebaAspNetCore.Datos.Modelos.GE;
using PruebaAspNetCore.Nucleo.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PruebaAspNetCore.Nucleo.Repositorios
{
    public class RepositorioEmpleado : IRepositorioEmpleado
    {
        private readonly GEContext _context;

        public RepositorioEmpleado(GEContext context)
        {
            _context = context;
        }
        public async Task<List<DTOEmpleado>> ObtenerEmpleados()
        {
            return await (from e in _context.Empleados
                          select new DTOEmpleado
                          {
                              Id = e.Id,
                              Apellido = e.Apellido.Trim().ToLower(),
                              Nombre = e.Nombre.Trim().ToLower(),
                              Telefono = e.Telefono.Trim(),
                              Correo = e.Correo.Trim(),
                              Foto = e.Foto.Trim(),
                              FechaContratacion = e.FechaContratacion,
                          }).AsNoTracking().ToListAsync();
        }

        public async Task<DTOEmpleado> ObtenerEmpleadoPorId(int idEmpleado)
        {
            if (idEmpleado == 0)
                throw new ArgumentNullException();

            var empleadoEncontrado = await (from e in _context.Empleados
                                            where e.Id == idEmpleado
                                            select new DTOEmpleado
                                            {
                                                Id = e.Id,
                                                Apellido = e.Apellido.Trim().ToLower(),
                                                Nombre = e.Nombre.Trim().ToLower(),
                                                Telefono = e.Telefono.Trim(),
                                                Correo = e.Correo.Trim(),
                                                Foto = e.Foto.Trim(),
                                                FechaContratacion = e.FechaContratacion,
                                            }).AsNoTracking().FirstOrDefaultAsync();
            if (empleadoEncontrado == null)
                throw new NullReferenceException("Empleado no encontrado");

            return empleadoEncontrado;
        }

        public async Task<DTOEmpleado> AgregarEmpleado(DTOEmpleado empleado)
        {
            if (empleado == null)
                throw new ArgumentNullException();

            var nuevoEmpleado = await _context.AddAsync(new Empleado
            {
                Apellido = empleado.Apellido.Trim().ToLower(),
                Nombre = empleado.Nombre.Trim().ToLower(),
                Telefono = empleado.Telefono.Trim(),
                Correo = empleado.Correo.Trim(),
                Foto = empleado.Foto.Trim(),
                FechaContratacion = empleado.FechaContratacion
            });

            await _context.SaveChangesAsync();

            return new DTOEmpleado
            {
                Id = nuevoEmpleado.Entity.Id,
                Apellido = nuevoEmpleado.Entity.Apellido.Trim().ToLower(),
                Nombre = nuevoEmpleado.Entity.Nombre.Trim().ToLower(),
                Telefono = nuevoEmpleado.Entity.Telefono.Trim(),
                Correo = nuevoEmpleado.Entity.Correo.Trim(),
                Foto = nuevoEmpleado.Entity.Foto.Trim(),
                FechaContratacion = nuevoEmpleado.Entity.FechaContratacion
            };
        }

        public async Task ActualizarEmpleado(DTOEmpleado empleado)
        {
            if (empleado == null)
                throw new ArgumentNullException();

            var empleadoEncontrado = await _context.Empleados.FindAsync(empleado.Id);
            if (empleadoEncontrado == null)
                throw new NullReferenceException();

            empleadoEncontrado.Apellido = empleado.Apellido.Trim().ToLower();
            empleadoEncontrado.Nombre = empleado.Nombre.Trim().ToLower();
            empleadoEncontrado.Telefono = empleado.Telefono.Trim();
            empleadoEncontrado.Correo = empleado.Correo.Trim().ToLower();
            empleadoEncontrado.Foto = empleado.Foto.Trim();
            empleadoEncontrado.FechaContratacion = empleado.FechaContratacion;

            await _context.SaveChangesAsync();
        }


        public async Task EliminarEmpleado(int idEmpleado)
        {
            if (idEmpleado == 0)
                throw new ArgumentNullException();

            var empleadoEncontrado = await _context.Empleados.FindAsync(idEmpleado);
            if (empleadoEncontrado == null)
                throw new NullReferenceException();

            _context.Empleados.Remove(empleadoEncontrado);
            await _context.SaveChangesAsync();
        }
    }
}
