import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PageComponent } from './page.component';
import { HomeComponent } from './home/home.component';
const routes: Routes = [
  {
    path: '',
    component:PageComponent,
  },{
    path: 'home',
    component :HomeComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PageRoutingModule { }
