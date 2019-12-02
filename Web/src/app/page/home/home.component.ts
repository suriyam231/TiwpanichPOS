import { Component, OnInit, TemplateRef, ElementRef, ViewChild, Output } from '@angular/core';
import { HostListener, EventEmitter } from '@angular/core';
import { Key } from 'protractor';
import { NzModalRef, NzModalService } from 'ng-zorro-antd';
import { ActivatedRoute, Router } from '@angular/router';
import { PageService } from '../page.service';
import { BillModel } from 'src/app/Model/Bill.model';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {


  UserID: any;
  StoreName: string;
  FirstName: string;
  LastName: string;
  Position: string;
  StoreID: any;
  ProductData;
  listOfData = new Array
  ProductID
  constructor(private modalService: NzModalService,
    private router: ActivatedRoute,
    private service: PageService,
    public Ruoter: Router) { }
  Total: number = 0

  @Output() eventData: EventEmitter<string> = new EventEmitter();
  ngOnInit() {

    this.UserID = this.router.snapshot.params.UserID;
    this.Position = this.router.snapshot.params.Position;
    this.StoreID = this.router.snapshot.params.Storeid;
    this.FirstName = this.router.snapshot.params.FirstName;
    this.LastName = this.router.snapshot.params.LastName;
    this.getStore();
    this.getProduct();

    // for (let i = 0; i < this.listOfData.length; i++) {
    //   this.Total = this.Total + this.listOfData[i].Price
    // }
  }

  getStore() {
    this.service.getStore(this.StoreID).subscribe((res: any) => {
      this.StoreName = res[0].storeName
    })
  }
  getProduct() {
    this.service.getProduct().subscribe((res: any[]) => {
      this.ProductData = res;

    })
  }
  Data
  searchProduct(values) {
    let data = this.ProductData.filter(a => a.productId === values)
    for (let i = 0; i < this.listOfData.length; i++) {
      if (this.Data[i].PRODUCTID === data[0].productId) {
        this.Data[i].PRODUCTNUMBER = this.Data[i].PRODUCTNUMBER + 1;
        this.Data[i].PRODUCTPRICE = this.Data[i].PRODUCTPRICE + data[0].productPrice;
        this.ProductID = "";
        break;
      }

      let check = this.listOfData.filter( a => a.PRODUCTID === values);
      if (this.listOfData[i].PRODUCTID != values && check.length === 0) {

        let value = new BillModel();
        value.INDEX = this.listOfData.length +1;
        value.PRODUCTID = data[0].productId;
        value.PRODUCTNAME = data[0].productName;
        value.PRODUCTNUMBER = 1;
        value.PRODUCTPRICE = data[0].productPrice;
        this.listOfData.push(value);
        this.Data = this.listOfData;
        this.ProductID = "";
        break;
      }
    }
    if (this.listOfData.length === 0) {
      let value = new BillModel();
      value.INDEX = 1;
      value.PRODUCTID = data[0].productId;
      value.PRODUCTNAME = data[0].productName;
      value.PRODUCTNUMBER = 1;
      value.PRODUCTPRICE = data[0].productPrice;
      this.listOfData.push(value);
      this.Data = this.listOfData;
      this.ProductID = "";
    }
    this.Price = 0;
    for(let i = 0 ; i < this.listOfData.length;i++){
      this.Price = this.Price + this.listOfData[i].PRODUCTPRICE;
    }
    this.Total = this.Price;
  }
Price = 0;


  //ส่งค่าไปหน้า "ตรวจสอบบิลย้อนหลัง"
  onClickPreviousbills() {
    this.Ruoter.navigate(['/previousbills', { UserID: this.UserID, Storeid: this.StoreID, FirstName: this.FirstName, LastName: this.LastName, Position: this.Position }]);
  }

  onClickAddproducts() {
    this.Ruoter.navigate(['/addproducts', { UserID: this.UserID, Storeid: this.StoreID, FirstName: this.FirstName, LastName: this.LastName, Position: this.Position }]);
  }



  //ส่งค่าไปหน้า "แก้ไข้ข้อมูลร้าน"
  onClickEditstore() {
    this.Ruoter.navigate(['/editstore', { UserID: this.UserID, Storeid: this.StoreID, FirstName: this.FirstName, LastName: this.LastName, Position: this.Position }]);
  }



  Key
  @ViewChild('Checkbill', { static: false }) checkbill: ElementRef;
  @ViewChild('Getbill', { static: false }) getbill: ElementRef;
  @ViewChild('Selectbill', { static: false }) selectbill: ElementRef;


  @HostListener('window:keydown', ['$event'])
  handleKeyDown(event: KeyboardEvent) {
    this.ProductID

    if (event.key === 'Enter' && this.ProductID === "") {

      let el: HTMLElement = document.getElementById('Checkbill') as HTMLElement;
      el.click();
      event = undefined
      this.Key = event
    }
    if (event.key === 'Escape') {
      this.CheckModal = false
    }
    if (event.key === 'F2') {
      let el: HTMLElement = document.getElementById('Getbill') as HTMLElement;
      el.click();
    }
    if (event.key === 'F3') {
      let el: HTMLElement = document.getElementById('Selectbill') as HTMLElement;
      el.click();
    }
  }


  CheckbillModal: NzModalRef;
  tplModalButtonLoading = false;
  htmlModalVisible = false;
  disabled = false;
  CheckModal = false;

  Checkbill(tplTitle: TemplateRef<{}>, tplContent: TemplateRef<{}>, tplFooter: TemplateRef<{}>): void {
    this.CheckbillModal = this.modalService.create({
      nzTitle: tplTitle,
      nzContent: tplContent,
      nzFooter: tplFooter,
      nzMaskClosable: false,
      nzClosable: false,
      nzOnOk: () => console.log('Click ok')

    });
    this.CheckModal = true
  }

  GetbillModal: NzModalRef;
  GetbillModalButtonLoading = false;

  Getbill(tplTitle: TemplateRef<{}>, tplContent: TemplateRef<{}>, tplFooter: TemplateRef<{}>): void {
    this.CheckbillModal = this.modalService.create({
      nzTitle: tplTitle,
      nzContent: tplContent,
      nzFooter: tplFooter,
      nzMaskClosable: false,
      nzClosable: false,
      nzOnOk: () => console.log('Click ok')

    });
    this.CheckModal = true
  }


  SelectbillModal: NzModalRef;
  SelectbillModalButtonLoading = false;

  Selectbill(tplTitle: TemplateRef<{}>, tplContent: TemplateRef<{}>, tplFooter: TemplateRef<{}>): void {
    this.CheckbillModal = this.modalService.create({
      nzTitle: tplTitle,
      nzContent: tplContent,
      nzFooter: tplFooter,
      nzMaskClosable: false,
      nzClosable: false,
      nzOnOk: () => console.log('Click ok')

    });
    this.CheckModal = true
  }


}
