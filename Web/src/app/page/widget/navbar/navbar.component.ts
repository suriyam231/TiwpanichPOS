import { Component, OnInit, Input } from '@angular/core';
import { HomeComponent } from '../../home/home.component';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  @Input() pageInput :  string;
  constructor() { }
  ngOnInit() {
  }
  
  
}
