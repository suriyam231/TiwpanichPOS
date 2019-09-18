// library
import { Component, Output, EventEmitter, ViewChild, Directive, OnInit } from '@angular/core';
import { RouterOutlet, Router, NavigationStart } from '@angular/router';
import { slide } from './animations';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  // animations: [slide]
})
export class AppComponent  implements OnInit  {

  // @ViewChild('navbar') navbar
  status: boolean;
  user: any = {};

  constructor() {

  }

  ngOnInit() {
}

  // checkAuthen(value) {
  //   if (this.authen.check()) {
  //     this.status = true;
  //   }
  // }
}
