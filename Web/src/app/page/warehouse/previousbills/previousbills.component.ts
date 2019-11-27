import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-previousbills',
  templateUrl: './previousbills.component.html',
  styleUrls: ['./previousbills.component.scss']
})
export class PreviousbillsComponent implements OnInit {

  constructor() { }
  pageInput = 'previousbills';
  ngOnInit() {
  }
  onChange(result: Date): void {
    console.log('Selected Time: ', result);
  }

  onOk(result: Date): void {
    console.log('onOk', result);
  }
}
