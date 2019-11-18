import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-bestseller',
  templateUrl: './bestseller.component.html',
  styleUrls: ['./bestseller.component.scss']
})
export class BestsellerComponent implements OnInit {

  constructor() { }
  ngOnInit() {
  }
  pageInput = 'bestseller'

}
