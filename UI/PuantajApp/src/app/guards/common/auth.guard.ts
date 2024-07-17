import {CanActivateFn, Router} from '@angular/router';
import {inject} from "@angular/core";
import { CustomToastrService, ToastrMessageType, ToastrPosition } from '../../Services/ui/custom-toastr.service';
import {_isAuthenticated} from "../../Services/auth.service";

export const authGuard: CanActivateFn = (route, state) => {
  const router: Router = inject(Router);
  const toastrService: CustomToastrService = inject(CustomToastrService);

  if(!_isAuthenticated){
    router.navigate(["auth/login"], { queryParams: { returnUrl: state.url } });
    toastrService.message("Lütfen Önce Giriş Yapınız", "Yetkisiz Erişim!", {
      messageType: ToastrMessageType.Error,
      position: ToastrPosition.TopRight
    });

  }
  return true;
};
