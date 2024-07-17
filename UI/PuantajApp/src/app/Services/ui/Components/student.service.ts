import { Injectable } from '@angular/core';
import {HttpClientService} from "../../http-client.service";
import {CustomToastrService, ToastrMessageType, ToastrPosition} from "../custom-toastr.service";
import {firstValueFrom, Observable} from "rxjs";
import {HttpReturnModel} from "../../../Models/httpReturnModel";
import {Student} from "../../../Models/student";

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  constructor(private httpclient: HttpClientService,
              private toastrService: CustomToastrService) { }

  async getAllStudent(callBackFunction?: ()=> void) {
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.get<any | HttpReturnModel>({
      controller:"Student",
      action: "GetList"
    });
    const myStudents: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    if (callBackFunction) { callBackFunction(); }
    return myStudents.data;
  }

  async getStudentById(StudentGuidId:string, callBackFunction?: ()=> void){
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.get<any | HttpReturnModel>({
      controller:"Student",
      action:"GetById"
    }, StudentGuidId, "StudentGuidId");
    const myStudent: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    return myStudent.data;
    //@ts-ignore
    if (callBackFunction) { callBackFunction(); }
  }

  async UpdateStudent(student:Student, callBackFunction?: ()=> void){
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.put<any | HttpReturnModel>({
      controller:"Student",
      action:"Update"
    },student);
    const myStudent: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    if(myStudent){
      const message: string = (myStudent.message!= undefined ? myStudent.message: "Öğrenci bilgileri başarıyla düzenlendi.")
      this.toastrService.message(message, "Düzenlendi.", {
        messageType: ToastrMessageType.Success,
        position: ToastrPosition.TopRight
      });
    }
    //@ts-ignore
    if (callBackFunction) { callBackFunction(); }
  }

  async DeleteStudent(StudentGuidId:string, callBackFunction?: ()=> void){
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.delete<any | HttpReturnModel>({
      controller:"Student",
      action:"Delete"
    }, StudentGuidId, "StudentGuidId");
    const myStudent: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    if(myStudent) {
      const message: string = (myStudent.message != undefined ? myStudent.message : "Öğrenci bilgileri başarıyla silindi.")

      this.toastrService.message(message, "Silindi.", {
        messageType: ToastrMessageType.Success,
        position: ToastrPosition.TopRight
      });
    }
    //@ts-ignore
    if (callBackFunction) { callBackFunction(); }
  }

  async AddStudent(student:Student, callBackFunction?: ()=> void){
    const observable: Observable<any | HttpReturnModel> =  this.httpclient.post<any | HttpReturnModel>({
      controller:"Student",
      action:"Add"
    }, student);
    const myStudent: HttpReturnModel = await firstValueFrom(observable) as HttpReturnModel;
    if(myStudent) {
      const message: string = (myStudent.message != undefined ? myStudent.message : "Öğrenci bilgileri başarıyla eklendi.")

      this.toastrService.message(message, "Eklendi", {
        messageType: ToastrMessageType.Success,
        position: ToastrPosition.TopRight
      });
    }
    //@ts-ignore
    if (callBackFunction) { callBackFunction(); }
  }
}
