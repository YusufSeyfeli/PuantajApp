import { Injectable } from '@angular/core';
import {HttpClientService} from "../../http-client.service";
import {CustomToastrService, ToastrMessageType, ToastrPosition} from "../custom-toastr.service";
import {firstValueFrom, Observable} from "rxjs";
import {HttpReturnModel} from "../../../Models/httpReturnModel";
import {Holiday} from "../../../Models/Holiday";

@Injectable({
  providedIn: 'root'
})
export class HolidayService {

  constructor(private httpclient: HttpClientService,
              private toastrService: CustomToastrService) { }

  async getAllHoliday(callBackFunction?: ()=> void) {
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.get<any | HttpReturnModel>({
      controller:"Holiday",
      action: "GetList"
    });
    const myHolidays: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    if (callBackFunction) { callBackFunction(); }
    return myHolidays.data;
  }

  async getHolidayById(HolidayGuidId:string, callBackFunction?: ()=> void){
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.get<any | HttpReturnModel>({
      controller:"Holiday",
      action:"GetById"
    }, HolidayGuidId, "HolidayGuidId");
    const myHoliday: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    return myHoliday.data;
    //@ts-ignore
    if (callBackFunction) { callBackFunction(); }
  }

  async UpdateHoliday(holiday:Holiday, callBackFunction?: ()=> void){
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.put<any | HttpReturnModel>({
      controller:"Holiday",
      action:"Update"
    },holiday);
    const myStudent: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    if(myStudent){
      const message: string = (myStudent.message!= undefined ? myStudent.message: "Tatil bilgileri başarıyla düzenlendi.")
      this.toastrService.message(message, "Düzenlendi.", {
        messageType: ToastrMessageType.Success,
        position: ToastrPosition.TopRight
      });
    }
    //@ts-ignore
    if (callBackFunction) { callBackFunction(); }
  }

  async DeleteHoliday(HolidayGuidId:string, callBackFunction?: ()=> void){
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.delete<any | HttpReturnModel>({
      controller:"Holiday",
      action:"Delete"
    }, HolidayGuidId, "HolidayGuidId");
    const myHoliday: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    if(myHoliday) {
      const message: string = (myHoliday.message != undefined ? myHoliday.message : "Tatil bilgileri başarıyla silindi.")

      this.toastrService.message(message, "Silindi.", {
        messageType: ToastrMessageType.Success,
        position: ToastrPosition.TopRight
      });
    }
    //@ts-ignore
    if (callBackFunction) { callBackFunction(); }
  }

  async AddHoliday(holiday:Holiday, callBackFunction?: ()=> void){
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.post<any | HttpReturnModel>({
      controller:"Holiday",
      action:"Add"
    }, holiday);
    const myHoliday: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    if(myHoliday) {
      const message: string = (myHoliday.message != undefined ? myHoliday.message : "Tatil bilgileri başarıyla eklendi.")

      this.toastrService.message(message, "Eklendi", {
        messageType: ToastrMessageType.Success,
        position: ToastrPosition.TopRight
      });
    }
    //@ts-ignore
    if (callBackFunction) { callBackFunction(); }
  }
}
