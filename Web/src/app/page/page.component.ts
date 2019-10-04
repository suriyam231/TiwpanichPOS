import { Component, OnInit, TemplateRef } from '@angular/core';
import { NzModalRef, NzNotificationService, NzModalService } from 'ng-zorro-antd';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AppService } from '../app.service';
import { Router } from '@angular/router';

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
  province

  constructor(private service: AppService,
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
      StoreID: [null , [ Validators.required]],
      StoreName:[null , [ Validators.required]],
      LocationNmber:[null , [ Validators.required]],
    });
    
  }


  submitForm(): void {
    for (const i in this.validateForm.controls) {
      this.validateForm.controls[i].markAsDirty();
      this.validateForm.controls[i].updateValueAndValidity();
    }

    
    if(this.userName === "admin"&& this.password === "1234"){
      this.notification.create('success','สำเร็จ','1234')

      this.Ruoter.navigate(['/home']);
      debugger
    }

    if(this.userName != "admin"&& this.password === "1234"){
      this.notification.create('error','รหัสผู้ใช้ผิด','กรุณาตรวจสอบรหัสผู้ใช้')
    } 
    if(this.userName === "admin"&& this.password != "1234"){
      this.notification.create('error','รหัสผ่านผิด','กรุณาตรวจสอบรหัสผ่าน')
    } 
    if(this.userName != "admin"&& this.password != "1234"&& this.userName != undefined ){
      this.notification.create('error','รหัสผู้ใช้และรหัสผ่านผิด','กรุณาตรวจสอบหัสผู้ใช้และรหัสผ่าน')
    }
  }
  getAddress(event,data){
debugger
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
  
  RegisterOK(): void {
  
  }
}
