import {Injectable} from '@angular/core';
import {HttpClientService} from "../../http-client.service";
import {delay, firstValueFrom, Observable} from "rxjs";
import { TokenResponse } from "../../../Models/Token/tokenResponse";
import { CustomToastrService, ToastrMessageType, ToastrPosition } from '../custom-toastr.service';
import { NgxSpinnerService } from 'ngx-spinner';
import {Router} from "@angular/router";
import {HttpReturnModel} from "../../../Models/httpReturnModel";
import {OperationClaim} from "../../../Models/operation-claim";
import {postUser, User} from "../../../Models/user";


@Injectable({
  providedIn: 'root'
})

export class UserService {

  constructor(private httpclient: HttpClientService, private toastrService: CustomToastrService, private spinner: NgxSpinnerService, private router: Router) { }

  async login(email: string, password: string, callBackFunction?: ()=> void): Promise<void>  {
    //this.spinner.show();
    const observable: Observable<any | TokenResponse> =  this.httpclient.post<any | TokenResponse>({
      controller:"Auth",
      action:"Login"
    },{ email,password });

    const tokenResponse: TokenResponse = await firstValueFrom(observable) as TokenResponse;

    if(tokenResponse){
      localStorage.setItem("accessToken", <string>tokenResponse.data?.accessToken);
      localStorage.setItem("refreshToken", <string>tokenResponse.data?.refreshToken);
      localStorage.setItem("userGuidId", <string>tokenResponse.data?.userGuidId);
      localStorage.setItem("myclaim", String(<boolean>tokenResponse.data?.myClaim));

      this.toastrService.message("Başarıyla Giriş Yapıldı.", "Giriş", {
        messageType: ToastrMessageType.Success,
        position: ToastrPosition.TopRight
      });
      localStorage.setItem("expiration", <string>tokenResponse.data?.expiration?.toString());
    }else{
      this.toastrService.message("E-Posta yada Şifre yanlış .", "Giriş", {
        messageType: ToastrMessageType.Error,
        position: ToastrPosition.TopRight
      });
    }
    //this.spinner.hide();
    if (callBackFunction) { callBackFunction(); }
  }


  async getAllUser(callBackFunction?: ()=> void) {
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.get<any | HttpReturnModel>({
      controller:"User",
      action:"GetList"
    });
    const user: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    if (callBackFunction) { callBackFunction(); }
    return user.data;
  }

  async getUserById(id:string, callBackFunction?: ()=> void){
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.get<any | HttpReturnModel>({
      controller:"User",
      action:"GetById"
    }, id,"userGuidId");
    const user: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;

    if (callBackFunction) { callBackFunction(); }
    return user.data;
  }

  async UpdateUser(user: postUser, callBackFunction?: (myUser: string, callBackFunction?: () => Promise<void>) => Promise<void>){
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.put<any | HttpReturnModel>({
      controller:"User",
      action:"Update"
    }, user);
    const myuser: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;

    if(myuser){
      const message: string = (myuser.message!= undefined ? myuser.message: "Başarıyla Düzenlendi.")
      this.toastrService.message(message, "Düzenlendi.", {
        messageType: ToastrMessageType.Success,
        position: ToastrPosition.TopRight
      });
    }
    if (callBackFunction) {
      // @ts-ignore
      await callBackFunction(); }
  }

  async DeleteUser(id:string, callBackFunction?: ()=> void){
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.delete<any | HttpReturnModel>({
      controller:"User",
      action:"Delete"
    }, id, "userGuidId");
    const myuser: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    if(myuser) {
      const message: string = (myuser.message != undefined ? myuser.message : "Başarıyla Silindi.")

      this.toastrService.message(message, "Silindi.", {
        messageType: ToastrMessageType.Success,
        position: ToastrPosition.TopRight
      });
    }
    //@ts-ignore
    if (callBackFunction) { callBackFunction(); }
  }

  /*async AddUser(user:User, callBackFunction?: ()=> void){
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.post<any | HttpReturnModel>({
      controller:"User",
      action:"Add"
    }, user);
    const myuser: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    if(myuser) {
      const message: string = (myuser.message != undefined ? myuser.message : "Başarıyla Eklendi.")

      this.toastrService.message(message, "Eklendi", {
        messageType: ToastrMessageType.Success,
        position: ToastrPosition.TopRight
      });
    }
    //@ts-ignore
    if (callBackFunction) { callBackFunction(); }
  }*/

  async ChangePassword(userGuidId: string | undefined, currentPassword: string | undefined, newPassword: string, callBackFunction?: () => void){
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.post<any | HttpReturnModel>({
      controller:"User",
      action:"ChangePassword"
    }, {userGuidId,currentPassword,newPassword});
    const myuser: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    if(myuser) {
      const message: string = (myuser.message != undefined ? myuser.message : "Başarıyla Şifre değiştirildi.")

      this.toastrService.message(message, "Değiştirildi", {
        messageType: ToastrMessageType.Success,
        position: ToastrPosition.TopRight
      });
    }
    //@ts-ignore
    if (callBackFunction) { callBackFunction(); }
  }
}
