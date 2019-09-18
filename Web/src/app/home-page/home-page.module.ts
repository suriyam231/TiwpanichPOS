import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgZorroAntdModule, NZ_I18N, th_TH, NZ_DATE_LOCALE, NzI18nService } from 'ng-zorro-antd';
import { registerLocaleData } from '@angular/common';
import th from '@angular/common/locales/th';
import { HttpClientModule } from '@angular/common/http';
import { HomePageComponent } from './home-page.component';
import { AppRoutingModule } from '../app-routing.module';

registerLocaleData(th);
@NgModule({
    declarations: [
      HomePageComponent
    ],
    imports: [
        CommonModule,
        FormsModule,
        FormsModule,
        ReactiveFormsModule,
        HttpClientModule,
        AppRoutingModule,
    ],
    providers: [
        {
            provide: NZ_I18N,
            useValue: th_TH
        },
    ],
})
export class HomePageModule { }