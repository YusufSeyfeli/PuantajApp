import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {OperationClaim} from "../../../Models/operation-claim";
import {HttpClientService} from "../../http-client.service";
import {CustomToastrService, ToastrMessageType, ToastrPosition} from "../custom-toastr.service";
import {NgxSpinnerService} from "ngx-spinner";
import {Router} from "@angular/router";
import {firstValueFrom, Observable} from "rxjs";
import {TokenResponse} from "../../../Models/Token/tokenResponse";
import {HttpReturnModel} from "../../../Models/httpReturnModel";

@Injectable({
  providedIn: 'root'
})
export class OperationclaimService {

  constructor(private httpclient: HttpClientService,
              private toastrService: CustomToastrService) { }

  async getAllOperationClaimWithCompetency(callBackFunction?: ()=> void) {
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.get<any | HttpReturnModel>({
      controller:"OperationClaim",
      action: "GetListWithCompetency"
    });
    const operationclaim: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    if (callBackFunction) { callBackFunction(); }
    return operationclaim.data;
  }
  async getAllOperationClaim(callBackFunction?: ()=> void) {
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.get<any | HttpReturnModel>({
      controller:"OperationClaim",
      action: "GetList"
    });
    const operationclaim: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    if (callBackFunction) { callBackFunction(); }
    return operationclaim.data;
  }


  async getOperationClaimById(id:string, callBackFunction?: ()=> void){
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.get<any | HttpReturnModel>({
      controller:"OperationClaim",
      action:"GetById"
    }, id);
    const operationclaim: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    return operationclaim.data;
    //@ts-ignore
    if (callBackFunction) { callBackFunction(); }
  }

  async UpdateOperationClaim(operationClaim:OperationClaim, callBackFunction?: ()=> void){
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.put<any | HttpReturnModel>({
      controller:"OperationClaim",
      action:"Update"
    },operationClaim);
    const operationclaim: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    if(operationclaim){
      const message: string = (operationclaim.message!= undefined ? operationclaim.message: "Başarıyla Düzenlendi.")
      this.toastrService.message(message, "Düzenlendi.", {
        messageType: ToastrMessageType.Success,
        position: ToastrPosition.TopRight
      });
    }
    //@ts-ignore
    if (callBackFunction) { callBackFunction(); }
  }

  async DeleteOperationClaim(operationClaimGuidId:string, callBackFunction?: ()=> void){
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.delete<any | HttpReturnModel>({
      controller:"OperationClaim",
      action:"Delete"
    }, operationClaimGuidId, "operationClaimGuidId");
    const operationclaim: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    if(operationclaim) {
      const message: string = (operationclaim.message != undefined ? operationclaim.message : "Başarıyla Silindi.")

      this.toastrService.message(message, "Silindi.", {
        messageType: ToastrMessageType.Success,
        position: ToastrPosition.TopRight
      });
    }
    //@ts-ignore
    if (callBackFunction) { callBackFunction(); }
  }

  async AddOperationClaim(operationClaim:OperationClaim, callBackFunction?: ()=> void){
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.post<any | HttpReturnModel>({
      controller:"OperationClaim",
      action:"Add"
    }, operationClaim);
    const operationclaim: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    if(operationclaim) {
      const message: string = (operationclaim.message != undefined ? operationclaim.message : "Başarıyla Eklendi.")

      this.toastrService.message(message, "Eklendi", {
        messageType: ToastrMessageType.Success,
        position: ToastrPosition.TopRight
      });
    }
    //@ts-ignore
    if (callBackFunction) { callBackFunction(); }
  }


}
