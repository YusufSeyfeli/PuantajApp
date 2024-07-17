import { Injectable } from '@angular/core';
import {HttpClientService} from "../../http-client.service";
import {CustomToastrService} from "../custom-toastr.service";
import {firstValueFrom, Observable} from "rxjs";
import {HttpReturnModel} from "../../../Models/httpReturnModel";

@Injectable({
  providedIn: 'root'
})
export class SyllabusService {

  constructor(private httpclient: HttpClientService,
              private toastrService: CustomToastrService) { }

  async Refresh(StudentGuidId:string, callBackFunction?: ()=> void){
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.get<any | HttpReturnModel>({
      controller:"Syllabus",
      action:"Refresh"
    }, StudentGuidId, "StudentGuidId");
    const myStudent: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    if (callBackFunction) { callBackFunction(); }
    return myStudent.data;
  }
}
