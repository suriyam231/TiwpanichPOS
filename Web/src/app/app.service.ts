import { Injectable } from '@angular/core';
import { HttpService } from 'src/app/http.service';

@Injectable({
  providedIn: 'root'
})
export class AppService{
    constructor(private http: HttpService){}
    

    public get(){
        return this.http.get(`DBBranch/GetName`);
    }
}