// library
import { NgModule } from '@angular/core';
// router
import { Routes, RouterModule } from '@angular/router';
import { from } from 'rxjs';
const routes: Routes = [
  { path: 'home', loadChildren: '../app/home-page/home-page.module#HomePageModule' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }


