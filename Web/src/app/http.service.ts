import { Injectable } from '@angular/core';

 
import { environment } from '../environments/environment.prod';
import { HttpParams, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';


@Injectable()
export class HttpService {

    constructor(
        private httpClient: HttpClient
    ) {
       
    }

    countLoader: number = 0
 

    get(url: string, responseType: any = 'json'): Observable<any> {
       
        return this.httpClient.get<any>(this.getFullUrl(url), { responseType: responseType });

       
    }

    getResponseBlob(url: string, responseType: any = 'blob'): Observable<any> {
        // debugger
        //this.showLoader(url);
        return this.httpClient.get<any>(this.getFullUrl(url), { responseType: responseType });

        //return this.sendRequest('GET', url);
    }

    getWithParams(url: string, params: any, responseType: any = 'json'): Observable<any> {
        // debugger
        //this.showLoader(url);
        return this.httpClient.get<any>(this.getFullUrl(url), { params: params, responseType: responseType });

        //return this.sendRequest('GET', url);
    }

    post(url: string, body: any, options?: any): Observable<any> {
        return this.httpClient.post<any>(this.getFullUrl(url), body, options);
    }

    put(url: string, body: any): Observable<any> {
        return this.httpClient.put<any>(this.getFullUrl(url), body);
    }

    delete(url: string, responseType: any = 'text'): Observable<any> {
        return this.httpClient.delete<any>(this.getFullUrl(url) , {
            responseType: responseType
        });
    }

    deleteWithParam(url: string, param: HttpParams, responseType: any = 'text'): Observable<any> {
        return this.httpClient.delete<any>(this.getFullUrl(url), {
            params: param , responseType: responseType
        });
    }
 

    private getFullUrl(url: string): string {
        return `${environment.webApiUrl}` + url
    }

 

    
}