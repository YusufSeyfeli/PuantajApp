import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { LayoutService } from './service/app.layout.service';
import {MenuItem} from "primeng/api";

@Component({
    selector: 'app-menu',
    templateUrl: './app.menu.component.html'
})
export class AppMenuComponent implements OnInit {

    model: any[] = [];
    myitems: any[] = [];

    constructor(public layoutService: LayoutService) { }

    ngOnInit() {
      if(localStorage.getItem("myclaim") != "false"){
        this.myitems = [{
          label: 'Kullanıcılar',
          items: [
            { label: 'Profilim', icon: 'pi pi-fw pi-user', routerLink: ['/comp/UserInfo'] },
            { label: 'Öğrenciler', icon: 'pi pi-fw pi-user', routerLink: ['/comp/students'] },
            { label: 'Tatiller', icon: 'pi pi-fw pi-calendar', routerLink: ['/comp/holiday'] },
            { label: 'Genel Ayarlar', icon: 'pi pi-fw pi-wrench', routerLink: ['/comp/settings'] },
          ]
        },
          {
            label: 'Admin',
            items: [
              { label: 'Kullanıcılar', icon: 'pi pi-fw pi-user', routerLink: ['/comp/alluser'] },
              { label: 'Yetkiler', icon: 'pi pi-fw pi-list', routerLink: ['/comp/operation'] },
              { label: 'Departmanlar', icon: 'pi pi-fw pi-building', routerLink: ['/comp/department'] },
            ]
          }];
      }else{
        this.myitems = [{
          label: 'Kullanıcılar',
          items: [
            { label: 'Profilim', icon: 'pi pi-fw pi-user', routerLink: ['/comp/UserInfo'] },
            { label: 'Öğrenciler', icon: 'pi pi-fw pi-user', routerLink: ['/comp/students'] },
            { label: 'Tatiller', icon: 'pi pi-fw pi-calendar', routerLink: ['/comp/holiday'] },
            { label: 'Genel Ayarlar', icon: 'pi pi-fw pi-wrench', routerLink: ['/comp/settings'] },
          ]
        }];
      }
    }
}
