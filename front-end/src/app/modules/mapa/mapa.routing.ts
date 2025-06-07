import { RouterModule, Routes } from '@angular/router';
import { MapaComponent } from './mapa.component';

const routes: Routes = [
  {
    path: '',
    component: MapaComponent,
  },
];

export const MapaRoutingModule = RouterModule.forChild(routes);