import {Inject, Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class HttpClientService {

  constructor(private http : HttpClient, @Inject("baseUrl") private baseUrl:string) { }

  private url(requestParameter: Partial<RequestParameters>){
    return `${requestParameter.baseUrl ? requestParameter.baseUrl: this.baseUrl}/${requestParameter.
      controller}${requestParameter.action? `/${requestParameter.action}` : "" }`
  }
  get<T>(requestParameter: Partial<RequestParameters>, id?: string, idName?:string) : Observable<T>{
    let url = "";
    if (requestParameter.fullEndPoint)
      url = requestParameter.fullEndPoint
    else
      url = `${this.url(requestParameter)}${id ? `/?${idName}=${id}`: "" }`;

    return this.http.get<T>(url,{headers: requestParameter.headers})
  }
  post<T>(requestParameter: Partial<RequestParameters>, body: Partial<T>){
    let url = "";
    if (requestParameter.fullEndPoint)
      url = requestParameter.fullEndPoint
    else
      url = `${this.url(requestParameter)}`;
    return this.http.post<T>(url, body,{headers: requestParameter.headers})
  }
  postFormData<T>(requestParameter: Partial<RequestParameters>, formData: FormData) {
    let url = "";
    if (requestParameter.fullEndPoint) {
      url = requestParameter.fullEndPoint;
    } else {
      url = `${this.baseUrl}/${requestParameter.controller}/${requestParameter.action}`;
    }

    return this.http.post<T>(url, formData, { headers: requestParameter.headers });
  }

  put<T>(requestParameter: Partial<RequestParameters>, body: Partial<T>){
    let url = "";
    if (requestParameter.fullEndPoint)
      url = requestParameter.fullEndPoint
    else
      url = `${this.url(requestParameter)}`;

    return this.http.put<T>(url, body,{headers: requestParameter.headers})
  }
  putFormData<T>(requestParameter: Partial<RequestParameters>, formData: FormData) {
    let url = "";
    if (requestParameter.fullEndPoint) {
      url = requestParameter.fullEndPoint;
    } else {
      url = `${this.baseUrl}/${requestParameter.controller}/${requestParameter.action}`;
    }

    return this.http.put<T>(url, formData, { headers: requestParameter.headers });
  }
  delete<T>(requestParameter: Partial<RequestParameters>, id?: string, idName?:string) : Observable<T>{
    let url = "";
    if (requestParameter.fullEndPoint)
      url = requestParameter.fullEndPoint
    else
      url = `${this.url(requestParameter)}${id ? `/?${idName}=${id}`: "" }`;

    return this.http.delete<T>(url,{headers: requestParameter.headers})
  }
}

export class RequestParameters{
  controller?:string;
  action?:string;

  headers?: HttpHeaders;
  baseUrl?:string;

  fullEndPoint?:string;
}
