import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MapaComponent } from './mapa.component';
import { MapaRoutingModule } from './mapa.routing';

@NgModule({
  imports: [CommonModule, MapaRoutingModule],
  declarations: [MapaComponent],
  exports: [MapaComponent],
})
export class MapaModule {}
