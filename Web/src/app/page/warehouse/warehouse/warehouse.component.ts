import { Component, OnInit } from '@angular/core';


interface ItemData {
  index: number,
  ProductID: string,
  ProductName: string,
  number: number,
  Price: number,
  CostPrice: number
}
@Component({
  selector: 'app-warehouse',
  templateUrl: './warehouse.component.html',
  styleUrls: ['./warehouse.component.scss']
})
export class WarehouseComponent implements OnInit {

  constructor() { }
  pageInput = 'warehouse';
  // ngOnInit() {
  // }
  // listOfData = [
  //   {
  //     index: 1,
  //     ProductID: '001',
  //     ProductName: 'เลย์',
  //     number: 1,
  //     Price: 20,
  //     CostPrice: 18
  //   }, {
  //     index: 2,
  //     ProductID: '002',
  //     ProductName: 'ผงซักฟอง',
  //     number: 2,
  //     Price: 208,
  //     CostPrice: 200
  //   }, {
  //     index: 3,
  //     ProductID: '003',
  //     ProductName: 'ปรับผ้านุ่ม',
  //     number: 10,
  //     Price: 180,
  //     CostPrice: 175
  //   }, {
  //     index: 4,
  //     ProductID: '004',
  //     ProductName: 'ไม้กวาด',
  //     number: 1,
  //     Price: 40,
  //     CostPrice: 39
  //   }, {
  //     index: 5,
  //     ProductID: '005',
  //     ProductName: 'ไม้ถูพื้น',
  //     number: 1,
  //     Price: 100,
  //     CostPrice: 98
  //   }, {
  //     index: 5,
  //     ProductID: '005',
  //     ProductName: 'ไม้ถูพื้น',
  //     number: 1,
  //     Price: 100,
  //     CostPrice: 98
  //   }, {
  //     index: 5,
  //     ProductID: '005',
  //     ProductName: 'ไม้ถูพื้น',
  //     number: 1,
  //     Price: 100,
  //     CostPrice: 98
  //   }, {
  //     index: 5,
  //     ProductID: '005',
  //     ProductName: 'ไม้ถูพื้น',
  //     number: 1,
  //     Price: 100,
  //     CostPrice: 98
  //   }, {
  //     index: 5,
  //     ProductID: '005',
  //     ProductName: 'ไม้ถูพื้น',
  //     number: 1,
  //     Price: 100,
  //     CostPrice: 98
  //   },
  // ];
  
  isAllDisplayDataChecked = false;
  isIndeterminate = false;
  listOfDisplayData: ItemData[] = [];
  listOfAllData: ItemData[] = [];
  selectedValue = null;
  
  ngOnInit(): void {
    for (let i = 0; i < 100; i++) {
      this.listOfAllData.push({
        index: i,
        ProductID: `00${i}`,
        ProductName: `Product moc.${i}`,
        number: 50+i,
        Price: 500+i,
        CostPrice: 450+i
      });
    }

    console.log(this.selectedValue)
  }
  isVisible = false;
  dataEdit : any;
  dataTest = "test modal";
  onEdit(value){
    this.isVisible = true;
    this.dataEdit = this.listOfAllData.filter(item => item.index === value);
    console.log('Data',this.dataEdit);

  }

  handleOk(): void {
    console.log('Button ok clicked!');
    this.isVisible = false;
  }

  handleCancel(): void {
    console.log('Button cancel clicked!');
    this.isVisible = false;
  }
}

