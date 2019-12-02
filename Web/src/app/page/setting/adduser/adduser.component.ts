import { Component, OnInit } from '@angular/core';
import { NzI18nService, zh_CN, en_US } from 'ng-zorro-antd';
@Component({
  selector: 'app-adduser',
  templateUrl: './adduser.component.html',
  styleUrls: ['./adduser.component.scss']
})
export class AdduserComponent implements OnInit {

  constructor(private i18n: NzI18nService) { }

  ngOnInit() {
  }
  pageInput = 'adduser'
  current = 0;

  index = 'First-content';

  pre(): void {
    this.current -= 1;
    this.changeContent();
  }

  next(): void {
    this.current += 1;
    this.changeContent();
  }

  done(): void {
    console.log('done');
  }

  changeContent(): void {
    switch (this.current) {
      case 0: {
        this.index = 'First-content';
        break;
      }
      case 1: {
        this.index = 'Second-content';
        break;
      }
      case 2: {
        this.index = 'Third-content';
        break;
      }
      default: {
        this.index = 'error';
      }
    }
  }
  date = null;
  dateRange = [];
  isEnglish = false;

  onChange(result: Date): void {
    console.log('onChange: ', result);
  }

  changeLanguage(): void {
    this.i18n.setLocale(this.isEnglish ? zh_CN : en_US);
    this.isEnglish = !this.isEnglish;
  }
}
