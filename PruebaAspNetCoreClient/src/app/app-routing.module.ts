import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ConsumoServicioComponent } from './core/components/consumo-servicio/consumo-servicio.component';
import { HomeComponent } from './core/components/home/home.component';

const routes: Routes = [
  {path: '', component: HomeComponent },
  {path: 'coin', component: ConsumoServicioComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
