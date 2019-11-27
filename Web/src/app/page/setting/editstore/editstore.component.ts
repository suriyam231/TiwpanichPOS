import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PageService } from '../../page.service';

@Component({
  selector: 'app-editstore',
  templateUrl: './editstore.component.html',
  styleUrls: ['./editstore.component.scss']
})
export class EditstoreComponent implements OnInit {
  UserID: any;
  Position: any;
  StoreID: any;
  constructor(private router: ActivatedRoute,
    private service: PageService) { }
  pageInput = 'editstore'

  ngOnInit() {
    this.UserID = this.router.snapshot.params.UserID;
    this.Position = this.router.snapshot.params.Position;
    this.StoreID = this.router.snapshot.params.Storeid;
    
    this.getStore()
  }


  getStore() {
    this.service.getStore(this.StoreID).subscribe((res : any) =>  {
      debugger
    })
  }

}
