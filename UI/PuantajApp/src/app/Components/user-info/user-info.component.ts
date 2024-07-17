import {Component, OnInit} from '@angular/core';
import {User} from "../../Models/user";
import {UserService} from "../../Services/ui/Components/user.service";
import {CustomToastrService, ToastrMessageType, ToastrPosition} from "../../Services/ui/custom-toastr.service";
import {UserChangePassword} from "../../Models/UserChangePassword";
import {JobUnit} from "../../Models/job-unit";
import {JobDepartment} from "../../Models/JobDepartment";

@Component({
  selector: 'app-user-info',
  templateUrl: './user-info.component.html',
  styleUrls: ['./user-info.component.scss']
})
export class UserInfoComponent  implements OnInit{
  constructor(private userService:UserService,
              private toastrService: CustomToastrService) {
  }
  ngOnInit(){
    // @ts-ignore
    this.myId = localStorage.getItem('userGuidId');
    this.changePassword.UserGuidId = this.myId;
    this.userService.getUserById(this.myId).then(data => {
      this.user = data;
    });
  }

  myId!: string;
  user: User = {}
  changePassword: UserChangePassword = {}
  userInfoDialog: boolean = false;
  submitted: boolean = false;
  againNewPassword: string = "";
  submitPass: boolean = false;
  errorMessage: string = "";
  regex = /^(?=.*[A-Z])(?=.*[.!@#$%^&*])(?=.*[0-9]).{8,}$/;


  openNew() {
    this.submitted = false;
    this.userInfoDialog = true;

  }
  hideDialog() {
    this.userInfoDialog = false;
    this.submitted = false;
  }
  async ChangePassword() {
    this.submitted = true;
    if (this.changePassword.newPassword == this.againNewPassword){
      if (this.regex.test(this.changePassword.newPassword)) {
        await this.userService.ChangePassword(this.user.userGuidId,this.changePassword.currentPassword,this.changePassword.newPassword);
        this.userInfoDialog = false;
      } else {
        this.submitPass = true;
        this.toastrService.message("Şifreniz belirtilen kurallara uymalıdır: en az bir büyük harf, bir özel karakter, ' +\n" +
          "          'bir sayı içermeli ve en az 8 haneli olmalı. ", "Tekrar Giriniz", {
          messageType: ToastrMessageType.Error,
          position: ToastrPosition.BottomFullWidth
        });
        this.userInfoDialog = false;
      }
    }else {
      this.toastrService.message("Yeni Şifre Eşleşmiyor!! ", "Tekrar Giriniz", {
        messageType: ToastrMessageType.Error,
        position: ToastrPosition.BottomLeft
      });
      this.userInfoDialog = false;
    }
  }


}
