import { Injectable } from '@angular/core';
import {HttpClientService} from "../../http-client.service";
import {CustomToastrService, ToastrMessageType, ToastrPosition} from "../custom-toastr.service";
import {firstValueFrom, Observable} from "rxjs";
import {HttpReturnModel} from "../../../Models/httpReturnModel";
import {JobUnit} from "../../../Models/job-unit";
import {Tally} from "../../../Models/Tally";
import {TallyFace} from "../../../Models/TallyFace";

@Injectable({
  providedIn: 'root'
})
export class TallyService {

  constructor(private httpclient: HttpClientService,
              private toastrService: CustomToastrService) { }
  async getAllTally(callBackFunction?: ()=> void) {
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.get<any | HttpReturnModel>({
      controller:"Tally",
      action: "GetList"
    });
    const myTally: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    if (callBackFunction) { callBackFunction(); }
    return myTally.data;
  }

  async getTallyById(TallyGuidId:string, callBackFunction?: ()=> void){
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.get<any | HttpReturnModel>({
      controller:"Tally",
      action:"GetById"
    }, TallyGuidId, "tallyGuidId");
    const myTally: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    return myTally.data;
    //@ts-ignore
    if (callBackFunction) { callBackFunction(); }
  }

  async UpdateTally(tally:TallyFace, callBackFunction?: ()=> void){
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.put<any | HttpReturnModel>({
      controller:"Tally",
      action:"Update"
    },tally);
    const myTally: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    if(myTally){
      const message: string = (myTally.message!= undefined ? myTally.message: "Puantaj bilgileri başarıyla düzenlendi.")
      this.toastrService.message(message, "Düzenlendi.", {
        messageType: ToastrMessageType.Success,
        position: ToastrPosition.TopRight
      });
    }
    //@ts-ignore
    if (callBackFunction) { callBackFunction(); }
  }

  async DeleteTally(TallyGuidId:string, callBackFunction?: ()=> void){
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.delete<any | HttpReturnModel>({
      controller:"Tally",
      action:"Delete"
    }, TallyGuidId, "tallyGuidId");
    const myTally: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    if(myTally) {
      const message: string = (myTally.message != undefined ? myTally.message : "Puantaj bilgileri başarıyla silindi.")

      this.toastrService.message(message, "Silindi.", {
        messageType: ToastrMessageType.Success,
        position: ToastrPosition.TopRight
      });
    }
    //@ts-ignore
    if (callBackFunction) { callBackFunction(); }
  }

  async AddTally(tally:TallyFace, callBackFunction?: ()=> void){
    debugger
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.post<any | HttpReturnModel>({
      controller:"Tally",
      action:"Add"
    }, tally);
    const myTally: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    if(myTally) {
      const message: string = (myTally.message != undefined ? myTally.message : "Puantaj bilgileri başarıyla eklendi.")

      this.toastrService.message(message, "Eklendi", {
        messageType: ToastrMessageType.Success,
        position: ToastrPosition.TopRight
      });
    }
    //@ts-ignore
    if (callBackFunction) { callBackFunction(); }
  }
}
