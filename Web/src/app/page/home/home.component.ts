import { Component, OnInit, TemplateRef, ElementRef, ViewChild, Output } from '@angular/core';
import { HostListener, EventEmitter } from '@angular/core';
import { Key } from 'protractor';
import { NzModalRef, NzModalService } from 'ng-zorro-antd';
import { ActivatedRoute, Router } from '@angular/router';
import { PageService } from '../page.service';
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
  StoreID : any;
  ProductData;
  listOfData;
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

    for (let i = 0; i < this.listOfData.length; i++) {
      this.Total = this.Total + this.listOfData[i].Price
    }
  }

  getStore() {
    this.service.getStore(this.StoreID).subscribe((res : any) =>  {
      this.StoreName = res[0].storeName
    })
  }
  getProduct(){
    this.service.getProduct().subscribe((res : any[])=>{
      this.ProductData = res;
      
    })
  }

  searchProduct(values){
  this.listOfData = this.ProductData.filter(a => a.productId === values)
  debugger
  }



  //ส่งค่าไปหน้า "ตรวจสอบบิลย้อนหลัง"
  onClickPreviousbills() {
    this.Ruoter.navigate(['/previousbills', { UserID: this.UserID, Storeid: this.StoreID, FirstName: this.FirstName, LastName: this.LastName, Position: this.Position }]);
  }

  onClickAddproducts() {
    this.Ruoter.navigate(['/addproducts', { UserID: this.UserID, Storeid: this.StoreID, FirstName: this.FirstName, LastName: this.LastName, Position: this.Position }]);
  }



  //ส่งค่าไปหน้า "แก้ไข้ข้อมูลร้าน"
  onClickEditstore(){
    this.Ruoter.navigate(['/editstore', { UserID: this.UserID, Storeid: this.StoreID, FirstName: this.FirstName, LastName: this.LastName, Position: this.Position }]);
  }



  Key
  @ViewChild('Checkbill', { static: false }) checkbill: ElementRef;
  @ViewChild('Getbill', { static: false }) getbill: ElementRef;
  @ViewChild('Selectbill', { static: false }) selectbill: ElementRef;


  @HostListener('window:keydown', ['$event'])
  handleKeyDown(event: KeyboardEvent) {
    if (event.key === '') {

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
