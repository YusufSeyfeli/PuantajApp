import { Injectable } from '@angular/core';
import {firstValueFrom, Observable} from "rxjs";
import {HttpReturnModel} from "../../../Models/httpReturnModel";
import {CustomToastrService, ToastrMessageType, ToastrPosition} from "../custom-toastr.service";
import {HttpClientService} from "../../http-client.service";
import {UserOperationClaim} from "../../../Models/user-operation-claim";

@Injectable({
  providedIn: 'root'
})
export class UserOperationClaimService {

  constructor(private httpclient: HttpClientService,
              private toastrService: CustomToastrService) { }

  async getUserOperationClaim(callBackFunction?: ()=> void) {
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.get<any | HttpReturnModel>({
      controller:"UserOperationClaims",
      action: "GetList"
    });
    const myUserOperationClaims: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    if (callBackFunction) { callBackFunction(); }
    return myUserOperationClaims.data;
  }

  async getUserOperationClaimById(userOperationClaimGuidId:string, callBackFunction?: ()=> void){
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.get<any | HttpReturnModel>({
      controller:"UserOperationClaims",
      action:"GetById"
    }, userOperationClaimGuidId, "UserOperationClaimGuidId");
    const myUserOperationClaims: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    return myUserOperationClaims.data;
    //@ts-ignore
    if (callBackFunction) { callBackFunction(); }
  }

  async UpdateUserOperationClaim(userOperationClaim:UserOperationClaim, callBackFunction?: ()=> void){
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.put<any | HttpReturnModel>({
      controller:"UserOperationClaims",
      action:"Update"
    },userOperationClaim);
    const myUserOperationClaims: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    if(myUserOperationClaims){
      const message: string = (myUserOperationClaims.message!= undefined ? myUserOperationClaims.message: "Kullanıcı Yetkileri başarıyla düzenlendi.")
      this.toastrService.message(message, "Düzenlendi.", {
        messageType: ToastrMessageType.Success,
        position: ToastrPosition.TopRight
      });
    }
    //@ts-ignore
    if (callBackFunction) { callBackFunction(); }
  }

  async DeleteUserOperationClaim(userOperationClaimGuidId:string, callBackFunction?: ()=> void){
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.delete<any | HttpReturnModel>({
      controller:"UserOperationClaims",
      action:"Delete"
    }, userOperationClaimGuidId, "UserOperationClaimGuidId");
    const myUserOperationClaims: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    if(myUserOperationClaims) {
      const message: string = (myUserOperationClaims.message != undefined ? myUserOperationClaims.message : "Kullanıcı Yetkileri başarıyla silindi.")

      this.toastrService.message(message, "Silindi.", {
        messageType: ToastrMessageType.Success,
        position: ToastrPosition.TopRight
      });
    }
    //@ts-ignore
    if (callBackFunction) { callBackFunction(); }
  }

  async AddUserOperationClaim(userOperationClaim:UserOperationClaim, callBackFunction?: ()=> void){
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.post<any | HttpReturnModel>({
      controller:"UserOperationClaims",
      action:"Add"
    }, userOperationClaim);
    const myUserOperationClaims: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    if(myUserOperationClaims) {
      const message: string = (myUserOperationClaims.message != undefined ? myUserOperationClaims.message : "Kullanıcı Yetkileri başarıyla eklendi.")

      this.toastrService.message(message, "Eklendi", {
        messageType: ToastrMessageType.Success,
        position: ToastrPosition.TopRight
      });
    }
    //@ts-ignore
    if (callBackFunction) { callBackFunction(); }
  }

  async BulkAddUserOperationClaim(userOperationClaims:UserOperationClaim[], callBackFunction?: () => Promise<void>){
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.post<any | HttpReturnModel>({
      controller:"UserOperationClaims",
      action:"BulkAddForUserOperationClaim"
    }, userOperationClaims);
    const myuserOperationClaims: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    if(myuserOperationClaims) {
      const message: string = (myuserOperationClaims.message != undefined ? myuserOperationClaims.message : "Başarıyla Eklendi.")

      this.toastrService.message(message, "Eklendi", {
        messageType: ToastrMessageType.Success,
        position: ToastrPosition.TopRight
      });
    }
    if (callBackFunction) { await callBackFunction(); }
  }

  async BulkDeleteUserOperationClaim(userGuidId: string, callBackFunction?: (callBackFunction?: (myUser: string, callBackFunction?: () => Promise<void>) => Promise<void>) => Promise<void>){
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.delete<any | HttpReturnModel>({
      controller:"UserOperationClaims",
      action:"BulkDeleteForUserOperationClaim"
    }, userGuidId, "userGuidId");
    const myOperationCompetency: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    if(myOperationCompetency) {
      const message: string = (myOperationCompetency.message != undefined ? myOperationCompetency.message : "Başarıyla Silindi.")

      this.toastrService.message(message, "Silindi.", {
        messageType: ToastrMessageType.Success,
        position: ToastrPosition.TopRight
      });
    }
    if (callBackFunction) { // @ts-ignore
      await callBackFunction(); }
  }
}
