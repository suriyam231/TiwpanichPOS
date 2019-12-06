import { Component, OnInit } from '@angular/core';
import { PageService } from '../../page.service';
import { NzNotificationService } from 'ng-zorro-antd';


@Component({
  selector: 'app-warehouse',
  templateUrl: './warehouse.component.html',
  styleUrls: ['./warehouse.component.scss']
})
export class WarehouseComponent implements OnInit {

  constructor(private service: PageService, private notification: NzNotificationService, ) { }
  pageInput = 'warehouse';

  isAllDisplayDataChecked = false;
  isIndeterminate = false;
  selectedValue = null;
  listOfAllData;
  TypeGroup;
  autocomplete = [];
  options = [];
  data = [];
  ngOnInit() {
    this.getProduct();
    this.getTypeProduct();

  }
  getProduct() {
    this.service.getProduct().subscribe((res: any[]) => {
      this.listOfAllData = res;
      this.data = res;
      for (let i = 0; i < res.length; i++) {
        this.options.push(res[i].productName)
      }
      this.autocomplete = this.options;
    })
  }
  getTypeProduct() {
    this.service.getTypeProduct().subscribe((res: any[]) => {
      this.TypeGroup = res;
    })
  }

  ChangType(value) {
    this.listOfAllData = this.data.filter(a => a.typeName === value);
    if (value === null) {
      this.listOfAllData = this.data;
    }
  }

  onChange(value: string): void {

    this.autocomplete = this.options.filter(option => option.toLowerCase().indexOf(value.toLowerCase()) !== -1);
    this.listOfAllData = this.data.filter(a => a.productName === value);
    if (value === "") {
      this.listOfAllData = this.data;
    }
  }
  Product;
  searchProduct(value) {
    this.listOfAllData = this.data.filter(a => a.productId === value);
    if (this.Product === "") {
      this.listOfAllData = this.data;
    }
  }


  // Modal แก้ไข 
  isVisible = false;
  dataEdit: any;


  ProductID;
  ProductName;
  TypeName;
  ProductAmount;
  ProductPrice;
  CostPrice;
  ProductReference;

  onEdit(value) {
    let values = this.data.filter(a => a.productId === value);
    this.isVisible = true;
    this.ProductID = values[0].productId;
    this.ProductName = values[0].productName;
    this.TypeName = values[0].typeName;
    this.ProductAmount = values[0].productAmount;
    this.ProductPrice = values[0].productPrice;
    this.CostPrice = values[0].costPrice;
    this.ProductReference = values[0].productReference;
  }

  handleOk(value): void {
    this.service.updateProductDe(value).subscribe((res :any) =>{
      if (res === 'success') {
        this.notification.create('success', 'แกไขรายละเอียดสินค้าสำเร็จ', value.ProductName+'อัพเดทเรียบร้อยแล้ว')
        this.ngOnInit();
      }
    })
    this.isVisible = false;
  }

  handleCancel(): void {
    this.isVisible = false;
    this.isDelete = false;
  }
  

  // Modal Delete
  isDelete = false;
  DeleteName;
  DeleteID;
  deleteProduct(value){
    let values = this.data.filter(a => a.productId === value);
    this.DeleteName = values[0].productName;
    this.DeleteID = values[0].productId;
    this.isDelete = true;
  }
  OkDeleye(){
    this.DeleteID
    this.service.deleteProduct(this.DeleteID).subscribe((res : any) => {
      if (res === 'success') {
        this.notification.create('success', 'ลบสินค้าสำเร็จ', '')
        this.isDelete = false;
        this.ngOnInit();
      }
    })
  }

}

