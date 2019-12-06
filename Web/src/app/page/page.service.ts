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

  // หน้า Addproduct
  public getTypeProduct(){
    return this.http.get(`Warehouse/getTypeProduct`);
  }
  public getProduct(){
    return this.http.get(`Warehouse/getProduct`);
  }
  public AddProduct(values){
    return this.http.post(`Warehouse/addProduct`,values ,{ responseType: 'text' });
  }
  public updateProduct(ModalType,number,ProductID){
    debugger
    return this.http.post(`Warehouse/updateProduct/${ModalType}/${ProductID}/${number}`,number,{ responseType: 'text' });
  }

  // หน้า Warehouse
  public updateProductDe(values){
    return this.http.post(`Warehouse/Productupdate`,values ,{ responseType: 'text' });
  }

  public deleteProduct(values){
    return this.http.delete(`Warehouse/deleteProduct/${values}`);
  }
} 