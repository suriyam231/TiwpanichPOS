import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  constructor() { }
Total :number =0
  ngOnInit() {

    this.listOfData
    for(let i = 0; i < this.listOfData.length;i++ ){
      this.Total =   this.Total + this.listOfData[i].Price
    }
    debugger
  }

  listOfData = [
    {
      index : 1,
      ProductName : 'เลย์',
      number : 1,
      Price : 20
    },{
      index : 2,
      ProductName : 'ผงซักฟอง',
      number : 2,
      Price : 208
    },{
      index : 3,
      ProductName : 'ปรับผ้านุ่ม',
      number : 10,
      Price : 180
    },{
      index : 4,
      ProductName : 'ไม้กวาด',
      number : 1,
      Price : 40
    },{
      index : 5,
      ProductName : 'ไม้ถูพื้น',
      number : 1,
      Price : 100
    }
  ];
}
