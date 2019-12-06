import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { PageRoutingModule } from '../page-routing.module';
import { LayoutModule } from '@angular/cdk/layout';
import { AppRoutingModule } from 'src/app/app-routing.module';
import { HttpClientModule, HttpClientJsonpModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgZorroAntdModule, NzBreadCrumbModule, NzPopoverModule } from 'ng-zorro-antd';
import { NavbarComponent } from '../widget/navbar/navbar.component';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

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
    BrowserModule,
    HttpClientJsonpModule,
    BrowserAnimationsModule,
  ],exports:[
    PageRoutingModule
  ],
  bootstrap:    [ NavbarComponent ],
})
export class HomeModule { }
