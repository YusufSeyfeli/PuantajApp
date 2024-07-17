import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {JobUnit} from "../../Models/job-unit";
import {JobUnitService} from "../../Services/ui/Components/job-unit.service";
import {CustomToastrService, ToastrMessageType, ToastrPosition} from "../../Services/ui/custom-toastr.service";
import {Table} from "primeng/table";

@Component({
  selector: 'app-job-units',
  templateUrl: './job-units.component.html',
  styleUrls: ['./job-units.component.scss']
})
export class JobUnitsComponent implements OnInit{

  JobUnitDialog: boolean = false;

  deleteJobUnitDialog: boolean = false;

  deleteAllJobUnitDialog: boolean = false;

  JobUnits: JobUnit[]  = [];

  JobDepartmentId: any;

  myJobUnit: JobUnit = {};

  selectedJu: JobUnit[] = [];

  submitted: boolean = false;

  cols: any[] = [];

  rowsPerPageOptions= [5, 10, 20];

  regex = /^(?=.*[A-Z])(?=.*[.!@#$%^&*])(?=.*[0-9]).{8,}$/;
  constructor(private toastrService: CustomToastrService,
              private route: ActivatedRoute,
              private jobUnitService: JobUnitService) {
    this.route.params.subscribe(params => {
      this.JobDepartmentId = params['id'];
    });
  }
  ngOnInit(){
    if(this.JobDepartmentId){
      this.jobUnitService.getAllJobUnit().then(data => {
        const filteredJobUnits: JobUnit[] = data.filter((res: JobUnit) => res.jobDepartmentGuidId === this.JobDepartmentId);
        if (filteredJobUnits.length != 0){
          this.JobUnits = filteredJobUnits;
        }else{
          this.toastrService.message("Departmana ait Bir kayıt bulunamadı, ekleyebilirsiniz!! ", "Bulunamadı!!", {
            messageType: ToastrMessageType.Info,
            position: ToastrPosition.TopRight
          });
        }
      });
    }else{
      this.toastrService.message("Lütfen Geçerli Bir Departman seçiniz!! ", "Yönlendirme Hatası!!", {
        messageType: ToastrMessageType.Error,
        position: ToastrPosition.TopRight
      });
    }
  }
  openNew() {
    this.myJobUnit = {};
    this.submitted = false;
    this.JobUnitDialog = true;
  }

  deleteSelectedJobUnits() {
    this.deleteAllJobUnitDialog = true;
  }

  async editJobUnit(myJobUnit: JobUnit) {
    this.myJobUnit = { ...myJobUnit };
    this.JobUnitDialog = true;
  }

  deleteJobUnit(myJobUnit: JobUnit) {
    this.deleteJobUnitDialog = true;
    this.myJobUnit = { ...myJobUnit };
  }

  hideDialog() {
    this.JobUnitDialog = false;
    this.submitted = false;
  }

  onGlobalFilter(table: Table, event: Event) {
    table.filterGlobal((event.target as HTMLInputElement).value, 'contains');
  }

  async saveJobUnit() {
    this.submitted = true;
    if (this.myJobUnit.jobUnitName?.trim()) {

      if (this.myJobUnit.jobUnitGuidId) {
        this.myJobUnit.jobDepartmentGuidId = this.JobDepartmentId;
        await this.jobUnitService.UpdateJobUnit(this.myJobUnit);
      } else {
        this.myJobUnit.jobDepartmentGuidId = this.JobDepartmentId;
        await this.jobUnitService.AddJobUnit(this.myJobUnit);
      }
      await this.jobUnitService.getAllJobUnit().then(data => {
        this.JobUnits = data.filter((res: JobUnit) => res.jobDepartmentGuidId === this.JobDepartmentId);
      });
      // @ts-ignore
      this.JobUnits = [...this.JobUnits];
      this.JobUnitDialog = false;
      this.myJobUnit = {};
    }
  }

  async confirmDeleteSelected() {
    this.deleteAllJobUnitDialog = false;
    if(this.selectedJu){
      for(const val of this.selectedJu){
        this.jobUnitService.DeleteJobUnit(val.jobUnitGuidId!)
      }
      this.JobUnits = this.JobUnits.filter(val => !this.selectedJu.includes(val));
    }else{
      this.toastrService.message("Birim silinemedi, Lütfen bir Birim seçiniz!! ", "Silinemedi", {
        messageType: ToastrMessageType.Error,
        position: ToastrPosition.TopRight
      });
    }
    await this.jobUnitService.getAllJobUnit().then(data => {
      this.JobUnits = data.filter((res: JobUnit) => res.jobDepartmentGuidId === this.JobDepartmentId);
    });
    this.JobUnits = [...this.JobUnits];
    this.selectedJu = [];
  }

  async confirmDelete() {
    this.deleteJobUnitDialog = false;
    if(this.myJobUnit.jobUnitGuidId){
      this.jobUnitService.DeleteJobUnit(this.myJobUnit.jobUnitGuidId);

      this.JobUnits = this.JobUnits.filter(val => val.jobUnitGuidId !== this.myJobUnit.jobUnitGuidId);

    }else{
      this.toastrService.message("Birim silinemedi, Lütfen bir Birim seçiniz!! ", "Silinemedi", {
        messageType: ToastrMessageType.Error,
        position: ToastrPosition.TopRight
      });
    }
    this.myJobUnit = {};
  }
}
