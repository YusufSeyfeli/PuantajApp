import {Component, OnInit} from '@angular/core';
import {CustomToastrService, ToastrMessageType, ToastrPosition} from "../../Services/ui/custom-toastr.service";
import {HolidayService} from "../../Services/ui/Components/holiday.service";
import {Holiday} from "../../Models/Holiday";
import {Table} from "primeng/table";

@Component({
  selector: 'app-holidays',
  templateUrl: './holidays.component.html',
  styleUrls: ['./holidays.component.scss']
})
export class HolidaysComponent implements OnInit {
  holidayDialog: boolean = false;

  deleteholidayDialog: boolean = false;

  deleteAllholidayDialog: boolean = false;

  holidays: Holiday[]  = [];

  myholiday: Holiday = {};

  selectedHo: Holiday[] = [];

  submitted: boolean = false;

  cols: any[] = [];

  rowsPerPageOptions= [5, 10, 20];

  constructor(private toastrService: CustomToastrService,
              private holidayService: HolidayService) {
  }

  ngOnInit(){
    this.holidayService.getAllHoliday().then(data => this.holidays = data);
  }
  formatDate(myDate: Date) {
    const options: Intl.DateTimeFormatOptions = { year: 'numeric', month: 'long', day: 'numeric' };
    return new Date(myDate).toLocaleDateString('tr-TR', options);
  }
  openNew() {
    this.myholiday = {};
    this.submitted = false;
    this.holidayDialog = true;
  }

  deleteSelectedHolidays() {
    this.deleteAllholidayDialog = true;
  }

  async editHoliday(myHoliday: Holiday) {
    this.myholiday = { ...myHoliday };
    this.holidayDialog = true;
  }

  deleteHoliday(myHoliday: Holiday) {
    this.deleteholidayDialog = true;
    this.myholiday = { ...myHoliday };
  }

  hideDialog() {
    this.holidayDialog = false;
    this.submitted = false;
  }

  onGlobalFilter(table: Table, event: Event) {
    table.filterGlobal((event.target as HTMLInputElement).value, 'contains');
  }

  async saveHoliday() {
    if(this.myholiday.holidayFirstDate! < this.myholiday.holidayFinishDate!){
      this.submitted = true;
      if (this.myholiday.holidayName?.trim()) {

        if (this.myholiday.holidayGuidId) {
          await this.holidayService.UpdateHoliday(this.myholiday);
        } else {
          await this.holidayService.AddHoliday(this.myholiday);
        }

        await this.holidayService.getAllHoliday().then(data => this.holidays = data);
        // @ts-ignore
        this.holidays = [...this.holidays];
        this.holidayDialog = false;
        this.myholiday = {};
      }
    }else{
      this.toastrService.message("Bitiş tarihi başlangıç tarihinden önce olamaz!! ", "Tarih", {
        messageType: ToastrMessageType.Error,
        position: ToastrPosition.TopRight
      });
    }
  }

  confirmDeleteSelected() {
    this.deleteAllholidayDialog = false;
    if(this.selectedHo){
      for(const val of this.selectedHo){
        this.holidayService.DeleteHoliday(val.holidayGuidId!)
      }
      // @ts-ignore
      this.holidays = this.holidays.filter(val => !this.selectedHo.includes(val));
    }else{
      this.toastrService.message("Tatil silinemedi, Lütfen bir Tatil seçiniz!! ", "Silinemedi", {
        messageType: ToastrMessageType.Error,
        position: ToastrPosition.TopRight
      });
    }
    this.selectedHo = [];
  }

  confirmDelete() {
    this.deleteholidayDialog = false;
    if(this.myholiday.holidayGuidId){
      this.holidayService.DeleteHoliday(this.myholiday.holidayGuidId);
      this.holidays = this.holidays.filter(val => val.holidayGuidId !== this.myholiday.holidayGuidId);

    }else{
      this.toastrService.message("Tatil silinemedi, Lütfen bir Tatil seçiniz!! ", "Silinemedi", {
        messageType: ToastrMessageType.Error,
        position: ToastrPosition.TopRight
      });
    }
    this.myholiday = {};
  }
}
