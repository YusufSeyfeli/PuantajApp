import { Injectable } from '@angular/core';
import {JwtHelperService} from "@auth0/angular-jwt";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor( private jwtHelper:JwtHelperService ) { }

  identityCheck(){
    // @ts-ignore
    const token: string = localStorage.getItem("accessToken");
    // @ts-ignore
    const myId: string = localStorage.getItem("userGuidId");
    //const decodeToken = jwtHelper.decodeToken(token);
    //const expirationDate: Date  | null = jwtHelper.getTokenExpirationDate(token);
    let expired: boolean;
    try {
      expired = this.jwtHelper.isTokenExpired(token);

    }catch{
      expired = true
    }

    _isAuthenticated = token != null && !expired && myId != null;
  }
  get isAuthenticated() : boolean{
    return _isAuthenticated;
  }
}

export let _isAuthenticated: boolean;
