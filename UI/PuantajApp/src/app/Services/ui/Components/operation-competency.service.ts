import { Injectable } from '@angular/core';
import {HttpClientService} from "../../http-client.service";
import {CustomToastrService, ToastrMessageType, ToastrPosition} from "../custom-toastr.service";
import {firstValueFrom, Observable} from "rxjs";
import {HttpReturnModel} from "../../../Models/httpReturnModel";
import {Competency} from "../../../Models/competency";
import {OperationCompetency} from "../../../Models/operation-competency";

@Injectable({
  providedIn: 'root'
})
export class OperationCompetencyService {

  constructor(private httpclient: HttpClientService, private toastrService: CustomToastrService) { }

  async getAllOperationCompetencies(callBackFunction?: ()=> void) {
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.get<any | HttpReturnModel>({
      controller:"OperationCompetency",
      action:"GetList"
    });
    const myOperationCompetency: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    if (callBackFunction) { callBackFunction(); }
    return myOperationCompetency.data;
  }

  async getOperationCompetencyById(id:string, callBackFunction?: ()=> void){
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.get<any | HttpReturnModel>({
      controller:"OperationCompetency",
      action:"GetById"
    }, id);
    const myOperationCompetency: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    return myOperationCompetency.data;
    //@ts-ignore
    if (callBackFunction) { callBackFunction(); }
  }

  async UpdateOperationCompetency(operationcompetency:OperationCompetency, callBackFunction?: ()=> void){
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.post<any | HttpReturnModel>({
      controller:"OperationCompetency",
      action:"Update"
    }, operationcompetency);
    const myOperationCompetency: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    if(myOperationCompetency){
      const message: string = (myOperationCompetency.message!= undefined ? myOperationCompetency.message: "Başarıyla Düzenlendi.")
      this.toastrService.message(message, "Düzenlendi.", {
        messageType: ToastrMessageType.Success,
        position: ToastrPosition.TopRight
      });
    }
    //@ts-ignore
    if (callBackFunction) { callBackFunction(); }
  }

  async DeleteOperationCompetency(id:string, callBackFunction?: ()=> void){
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.delete<any | HttpReturnModel>({
      controller:"OperationCompetency",
      action:"Delete"
    }, id);
    const myOperationCompetency: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    if(myOperationCompetency) {
      const message: string = (myOperationCompetency.message != undefined ? myOperationCompetency.message : "Başarıyla Silindi.")

      this.toastrService.message(message, "Silindi.", {
        messageType: ToastrMessageType.Success,
        position: ToastrPosition.TopRight
      });
    }
    //@ts-ignore
    if (callBackFunction) { callBackFunction(); }
  }

  async AddOperationCompetency(operationcompetency:OperationCompetency, callBackFunction?: ()=> void){
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.post<any | HttpReturnModel>({
      controller:"OperationCompetency",
      action:"Add"
    }, operationcompetency);
    const myOperationCompetency: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    if(myOperationCompetency) {
      const message: string = (myOperationCompetency.message != undefined ? myOperationCompetency.message : "Başarıyla Eklendi.")

      this.toastrService.message(message, "Eklendi", {
        messageType: ToastrMessageType.Success,
        position: ToastrPosition.TopRight
      });
    }
    //@ts-ignore
    if (callBackFunction) { callBackFunction(); }
  }
  async BulkAddOperationCompetency(operationcompetency:OperationCompetency[], callBackFunction?: ()=> void){
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.post<any | HttpReturnModel>({
      controller:"OperationCompetency",
      action:"BulkAddForOperationClaim"
    }, operationcompetency);
    const myOperationCompetency: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    if(myOperationCompetency) {
      const message: string = (myOperationCompetency.message != undefined ? myOperationCompetency.message : "Başarıyla Eklendi.")

      this.toastrService.message(message, "Eklendi", {
        messageType: ToastrMessageType.Success,
        position: ToastrPosition.TopRight
      });
    }
    //@ts-ignore
    if (callBackFunction) { callBackFunction(); }
  }

  async BulkDeleteOperationCompetency(operationClaimGuidId:string, callBackFunction?: ()=> void){
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.delete<any | HttpReturnModel>({
      controller:"OperationCompetency",
      action:"BulkDeleteForOperationClaim"
    }, operationClaimGuidId, "operationClaimGuidId");
    const myOperationCompetency: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    if(myOperationCompetency) {
      const message: string = (myOperationCompetency.message != undefined ? myOperationCompetency.message : "Başarıyla Silindi.")

      this.toastrService.message(message, "Silindi.", {
        messageType: ToastrMessageType.Success,
        position: ToastrPosition.TopRight
      });
    }
    //@ts-ignore
    if (callBackFunction) { callBackFunction(); }
  }
}
