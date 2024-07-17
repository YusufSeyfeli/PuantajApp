import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AppLayoutModule} from "./layout/app.layout.module";
import {ComponentsModule} from './Components/components.module';
import {HTTP_INTERCEPTORS, HttpClientModule} from "@angular/common/http";
import {JwtModule} from "@auth0/angular-jwt";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from "ngx-spinner";
import {HttpErrorHandlerInterceptorService} from "./Services/http-error-handler-interceptor.service";
import {DocreateModule} from "./docreate/docreate.module";

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    NgxSpinnerModule.forRoot({ type: 'square-jelly-box' }),
    AppRoutingModule,
    AppLayoutModule,
    ComponentsModule,
    DocreateModule,
    HttpClientModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: () => localStorage.getItem("accessToken"),
        allowedDomains: ["localhost:44348"]
      }
    })
  ],
  providers: [
    {provide: "baseUrl", useValue:"https://localhost:44348/api",multi:true},
    {provide:HTTP_INTERCEPTORS, useClass: HttpErrorHandlerInterceptorService, multi:true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
