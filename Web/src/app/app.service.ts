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
    public add(firstname:any , lastname:any){
      debugger
      return this.http.post(`DBBranch/addName/${firstname}/${lastname}`,firstname,{ responseType: 'text' });
    }

    public getProvince(){
      return this.http.get(`App/getProvine`);
    } 
}