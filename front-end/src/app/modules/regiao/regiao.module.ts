import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegiaoComponent } from './regiao.component';
import { RegiaoRoutingModule } from './regiao.routing';
import { ListarComponent } from './listar/listar.component';
import { CadastrarComponent } from './cadastrar/cadastrar.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CidadeSelectComponent } from 'src/app/components/select/cidade-select/cidade-select.component';

@NgModule({
  imports: [
    CommonModule,
    RegiaoRoutingModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  declarations: [RegiaoComponent, ListarComponent, CadastrarComponent, CidadeSelectComponent],
  exports: [RegiaoComponent, ListarComponent, CadastrarComponent],
})
export class RegiaoModule { }
