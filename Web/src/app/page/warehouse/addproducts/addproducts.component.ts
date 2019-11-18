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

  constructor() { }
  // productid: string;
  // productname: string;
  // amount: number;
  // price: number;
  // cost: number;
  ngOnInit() {
  }
  pageInput = 'addproducts';

  listOfData = [
    {
      index: 1,
      ProductID: '001',
      ProductName: 'เลย์',
      number: 1,
      Price: 20,
      CostPrice: 18
    }, {
      index: 2,
      ProductID: '002',
      ProductName: 'ผงซักฟอง',
      number: 2,
      Price: 208,
      CostPrice: 200
    }, {
      index: 3,
      ProductID: '003',
      ProductName: 'ปรับผ้านุ่ม',
      number: 10,
      Price: 180,
      CostPrice: 175
    }, {
      index: 4,
      ProductID: '004',
      ProductName: 'ไม้กวาด',
      number: 1,
      Price: 40,
      CostPrice: 39
    }, {
      index: 5,
      ProductID: '005',
      ProductName: 'ไม้ถูพื้น',
      number: 1,
      Price: 100,
      CostPrice: 98
    }
  ];
}
