import { Injectable } from '@angular/core';
import {HttpClientService} from "../../http-client.service";
import {CustomToastrService, ToastrMessageType, ToastrPosition} from "../custom-toastr.service";
import {firstValueFrom, Observable} from "rxjs";
import {HttpReturnModel} from "../../../Models/httpReturnModel";
import {Tally} from "../../../Models/Tally";
import {Settings} from "../../../Models/Settings";

@Injectable({
  providedIn: 'root'
})
export class GeneralSettingsService {

  constructor(private httpclient: HttpClientService,
              private toastrService: CustomToastrService) { }

  async getAllSettings(callBackFunction?: ()=> void) {
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.get<any | HttpReturnModel>({
      controller:"Settings",
      action: "GetList"
    });
    const mySettings: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    if (callBackFunction) { callBackFunction(); }
    return mySettings.data;
  }

  async UpdateSettings(settings:Settings, callBackFunction?: ()=> void){
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.put<any | HttpReturnModel>({
      controller:"Settings",
      action:"Update"
    },settings);
    const mySettings: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    if(mySettings){
      const message: string = (mySettings.message!= undefined ? mySettings.message: "Genel Ayarlar başarıyla düzenlendi.")
      this.toastrService.message(message, "Düzenlendi.", {
        messageType: ToastrMessageType.Success,
        position: ToastrPosition.TopRight
      });
    }
    //@ts-ignore
    if (callBackFunction) { callBackFunction(); }
  }
}
