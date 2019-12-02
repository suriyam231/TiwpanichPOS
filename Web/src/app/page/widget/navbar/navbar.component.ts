import { Component, OnInit, Input } from '@angular/core';
import { HomeComponent } from '../../home/home.component';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  UserID
  Position
  StoreID
  FirstName
  LastName
  @Input() pageInput :  string;
  constructor( private router: ActivatedRoute,
    public Ruoter: Router) { }
  ngOnInit() {
    console.log(this.pageInput)
    this.UserID = this.router.snapshot.params.UserID;
    this.Position = this.router.snapshot.params.Position;
    this.StoreID = this.router.snapshot.params.Storeid;
    this.FirstName = this.router.snapshot.params.FirstName;
    this.LastName = this.router.snapshot.params.LastName;
  }

  onClickEvent() {
    this.Ruoter.navigate(['/home', { UserID: this.UserID, Storeid: this.StoreID, FirstName: this.FirstName, LastName: this.LastName, Position: this.Position }]);

  }
  
  
}
