import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PageRoutingModule } from './page-routing.module';
import { PageComponent } from './page.component';
import { LayoutModule } from '@angular/cdk/layout';
import { AppRoutingModule } from '../app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NzBreadCrumbModule, NgZorroAntdModule, NzPopoverModule } from 'ng-zorro-antd';

@NgModule({
  declarations: [PageComponent],
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
export class PageModule { }
