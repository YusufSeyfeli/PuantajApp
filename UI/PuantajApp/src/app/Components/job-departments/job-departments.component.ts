import {Component, OnInit} from '@angular/core';
import { Router } from '@angular/router';
import {CustomToastrService, ToastrMessageType, ToastrPosition} from "../../Services/ui/custom-toastr.service";
import {JobDepartmentService} from "../../Services/ui/Components/job-department.service";
import {Table} from "primeng/table";
import {JobDepartment} from "../../Models/JobDepartment";

@Component({
  selector: 'app-job-departments',
  templateUrl: './job-departments.component.html',
  styleUrls: ['./job-departments.component.scss']
})
export class JobDepartmentsComponent implements OnInit {
  JobDepartmentDialog: boolean = false;

  deleteJobDepartmentDialog: boolean = false;

  deleteAllJobDepartmentDialog: boolean = false;

  JobDepartments: JobDepartment[]  = [];

  myJobDepartment: JobDepartment = {};

  selectedJd: JobDepartment[] = [];

  submitted: boolean = false;

  cols: any[] = [];

  rowsPerPageOptions= [5, 10, 20];
  constructor(private toastrService: CustomToastrService,
              private jobDepartmentService: JobDepartmentService,
              private router: Router) {
  }
  ngOnInit(){
    this.jobDepartmentService.getAllJobDepartment().then(data => this.JobDepartments = data);
  }

  openNew() {
    this.myJobDepartment = {};
    this.submitted = false;
    this.JobDepartmentDialog = true;
  }

  deleteSelectedJobDepartments() {
    this.deleteAllJobDepartmentDialog = true;
  }

  async editJobDepartment(myJobDepartment: JobDepartment) {
    this.myJobDepartment = { ...myJobDepartment };
    this.JobDepartmentDialog = true;
  }

  deleteJobDepartment(myJobDepartment: JobDepartment) {
    this.deleteJobDepartmentDialog = true;
    this.myJobDepartment = { ...myJobDepartment };
  }

  hideDialog() {
    this.JobDepartmentDialog = false;
    this.submitted = false;
  }

  onGlobalFilter(table: Table, event: Event) {
    table.filterGlobal((event.target as HTMLInputElement).value, 'contains');
  }

  async saveJobDepartment() {
      this.submitted = true;
      if (this.myJobDepartment.name?.trim()) {

        if (this.myJobDepartment.jobDepartmentGuidId) {
          await this.jobDepartmentService.UpdateJobDepartment(this.myJobDepartment);
        } else {
          await this.jobDepartmentService.AddJobDepartment(this.myJobDepartment);
        }

        await this.jobDepartmentService.getAllJobDepartment().then(data => this.JobDepartments = data);
        // @ts-ignore
        this.JobDepartments = [...this.JobDepartments];
        this.JobDepartmentDialog = false;
        this.myJobDepartment = {};
      }
    this.JobDepartmentDialog = false;
  }

  confirmDeleteSelected() {
    this.deleteAllJobDepartmentDialog = false;
    if(this.selectedJd){
      for(const val of this.selectedJd){
        this.jobDepartmentService.DeleteJobDepartment(val.jobDepartmentGuidId!)
      }
      this.JobDepartments = this.JobDepartments.filter(val => !this.selectedJd.includes(val));
    }else{
      this.toastrService.message("Departman silinemedi, Lütfen bir Departman seçiniz!! ", "Silinemedi", {
        messageType: ToastrMessageType.Error,
        position: ToastrPosition.TopRight
      });
    }
    this.selectedJd = [];
  }

  confirmDelete() {
    this.deleteJobDepartmentDialog = false;
    if(this.myJobDepartment.jobDepartmentGuidId){
      this.jobDepartmentService.DeleteJobDepartment(this.myJobDepartment.jobDepartmentGuidId);
      this.JobDepartments = this.JobDepartments.filter(val => val.jobDepartmentGuidId !== this.myJobDepartment.jobDepartmentGuidId);

    }else{
      this.toastrService.message("Tatil silinemedi, Lütfen bir Tatil seçiniz!! ", "Silinemedi", {
        messageType: ToastrMessageType.Error,
        position: ToastrPosition.TopRight
      });
    }
    this.myJobDepartment = {};
  }

  navigateToDetail(jobDepartmentGuidId: string) {
    this.router.navigate(['/comp/department/unit', jobDepartmentGuidId]);
  }
}
