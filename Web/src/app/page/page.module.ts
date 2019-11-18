import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PageRoutingModule } from './page-routing.module';
import { PageComponent } from './page.component';
import { LayoutModule } from '@angular/cdk/layout';
import { AppRoutingModule } from '../app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NzBreadCrumbModule, NgZorroAntdModule, NzPopoverModule } from 'ng-zorro-antd';
import { PreviousbillsComponent } from './warehouse/previousbills/previousbills.component';
import { BillmanageComponent } from './warehouse/billmanage/billmanage.component';
import { AddproductsComponent } from './warehouse/addproducts/addproducts.component';
import { EditproductsComponent } from './warehouse/editproducts/editproducts.component';
import { WarehouseComponent } from './warehouse/warehouse/warehouse.component';
import { LittleproductComponent } from './warehouse/littleproduct/littleproduct.component';
import { OutstockComponent } from './warehouse/outstock/outstock.component';
import { SalesreportComponent } from './report/salesreport/salesreport.component';
import { BestsellerComponent } from './report/bestseller/bestseller.component';
import { LesssaleComponent } from './report/lesssale/lesssale.component';
import { EditstoreComponent } from './setting/editstore/editstore.component';
import { AdduserComponent } from './setting/adduser/adduser.component';
import { TestscannerComponent } from './setting/testscanner/testscanner.component';
import { HowtouseComponent } from './setting/howtouse/howtouse.component';
import { ReportusageComponent } from './setting/reportusage/reportusage.component';
import { NavbarComponent } from './widget/navbar/navbar.component';


@NgModule({
  declarations: [PageComponent, 
    PreviousbillsComponent,
    BillmanageComponent,
    AddproductsComponent,
    EditproductsComponent,
    WarehouseComponent,
    LittleproductComponent,
    OutstockComponent,
    SalesreportComponent,
    BestsellerComponent,
    LesssaleComponent,
    EditstoreComponent,
    AdduserComponent,
    TestscannerComponent,
    HowtouseComponent,
    ReportusageComponent,
    NavbarComponent,
    ],
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
