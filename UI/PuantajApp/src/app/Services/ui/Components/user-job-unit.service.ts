import { Injectable } from '@angular/core';
import {HttpClientService} from "../../http-client.service";
import {CustomToastrService, ToastrMessageType, ToastrPosition} from "../custom-toastr.service";
import {firstValueFrom, Observable} from "rxjs";
import {HttpReturnModel} from "../../../Models/httpReturnModel";
import {UserOperationClaim} from "../../../Models/user-operation-claim";
import {UserJobUnit} from "../../../Models/UserJobUnit";

@Injectable({
  providedIn: 'root'
})
export class UserJobUnitService {

  constructor(private httpclient: HttpClientService,
             private toastrService: CustomToastrService) { }

  async getUserJobUnit(callBackFunction?: ()=> void) {
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.get<any | HttpReturnModel>({
      controller:"UserJobUnit",
      action: "GetList"
    });
    const myUserJobUnits: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    if (callBackFunction) { callBackFunction(); }
    return myUserJobUnits.data;
  }

  async getUserJobUnitById(userJobUnitGuidId:string, callBackFunction?: ()=> void){
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.get<any | HttpReturnModel>({
      controller:"UserJobUnit",
      action:"GetById"
    }, userJobUnitGuidId, "UserJobUnitGuidId");
    const myUserJobUnits: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    return myUserJobUnits.data;
    //@ts-ignore
    if (callBackFunction) { callBackFunction(); }
  }

  async UpdateUserJobUnit(userJobUnit:UserJobUnit, callBackFunction?: ()=> void){
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.put<any | HttpReturnModel>({
      controller:"UserJobUnit",
      action:"Update"
    },userJobUnit);
    const myUserJobUnits: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    if(myUserJobUnits){
      const message: string = (myUserJobUnits.message!= undefined ? myUserJobUnits.message: "Kullanıcı Yetkileri başarıyla düzenlendi.")
      this.toastrService.message(message, "Düzenlendi.", {
        messageType: ToastrMessageType.Success,
        position: ToastrPosition.TopRight
      });
    }
    //@ts-ignore
    if (callBackFunction) { callBackFunction(); }
  }

  async DeleteUserJobUnit(userJobUnitGuidId:string, callBackFunction?: ()=> void){
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.delete<any | HttpReturnModel>({
      controller:"UserJobUnit",
      action:"Delete"
    }, userJobUnitGuidId, "UserJobUnitGuidId");
    const myUserJobUnits: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    if(myUserJobUnits) {
      const message: string = (myUserJobUnits.message != undefined ? myUserJobUnits.message : "Kullanıcı Yetkileri başarıyla silindi.")

      this.toastrService.message(message, "Silindi.", {
        messageType: ToastrMessageType.Success,
        position: ToastrPosition.TopRight
      });
    }
    //@ts-ignore
    if (callBackFunction) { callBackFunction(); }
  }

  async AddUserJobUnit(userJobUnit:UserJobUnit, callBackFunction?: () => Promise<void>){
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.post<any | HttpReturnModel>({
      controller:"UserJobUnit",
      action:"Add"
    }, userJobUnit);
    const myUserJobUnits: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    if(myUserJobUnits) {
      const message: string = (myUserJobUnits.message != undefined ? myUserJobUnits.message : "Kullanıcı Yetkileri başarıyla eklendi.")

      this.toastrService.message(message, "Eklendi", {
        messageType: ToastrMessageType.Success,
        position: ToastrPosition.TopRight
      });
    }
    if (callBackFunction) { await callBackFunction(); }
  }

  async BulkAddUserJobUnit(userJobUnits:UserJobUnit[], callBackFunction?: () => Promise<void>){
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.post<any | HttpReturnModel>({
      controller:"UserJobUnit",
      action:"BulkAddForUserJobUnit"
    }, userJobUnits);
    const myUserJobUnits: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    if(myUserJobUnits) {
      const message: string = (myUserJobUnits.message != undefined ? myUserJobUnits.message : "Başarıyla Eklendi.")

      this.toastrService.message(message, "Eklendi", {
        messageType: ToastrMessageType.Success,
        position: ToastrPosition.TopRight
      });
    }
    if (callBackFunction) { await callBackFunction(); }
  }

  async BulkDeleteUserJobUnit(userJobUnitGuidId: string, callBackFunction?: () => Promise<void>){
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.delete<any | HttpReturnModel>({
      controller:"UserJobUnit",
      action:"BulkDeleteForUserJobUnit"
    }, userJobUnitGuidId, "UserGuidId");
    const myUserJobUnits: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    if(myUserJobUnits) {
      const message: string = (myUserJobUnits.message != undefined ? myUserJobUnits.message : "Başarıyla Silindi.")

      this.toastrService.message(message, "Silindi.", {
        messageType: ToastrMessageType.Success,
        position: ToastrPosition.TopRight
      });
    }
    if (callBackFunction) { await callBackFunction(); }
  }
}
