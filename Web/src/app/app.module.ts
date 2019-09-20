// library
import { BrowserModule } from '@angular/platform-browser';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { FormsModule, FormGroup, FormControl, ReactiveFormsModule, FormBuilder, Validators } from '@angular/forms';
// router


import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
// module

// component
import { AppComponent } from './app.component';
// import { ChartsModule } from 'ng2-charts/ng2-charts';
import { ToastrModule } from 'ngx-toastr';



/** config angular i18n **/
// ng-zorro
import { NgZorroAntdModule, NZ_I18N, th_TH } from 'ng-zorro-antd';
import { registerLocaleData } from '@angular/common';
import th from '@angular/common/locales/th';
import { NzBreadCrumbModule } from 'ng-zorro-antd';
import { NzPopoverModule } from 'ng-zorro-antd';
import { HttpService } from './http.service';
import { AppRoutingModule } from './app-routing.module';
import { HomePageModule } from './home-page/home-page.module';





registerLocaleData(th);

@NgModule({
  declarations: [
    AppComponent,
    
  ],
  imports: [

    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgZorroAntdModule,
    NzBreadCrumbModule,
    NzPopoverModule,
    
  

  ],
  providers: [
    { provide: NZ_I18N, useValue: th_TH }
    ,HttpService
  ]
  ,
  bootstrap: [AppComponent],


})
export class AppModule { }
