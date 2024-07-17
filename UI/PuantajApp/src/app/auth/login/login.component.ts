import { Component } from '@angular/core';
import {UserService} from "../../Services/ui/Components/user.service";
import {AuthService} from "../../Services/auth.service";
import {ActivatedRoute, Router} from "@angular/router";
import {NgxSpinnerService} from "ngx-spinner";

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styles: [`
        :host ::ng-deep .pi-eye,
        :host ::ng-deep .pi-eye-slash {
            transform:scale(1.6);
            margin-right: 1rem;
            color: var(--primary-color) !important;
        }
    `]
})
export class LoginComponent{
  constructor(private userService: UserService, private authService: AuthService,
              private activatedRoute: ActivatedRoute, private router: Router, private spinner: NgxSpinnerService) {}

  async Login(email: string, password: string) {
    this.spinner.show();
    await this.userService.login(email, password, () => {
      this.authService.identityCheck();
        this.activatedRoute.queryParams.subscribe(params=>{
          const returnUrl: string = params["returnUrl"]
          if (returnUrl) {
            this.router.navigate([returnUrl])
          } else {
            this.router.navigate(['/']);
          }
        })
      });
    this.spinner.hide();
  }
}
