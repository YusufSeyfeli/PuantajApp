import {Injectable} from '@angular/core';
import {HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpStatusCode} from "@angular/common/http";
import {catchError, Observable, of} from "rxjs";
import {CustomToastrService, ToastrMessageType, ToastrPosition} from "./ui/custom-toastr.service";
import {NgxSpinnerService} from "ngx-spinner";
import {er} from "@fullcalendar/core/internal-common";

@Injectable({
  providedIn: 'root'
})
export class HttpErrorHandlerInterceptorService implements HttpInterceptor{

  constructor(private toasterService : CustomToastrService,
              private spinner: NgxSpinnerService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(catchError(error => {

      switch (error.status){
        case HttpStatusCode.Unauthorized:
          const message1: string = (error.error.Message!= undefined ? error.error.Message: "Bu işlemi yapmak için yetkiniz bulunmamaktadır!!")
          this.toasterService.message(message1,
            "Yetkisiz İşlem!",{
            messageType: ToastrMessageType.Warning,
              position: ToastrPosition.BottomFullWidth
            })
          this.spinner.hide();
          break;
        case HttpStatusCode.InternalServerError:
          const message: string = (error.error.Message!= undefined ? error.error.Message: "Sunucuya Erişilemiyor!!")
          console.log(error)
          this.toasterService.message(message,
            "Sunucu Hatası!",{
              messageType: ToastrMessageType.Warning,
              position: ToastrPosition.BottomFullWidth
            })
          this.spinner.hide();
          break;
        case HttpStatusCode.BadRequest:
          const message2: string = (error.error.Message!= undefined ? error.error.Message: "Geçersiz İstek Yapıldı!!")
          console.log(error)
          this.toasterService.message(message2,
            "Geçersiz İstek!",{
              messageType: ToastrMessageType.Warning,
              position: ToastrPosition.BottomFullWidth
            })
          this.spinner.hide();

          break;
        case HttpStatusCode.NotFound:
          const message3: string = (error.error.Message!= undefined ? error.error.Message: "Sayfa Bulunamadı!!")
          this.toasterService.message(message3,
            "Sayfa Bulunamadı!",{
              messageType: ToastrMessageType.Warning,
              position: ToastrPosition.BottomFullWidth
            })
          this.spinner.hide();
          break;
        default:
          const message4: string = (error.error.Message!= undefined ? error.error.Message: "Beklenmeyen bir hata meydana gelmiştir!!")
          this.toasterService.message(message4,
            "Hata!",{
              messageType: ToastrMessageType.Warning,
              position: ToastrPosition.BottomFullWidth
            })
          this.spinner.hide();
          break;

      }
      this.spinner.hide();
      return of(error);
    }));
  }

}
