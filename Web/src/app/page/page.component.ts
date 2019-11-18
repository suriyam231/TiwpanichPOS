import { Component, OnInit, TemplateRef } from '@angular/core';
import { NzModalRef, NzNotificationService, NzModalService } from 'ng-zorro-antd';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { PageService } from './page.service';
import { IRegisterModel, RegisterModel } from '../Model/register.model';

@Component({
  selector: 'app-page',
  templateUrl: './page.component.html',
  styleUrls: ['./page.component.scss']
})
export class PageComponent implements OnInit {

  status: boolean;
  user: any = {};
  validateForm: FormGroup;
  validateRegister: FormGroup;
  userName
  password



  //registerType
  province
  District
  Subdistricts
  Zipcode
  ActivePass
  rePasswordNew
  PasswordNew
  UsernameNew
  ZipcodeStak
  mSubdistricts
  mDistrict
  mProvince
  LocationNmber
  StoreName
  StoreID
  constructor(private service: PageService,
    private notification: NzNotificationService,
    private fb: FormBuilder,
    private modalService: NzModalService,
    public Ruoter: Router
  ) {

  }

  ngOnInit() {
    this.validateForm = this.fb.group({
      userName: [null, [Validators.required]],
      password: [null, [Validators.required]],
      remember: [true]
    });
    this.validateRegister = this.fb.group({
      StoreID: [null, [Validators.required]],
      StoreName: [null, [Validators.required]],
      LocationNmber: [null, [Validators.required]],
      Province: [null, [Validators.required]],
      District: [null, [Validators.required]],
      Subdistricts: [null, [Validators.required]],
      Zipcode: [null, [Validators.required]],
      UsernameNew: [null, [Validators.required]],
      PasswordNew: [null, [Validators.required]],
      rePasswordNew: [null, [Validators.required]],
      ActivePass: [null, [Validators.required]],
    });

  }


  submitForm(): void {
    for (const i in this.validateForm.controls) {
      this.validateForm.controls[i].markAsDirty();
      this.validateForm.controls[i].updateValueAndValidity();
    }


    if (this.userName === "admin" && this.password === "1234") {
  
      this.Ruoter.navigate(['/home']);
    }

    if (this.userName != "admin" && this.password === "1234") {
      this.notification.create('error', 'รหัสผู้ใช้ผิด', 'กรุณาตรวจสอบรหัสผู้ใช้')
    }
    if (this.userName === "admin" && this.password != "1234") {
      this.notification.create('error', 'รหัสผ่านผิด', 'กรุณาตรวจสอบรหัสผ่าน')
    }
    if (this.userName != "admin" && this.password != "1234" && this.userName != undefined) {
      this.notification.create('error', 'รหัสผู้ใช้และรหัสผ่านผิด', 'กรุณาตรวจสอบหัสผู้ใช้และรหัสผ่าน')
    }
  }




  tplModal: NzModalRef;
  tplModalButtonLoading = false;
  htmlModalVisible = false;


  createTplModal(tplTitle: TemplateRef<{}>, tplContent: TemplateRef<{}>, tplFooter: TemplateRef<{}>): void {
    this.tplModal = this.modalService.create({
      nzTitle: tplTitle,
      nzContent: tplContent,
      nzFooter: tplFooter,
      nzMaskClosable: false,
      nzClosable: false,
      nzOnOk: () => console.log('Click ok')
    });
    this.service.getProvince().subscribe((res: any) => {
      this.province = res
    })
  }

  destroyTplModal(): void {
    this.tplModalButtonLoading = true;
    setTimeout(() => {
      this.tplModalButtonLoading = false;
      this.tplModal.destroy();
    });
  }

  getDistrict(data) {
    let District = this.province.filter(a => a.nameInThai === data)

    this.service.getDistrict(District[0].id).subscribe((res: any) => {
      this.District = res
    });

  }
  getSubdistricts(data) {
    let Subdistricts = this.District.filter(a => a.nameInThai === data)

    this.service.getSubdistricts(Subdistricts[0].id).subscribe((res: any) => {
      this.Subdistricts = res
    });
  }

  getZipcode(data) {
    let Subdistricts = this.Subdistricts.filter(a => a.nameInThai === data)
    this.ZipcodeStak = Subdistricts[0].zipCode

  }
  data = []

  RegisterOK(): void {
    for (let i = 0; i < 1; i++) {
      let register = new RegisterModel()
      register.STOREID = this.StoreID
      register.STORENAME = this.StoreName
      register.LOCATIONNUMBER = this.LocationNmber
      register.PROVINCE = this.mProvince
      register.DISTRICT = this.mDistrict
      register.SUBDISTRICT = this.mSubdistricts
      register.ZIPCODE = this.ZipcodeStak
      register.USERNAME = this.UsernameNew
      register.PASSWORD = this.PasswordNew
      register.STATUS = 'owner'
      this.data.push(register)
    }
    this.service.AddRegister(this.data).subscribe((res :any)=>{
      debugger
    })
  
  }
}
