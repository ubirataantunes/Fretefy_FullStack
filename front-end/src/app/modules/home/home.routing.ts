import { RouterModule, Routes } from '@angular/router';
import { CadastrarComponent } from './cadastrar/cadastrar.component';
import { HomeComponent } from './home.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
  },
  { path: 'home/cadastrar', component: CadastrarComponent },
];

export const HomeRoutingModule = RouterModule.forChild(routes);