import { Injectable } from '@angular/core';
import {HttpClientService} from "../../http-client.service";
import {CustomToastrService, ToastrMessageType, ToastrPosition} from "../custom-toastr.service";
import {firstValueFrom, Observable} from "rxjs";
import {HttpReturnModel} from "../../../Models/httpReturnModel";
import {JobUnit} from "../../../Models/job-unit";

@Injectable({
  providedIn: 'root'
})
export class JobUnitService {

  constructor(private httpclient: HttpClientService,
              private toastrService: CustomToastrService) { }

  async getAllJobUnit(callBackFunction?: ()=> void) {
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.get<any | HttpReturnModel>({
      controller:"JobUnit",
      action: "GetList"
    });
    const myJobUnit: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    if (callBackFunction) { callBackFunction(); }
    return myJobUnit.data;
  }

  async getJobUnitById(JobUnitGuidId:string, callBackFunction?: ()=> void){
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.get<any | HttpReturnModel>({
      controller:"JobUnit",
      action:"GetById"
    }, JobUnitGuidId, "JobUnitGuidId");
    const myJobUnit: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    return myJobUnit.data;
    //@ts-ignore
    if (callBackFunction) { callBackFunction(); }
  }

  async UpdateJobUnit(jobUnit:JobUnit, callBackFunction?: ()=> void){
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.put<any | HttpReturnModel>({
      controller:"JobUnit",
      action:"Update"
    },jobUnit);
    const myJobUnit: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    if(myJobUnit){
      const message: string = (myJobUnit.message!= undefined ? myJobUnit.message: "Departman bilgileri başarıyla düzenlendi.")
      this.toastrService.message(message, "Düzenlendi.", {
        messageType: ToastrMessageType.Success,
        position: ToastrPosition.TopRight
      });
    }
    //@ts-ignore
    if (callBackFunction) { callBackFunction(); }
  }

  async DeleteJobUnit(JobUnitGuidId:string, callBackFunction?: ()=> void){
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.delete<any | HttpReturnModel>({
      controller:"JobUnit",
      action:"Delete"
    }, JobUnitGuidId, "JobUnitGuidId");
    const myJobUnit: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    if(myJobUnit) {
      const message: string = (myJobUnit.message != undefined ? myJobUnit.message : "Departman bilgileri başarıyla silindi.")

      this.toastrService.message(message, "Silindi.", {
        messageType: ToastrMessageType.Success,
        position: ToastrPosition.TopRight
      });
    }
    //@ts-ignore
    if (callBackFunction) { callBackFunction(); }
  }

  async AddJobUnit(jobUnit:JobUnit, callBackFunction?: ()=> void){
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.post<any | HttpReturnModel>({
      controller:"JobUnit",
      action:"Add"
    }, jobUnit);
    const myJobUnit: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    if(myJobUnit) {
      const message: string = (myJobUnit.message != undefined ? myJobUnit.message : "Departman bilgileri başarıyla eklendi.")

      this.toastrService.message(message, "Eklendi", {
        messageType: ToastrMessageType.Success,
        position: ToastrPosition.TopRight
      });
    }
    //@ts-ignore
    if (callBackFunction) { callBackFunction(); }
  }
}
