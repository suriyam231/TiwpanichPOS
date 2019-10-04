import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { PageRoutingModule } from '../page-routing.module';
import { LayoutModule } from '@angular/cdk/layout';
import { AppRoutingModule } from 'src/app/app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgZorroAntdModule, NzBreadCrumbModule, NzPopoverModule } from 'ng-zorro-antd';

@NgModule({
  declarations: [HomeComponent],
  imports: [
    CommonModule,
    PageRoutingModule,
    LayoutModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    NzBreadCrumbModule,
    NzPopoverModule,
  ],exports:[
    PageRoutingModule
  ],
})
export class HomeModule { }
