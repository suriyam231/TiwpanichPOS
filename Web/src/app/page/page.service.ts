import { Injectable } from "@angular/core";
import { HttpService } from "../http.service";

@Injectable({
  providedIn: 'root'
})
export class PageService {
  constructor(private http: HttpService) { }


  public get() {
    return this.http.get(`DBBranch/GetName`);
  }
  public add(firstname: any, lastname: any) {
    return this.http.post(`DBBranch/addName/${firstname}/${lastname}`, firstname, { responseType: 'text' });
  }

  public getProvince() {
    return this.http.get(`Page/getProvine`);
  }
  public getDistrict(District: any) {

    return this.http.get(`Page/getDistrict/${District}`)
  }

  public getSubdistricts(Subdistricts: any) {
    return this.http.get(`Page/getSubdistricts/${Subdistricts}`)
  }
  public AddRegister(data: any) {
    return this.http.post(`Page/addRegister/${data}`, data, { responseType: 'text' });
  }



  // หน้าHome 
  public CheckUser(username,password){
    return this.http.get(`Page/CheckUser/${password}/${username}`)
  }
  public getStore(StoreID){
    return this.http.get(`Page/getStore/${StoreID}`)
  }
} 