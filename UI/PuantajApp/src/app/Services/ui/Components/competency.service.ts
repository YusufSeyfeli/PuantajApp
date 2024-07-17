import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {OperationClaim} from "../../../Models/operation-claim";
import {Competency} from "../../../Models/competency";
import {firstValueFrom, Observable} from "rxjs";
import {HttpReturnModel} from "../../../Models/httpReturnModel";
import {User} from "../../../Models/user";
import {CustomToastrService, ToastrMessageType, ToastrPosition} from "../custom-toastr.service";
import {HttpClientService} from "../../http-client.service";

@Injectable({
  providedIn: 'root'
})
export class CompetencyService {

  constructor(private httpclient: HttpClientService, private toastrService: CustomToastrService) { }

  async getAllCompetencies(callBackFunction?: ()=> void) {
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.get<any | HttpReturnModel>({
      controller:"Competency",
      action:"GetList"
    });
    const myCompetency: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    if (callBackFunction) { callBackFunction(); }
    return myCompetency.data;
  }

  async getCompetencyById(id:string, callBackFunction?: ()=> void){
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.get<any | HttpReturnModel>({
      controller:"Competency",
      action:"GetById"
    }, id);
    const myCompetency: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    if (callBackFunction) { callBackFunction(); }
    return myCompetency.data;
  }

  async getCompetencyByOperationClaimId(OperationClaimGuidId:string, callBackFunction?: ()=> void){
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.get<any | HttpReturnModel>({
      controller:"Competency",
      action:"GetCompetenciesbyOperationClaimId"
    }, OperationClaimGuidId, "OperationClaimGuidId");
    const myCompetency: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    if (callBackFunction) { callBackFunction(); }
    return myCompetency.data;
  }
}
