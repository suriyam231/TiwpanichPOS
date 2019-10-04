// library
import { NgModule } from '@angular/core';
// router
import { Routes, RouterModule } from '@angular/router';
import { PageComponent } from './page/page.component';
import { HomeComponent } from './page/home/home.component';

const routes: Routes = [
  {
    path: '',
    component:PageComponent
  },
  { path: '', redirectTo: '', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  
})
export class AppRoutingModule { }


