import {Component, OnInit} from '@angular/core';
import {CustomToastrService, ToastrMessageType, ToastrPosition} from "../../Services/ui/custom-toastr.service";
import {ActivatedRoute} from "@angular/router";
import {TallyService} from "../../Services/ui/Components/tally.service";
import {Tally, TallyFace} from "../../Models/Tally";
import {Table} from "primeng/table";
import {SyllabusService} from "../../Services/ui/Components/syllabus.service";

@Component({
  selector: 'app-tally',
  templateUrl: './tally.component.html',
  styleUrls: ['./tally.component.scss']
})
export class TallyComponent implements OnInit {
  TallyDialog: boolean = false;

  deleteTallyDialog: boolean = false;

  deleteAllTallyDialog: boolean = false;

  Tallies: Tally[]  = [];

  myTally: Tally = {};
  myTallyFace: TallyFace = {};

  selectedT: Tally[] = [];

  submitted: boolean = false;

  cols: any[] = [];

  rowsPerPageOptions= [5, 10, 20];

  studentId:any;
  filterDate: Date | undefined;
  filterTally: Tally[]  = [];
  timeValue: string | undefined;
  MyMonths: any[] = [];
  filterMonth: string| undefined;
 constructor(private toastrService: CustomToastrService,
             private route: ActivatedRoute,
             private tallyService: TallyService,
             private syllabusService: SyllabusService) {
     this.route.params.subscribe(params => {
       this.studentId = params['id'];
     });
 }
  ngOnInit(){
    if(this.studentId){
      this.tallyService.getAllTally().then(data => {
        const filteredTallies: Tally[] = data.filter((res: Tally) => res.studentGuidId === this.studentId);
        if (filteredTallies.length != 0){
          this.Tallies = filteredTallies;
          this.filterTally = filteredTallies;
        }else{
          this.toastrService.message("Öğrenciye ait Bir kayıt bulunamadı, ekleyebilirsiniz!! ", "Bulunamadı!!", {
            messageType: ToastrMessageType.Info,
            position: ToastrPosition.TopRight
          });
        }
      });
    }else{
      this.toastrService.message("Lütfen Geçerli Bir Öğrenci seçiniz!! ", "Yönlendirme Hatası!!", {
        messageType: ToastrMessageType.Error,
        position: ToastrPosition.TopRight
      });
    }

    this.MyMonths = [
      { label: 'Ocak', value: 0 },
      { label: 'Şubat', value: 1 },
      { label: 'Mart', value: 2 },
      { label: 'Nisan', value: 3 },
      { label: 'Mayıs', value: 4 },
      { label: 'Haziran', value: 5 },
      { label: 'Temmuz', value: 6 },
      { label: 'Ağustos', value: 7 },
      { label: 'Eylül', value: 8 },
      { label: 'Ekim', value: 9 },
      { label: 'Kasım', value: 10 },
      { label: 'Aralık', value: 11 },
    ];
  }

  formatDate(myDate: Date) {
    const options: Intl.DateTimeFormatOptions = { year: 'numeric', month: 'long', day: 'numeric' };
    return new Date(myDate).toLocaleDateString('tr-TR', options);
  }
  formatHour(myDate: Date) {
    const options: Intl.DateTimeFormatOptions = { hour:"numeric", minute:"numeric" };
    return new Date(myDate).toLocaleDateString('tr-TR', options);
  }

  openNew() {
    this.myTally = {};
    this.submitted = false;
    this.TallyDialog = true;
    console.log(this.Tallies)
  }
  Refresh() {
   this.syllabusService.Refresh(this.studentId);
  }
  FilterDate(){
   this.filterTally = [];
    let myMonth = this.filterDate?.getMonth();
    let filMo = this.MyMonths.find(month => month.value === myMonth);
    this.filterMonth = filMo.label;
    for (let i = 0; i < (this.Tallies).length; i++) {
      const myTally = this.Tallies[i];
      let myDay = new Date(myTally.jobDate!);
      if (myDay.getMonth() === myMonth) {
        this.filterTally.push(myTally);
      }
    }
  }

  deleteSelectedTallies() {
    this.deleteAllTallyDialog = true;
  }

  async editTally(myTally: Tally) {
    this.myTally = { ...myTally };
    this.TallyDialog = true;
  }

  deleteTally(myTally: Tally) {
    this.deleteTallyDialog = true;
    this.myTally = { ...myTally };
  }

  hideDialog() {
    this.TallyDialog = false;
    this.submitted = false;
  }

  setdate(target?: Date, original?: Date): Date | undefined {
    if (target && original) {
      target.setFullYear(original.getFullYear());
      target.setMonth(original.getMonth());
      target.setDate(original.getDate());
      return target;
    }
    return undefined;
  }
  setSaveTally(){
    this.myTallyFace.studentGuidId = this.studentId;
    this.myTallyFace.tallyGuidId = this.myTally.tallyGuidId;
    this.myTallyFace.jobDate = this.myTally.jobDate!.toISOString();
    this.myTallyFace.FirstDateTally = this.myTally.FirstDateTally!.toISOString();
    this.myTallyFace.FinishDateTally = this.myTally.FinishDateTally!.toISOString();
  }
  async saveTally() {
    this.submitted = true;
    await new Promise<void>((resolve, reject) => {
      this.myTally.studentGuidId = this.studentId;
      this.myTally.FirstDateTally = this.setdate(this.myTally.FirstDateTally, this.myTally.jobDate);
      this.myTally.FinishDateTally = this.setdate(this.myTally.FinishDateTally, this.myTally.jobDate);
      this.setSaveTally();
      console.log(this.myTallyFace);
      debugger
      resolve();
    });

      if (this.myTally.tallyGuidId) {
        await this.tallyService.UpdateTally(this.myTallyFace);
      } else {
        await this.tallyService.AddTally(this.myTallyFace);
      }
      await this.tallyService.getAllTally().then(data => {
        this.Tallies = data.filter((res: Tally) => res.studentGuidId === this.studentId);
      });
      this.Tallies = [...this.Tallies];
      this.TallyDialog = false;
      this.myTally = {};

  }

  confirmDeleteSelected() {
    this.deleteAllTallyDialog = false;
    if(this.selectedT){
      for(const val of this.selectedT){
        this.tallyService.DeleteTally(val.tallyGuidId!)
      }
      this.Tallies = this.Tallies.filter(val => !this.selectedT.includes(val));
    }else{
      this.toastrService.message("Puantaj silinemedi, Lütfen bir Birim seçiniz!! ", "Silinemedi", {
        messageType: ToastrMessageType.Error,
        position: ToastrPosition.TopRight
      });
    }
    this.selectedT = [];
  }

  confirmDelete() {
    this.deleteTallyDialog = false;
    if(this.myTally.tallyGuidId){
      this.tallyService.DeleteTally(this.myTally.tallyGuidId);
      this.Tallies = this.Tallies.filter(val => val.tallyGuidId !== this.myTally.tallyGuidId);

    }else{
      this.toastrService.message("Puantaj silinemedi, Lütfen bir Puantaj seçiniz!! ", "Silinemedi", {
        messageType: ToastrMessageType.Error,
        position: ToastrPosition.TopRight
      });
    }
    this.myTally = {};
  }
  onGlobalFilter(table: Table, event: Event) {
    table.filterGlobal((event.target as HTMLInputElement).value, 'contains');
  }
}
