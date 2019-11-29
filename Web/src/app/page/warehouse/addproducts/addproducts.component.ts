import { Component, OnInit } from '@angular/core';
import { PageService } from '../../page.service';
import { NzNotificationService, NzModalService } from 'ng-zorro-antd';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-addproducts',
  templateUrl: './addproducts.component.html',
  styleUrls: ['./addproducts.component.scss']
})
export class AddproductsComponent implements OnInit {
  listOfData 
  productid: '';
  productname: '';
  Data : any[];  
  TypeGroup : any[];
  constructor(private service: PageService,private notification: NzNotificationService) { }
  // amount: number;
  // price: number;
  // cost: number;
  
  ngOnInit() {
    this.getTypeProduct();
    this.getProduct();
  }

  getTypeProduct(){
    this.service.getTypeProduct().subscribe((res : any[]) =>{
      this.TypeGroup = res
    })
  }
  
   getProduct(){
     this.service.getProduct().subscribe((res : any[]) =>{
       this.listOfData = res;
       this.Data =res;
     })
   }

 
  pageInput = 'addproducts';
  submitForm(value){
    
    this.Data[0] = value
    this.service.AddProduct(this.Data).subscribe((res :  any) => {
      if(res === 'success'){
        this.notification.create('success', 'เพิ่มสินเค้าใหม่สำเร็จ', '')
        this.ngOnInit(); 
      }
    })
  }

  Product
  searchProduct(value){
    this.listOfData = this.listOfData.filter(a => a.productId === value)
    debugger
    if(value === ""){
      this.listOfData = this.Data
    }
  }
  
}
