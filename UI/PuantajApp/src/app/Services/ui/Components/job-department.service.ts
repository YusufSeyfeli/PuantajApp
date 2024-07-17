import { Injectable } from '@angular/core';
import {HttpClientService} from "../../http-client.service";
import {CustomToastrService, ToastrMessageType, ToastrPosition} from "../custom-toastr.service";
import {firstValueFrom, Observable} from "rxjs";
import {HttpReturnModel} from "../../../Models/httpReturnModel";
import {Holiday} from "../../../Models/Holiday";
import {JobDepartment} from "../../../Models/JobDepartment";

@Injectable({
  providedIn: 'root'
})
export class JobDepartmentService {

  constructor(private httpclient: HttpClientService,
              private toastrService: CustomToastrService) { }

  async getAllJobDepartment(callBackFunction?: ()=> void) {
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.get<any | HttpReturnModel>({
      controller:"JobDepartment",
      action: "GetList"
    });
    const myJobDepartments: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    if (callBackFunction) { callBackFunction(); }
    return myJobDepartments.data;
  }

  async getJobDepartmentById(jobDepartmentGuidId:string, callBackFunction?: ()=> void){
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.get<any | HttpReturnModel>({
      controller:"JobDepartment",
      action:"GetById"
    }, jobDepartmentGuidId, "jobDepartmentGuidId");
    const myJobDepartment: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    return myJobDepartment.data;
    //@ts-ignore
    if (callBackFunction) { callBackFunction(); }
  }

  async UpdateJobDepartment(jobDepartment:JobDepartment, callBackFunction?: ()=> void){
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.put<any | HttpReturnModel>({
      controller:"JobDepartment",
      action:"Update"
    },jobDepartment);
    const myJobDepartment: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    if(myJobDepartment){
      const message: string = (myJobDepartment.message!= undefined ? myJobDepartment.message: "Departman bilgileri başarıyla düzenlendi.")
      this.toastrService.message(message, "Düzenlendi.", {
        messageType: ToastrMessageType.Success,
        position: ToastrPosition.TopRight
      });
    }
    //@ts-ignore
    if (callBackFunction) { callBackFunction(); }
  }

  async DeleteJobDepartment(jobDepartmentGuidId:string, callBackFunction?: ()=> void){
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.delete<any | HttpReturnModel>({
      controller:"JobDepartment",
      action:"Delete"
    }, jobDepartmentGuidId, "jobDepartmentGuidId");
    const myJobDepartment: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    if(myJobDepartment) {
      const message: string = (myJobDepartment.message != undefined ? myJobDepartment.message : "Departman bilgileri başarıyla silindi.")

      this.toastrService.message(message, "Silindi.", {
        messageType: ToastrMessageType.Success,
        position: ToastrPosition.TopRight
      });
    }
    //@ts-ignore
    if (callBackFunction) { callBackFunction(); }
  }

  async AddJobDepartment(jobDepartment:JobDepartment, callBackFunction?: ()=> void){
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.post<any | HttpReturnModel>({
      controller:"JobDepartment",
      action:"Add"
    }, jobDepartment);
    const myJobDepartment: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    if(myJobDepartment) {
      const message: string = (myJobDepartment.message != undefined ? myJobDepartment.message : "Departman bilgileri başarıyla eklendi.")

      this.toastrService.message(message, "Eklendi", {
        messageType: ToastrMessageType.Success,
        position: ToastrPosition.TopRight
      });
    }
    //@ts-ignore
    if (callBackFunction) { callBackFunction(); }
  }
}
