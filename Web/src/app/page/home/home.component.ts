import { Component, OnInit, TemplateRef, ElementRef, ViewChild } from '@angular/core';
import { HostListener } from '@angular/core';
import { Key } from 'protractor';
import { NzModalRef, NzModalService } from 'ng-zorro-antd';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {



  

  constructor(private modalService: NzModalService) { }
  Total: number = 0
  ngOnInit() {

    this.listOfData
    for (let i = 0; i < this.listOfData.length; i++) {
      this.Total = this.Total + this.listOfData[i].Price
    }
  }

  listOfData = [
    {
      index: 1,
      ProductName: 'เลย์',
      number: 1,
      Price: 20
    }, {
      index: 2,
      ProductName: 'ผงซักฟอง',
      number: 2,
      Price: 208
    }, {
      index: 3,
      ProductName: 'ปรับผ้านุ่ม',
      number: 10,
      Price: 180
    }, {
      index: 4,
      ProductName: 'ไม้กวาด',
      number: 1,
      Price: 40
    }, {
      index: 5,
      ProductName: 'ไม้ถูพื้น',
      number: 1,
      Price: 100
    }
  ];

  Key
  @ViewChild('Checkbill', { static: false }) checkbill: ElementRef;
  @ViewChild('Getbill', { static: false }) getbill: ElementRef;
  @ViewChild('Selectbill', { static: false }) selectbill: ElementRef;


  @HostListener('window:keydown', ['$event'])
  handleKeyDown(event: KeyboardEvent) {
    if (event.key === 'Enter') {

      let el: HTMLElement = document.getElementById('Checkbill') as HTMLElement;
      el.click();
      event = undefined
      this.Key = event
    }
    if (event.key === 'Escape') {
      this.CheckModal = false
    }
    if(event.key === 'F2'){
      let el: HTMLElement = document.getElementById('Getbill') as HTMLElement;
      el.click();
    }
    if(event.key === 'F3'){
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
