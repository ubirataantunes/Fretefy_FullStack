import { RouterModule, Routes } from '@angular/router';
import { CadastrarComponent } from './cadastrar/cadastrar.component';
import { ListarComponent } from './listar/listar.component';

const routes: Routes = [
  {
    path: '',
    component: ListarComponent
  },
  { path: 'cadastrar', component: CadastrarComponent },
  { path: 'editar/:id', component: CadastrarComponent },
];

export const RegiaoRoutingModule = RouterModule.forChild(routes);