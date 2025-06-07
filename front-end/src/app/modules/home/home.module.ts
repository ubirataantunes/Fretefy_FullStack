import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { CadastrarComponent } from './cadastrar/cadastrar.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HomeRoutingModule } from './home.routing';

@NgModule({
  imports: [CommonModule, FormsModule, ReactiveFormsModule, HomeRoutingModule],
  declarations: [HomeComponent, CadastrarComponent],
  exports: [HomeComponent],
})
export class HomeModule {}
