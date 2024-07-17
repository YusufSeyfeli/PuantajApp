import { Component, ElementRef, ViewChild } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { LayoutService } from "./service/app.layout.service";
import {AuthService} from "../Services/auth.service";
import {CustomToastrService, ToastrMessageType, ToastrPosition} from "../Services/ui/custom-toastr.service";

@Component({
    selector: 'app-topbar',
    templateUrl: './app.topbar.component.html'
})
export class AppTopBarComponent {

    items!: MenuItem[];

    @ViewChild('menubutton') menuButton!: ElementRef;

    @ViewChild('topbarmenubutton') topbarMenuButton!: ElementRef;

    @ViewChild('topbarmenu') menu!: ElementRef;

    constructor(public layoutService: LayoutService, private authService: AuthService, private toastrService: CustomToastrService) { }
  signOut(){
    localStorage.removeItem("accessToken");
    localStorage.removeItem("expiration");
    localStorage.removeItem("refreshToken");
    localStorage.removeItem("userGuidId");
    localStorage.removeItem("myclaim");
    this.authService.identityCheck();
    this.toastrService.message("Başarıyla Çıkış Yapıldı.", "Çıkış", {
      messageType: ToastrMessageType.Warning,
      position: ToastrPosition.TopRight
    });
  }
}
