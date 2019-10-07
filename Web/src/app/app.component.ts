// library
import { Component, Output, EventEmitter, ViewChild, Directive, OnInit, TemplateRef } from '@angular/core';
import { RouterOutlet, Router, NavigationStart } from '@angular/router';
import { slide } from './animations';
import { NzNotificationService, NzModalService, NzModalRef } from 'ng-zorro-antd';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  // animations: [slide]
})
export class AppComponent implements OnInit {

  // @ViewChild('navbar') navbar


  constructor() {}

  ngOnInit() {

  }

}
