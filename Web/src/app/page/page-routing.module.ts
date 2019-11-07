import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PageComponent } from './page.component';
import { HomeComponent } from './home/home.component';
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
const routes: Routes = [
  {
    path: '',
    component:PageComponent,
  },{
    path: 'home',
    component :HomeComponent
  },{
    path : 'previousbills',
    component : PreviousbillsComponent
  },{
    path : 'billmanage',
    component : BillmanageComponent
  },{
    path : 'addproducts',
    component : AddproductsComponent
  },{
    path : 'editproducts',
    component : EditproductsComponent
  },{
    path : 'warehouse',
    component : WarehouseComponent
  },{
    path : 'littleproduct',
    component : LittleproductComponent
  },{
    path : 'outstock',
    component : OutstockComponent
  },{
    path : 'salesreport',
    component : SalesreportComponent
  },{
    path : 'bestseller',
    component : BestsellerComponent
  },{
    path : 'lesssale',
    component : LesssaleComponent
  },{
    path : 'editstore',
    component : EditstoreComponent
  },{
    path : 'adduser',
    component : AdduserComponent
  },{
    path : 'testscanner',
    component : TestscannerComponent
  },{
    path : 'howtouse',
    component : HowtouseComponent
  },{
    path : 'reportusage',
    component : ReportusageComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PageRoutingModule { }
