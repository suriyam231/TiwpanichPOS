import { Component, OnInit } from '@angular/core';
import { PageService } from '../../page.service';
import { NzNotificationService, NzModalService } from 'ng-zorro-antd';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-addproducts',
  templateUrl: './addproducts.component.html',
  styleUrls: ['./addproducts.component.scss']
})
export class AddproductsComponent implements OnInit {
  UserID;
  Position;

  listOfData
  productid: '';
  productname: '';
  Data: any[];
  TypeGroup: any[];
  selectedType
  ProductName;
  TypeName;
  ProductAmount;
  ProductPrice;
  CostPrice;
  ProductReference;
  ProductID;

  validateForm: FormGroup;
  isVisible = false;
  constructor(private service: PageService, private notification: NzNotificationService,
    private router: ActivatedRoute,
    private fb: FormBuilder) { }


  ngOnInit() {
    this.UserID = this.router.snapshot.params.UserID;
    this.Position = this.router.snapshot.params.Position;

    this.getTypeProduct();
    this.getProduct();

    this.validateForm = this.fb.group({
      ProductName: [null, [Validators.required]],
      TypeName: [null, [Validators.required]],
      ProductAmount: [null, [Validators.required]],
      ProductPrice: [null, [Validators.required]],
      CostPrice: [null, [Validators.required]],
      ProductReference: [null, [Validators.required]],
      ProductID: [null, [Validators.required]],
    });

  }

  getTypeProduct() {
    this.service.getTypeProduct().subscribe((res: any[]) => {
      this.TypeGroup = res
    })
  }

  getProduct() {
    this.service.getProduct().subscribe((res: any[]) => {
      this.listOfData = res;
      this.Data = res;
    })
  }


  pageInput = 'addproducts';
  submitForm(value) {
    
    for (const i in this.validateForm.controls) {
      this.validateForm.controls[i].markAsDirty();
      this.validateForm.controls[i].updateValueAndValidity();
    }
    this.Data[0] = value
    if (this.Data[0].ProductID != undefined && this.Data[0].CostPrice != undefined &&this.Data[0].ProductPrice != undefined &&this.Data[0].ProductAmount != undefined &&
      this.Data[0].TypeName != undefined &&this.Data[0].ProductName != undefined&&this.Data[0].ProductReference != undefined ) {
      this.service.AddProduct(this.Data).subscribe((res: any) => {
        if (res === 'success') {
          this.notification.create('success', 'เพิ่มสินเค้าใหม่สำเร็จ', '')
          this.ngOnInit();
          this.ProductName = undefined;
          this.TypeName = undefined;
          this.ProductAmount = undefined;
          this.ProductPrice = undefined;
          this.ProductReference = undefined;
          this.ProductID = undefined;
          this.CostPrice = undefined;
        }
      })
    }
  }

  Product
  searchProduct(value) {
    this.listOfData = this.Data.filter(a => a.productId === value)
    if (value === undefined ||value === "" ) {
      this.listOfData = this.Data
    }
  }
  ChangType(value){
    this.listOfData = this.Data.filter(a => a.typeName === value)
    if (value === undefined ||value === null ) {
      this.listOfData = this.Data
    }
  }



// Modal
  Title
  number
  Id
  ModalType
  showModal(data,dataName,dataAmount,dataId): void {
    this.isVisible = true;
    this.ModalType = data;
    this.Title = dataName;
    this.number 
    this.Id = dataId;
  }

  handleOk(ModalType,number): void {
    
    this.service.updateProduct(ModalType,number,this.Id).subscribe((res :any) =>{
      this.isVisible = false;
      if (res === 'success') {
        this.notification.create('success', ModalType+'จำนวนสินค้าสำเร็จ', '')
       this.number = undefined
        this.ngOnInit();
      }
    })
  }

  handleCancel(): void {
    console.log('Button cancel clicked!');
    this.isVisible = false;
  }

}
