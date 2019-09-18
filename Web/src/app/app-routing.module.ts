// library
import { NgModule } from '@angular/core';
// router
import { Routes, RouterModule } from '@angular/router';
const routes: Routes = [
  { path: 'home', loadChildren: './home-page/home-page.module#HomePageModule' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }


