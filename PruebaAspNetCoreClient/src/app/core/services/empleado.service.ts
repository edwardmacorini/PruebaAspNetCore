import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Empleado } from '../models/empleado';

@Injectable({
  providedIn: 'root'
})
export class EmpleadoService {
  private ENDPOINT_EMPLEADOS = `${environment.apiUrl}/empleados`;

  constructor(private httpCliente: HttpClient) { }

  public obtenerEmpleados(): Observable<Empleado[]> {
    return this.httpCliente.get<Empleado[]>(this.ENDPOINT_EMPLEADOS);
  }

  public obtenerEmpleado(idEmpleado: number): Observable<Empleado> {
    return this.httpCliente.get<Empleado>(this.ENDPOINT_EMPLEADOS + '/' + idEmpleado);
  }

  public agregarEmpleado(empleado: Empleado): Observable<Empleado> {
    return this.httpCliente.post<Empleado>(this.ENDPOINT_EMPLEADOS, empleado);
  }

  public actualizarEmpleado(empleado: Empleado): Observable<Empleado> {
    return this.httpCliente.put<Empleado>(this.ENDPOINT_EMPLEADOS, empleado);
  }

  public eliminarEmpleado(idEmpleado: number) {
    return this.httpCliente.delete(this.ENDPOINT_EMPLEADOS + '/' + idEmpleado);
  }
}
