import {Component, OnInit} from '@angular/core';
import {CustomToastrService, ToastrMessageType, ToastrPosition} from "../../Services/ui/custom-toastr.service";
import {StudentService} from "../../Services/ui/Components/student.service";
import {JobUnitService} from "../../Services/ui/Components/job-unit.service";
import {Student} from "../../Models/student";
import {JobUnit} from "../../Models/job-unit";
import {Table} from "primeng/table";
import {DataView} from "primeng/dataview";
import {Router} from "@angular/router";
import {FileConverterService} from "../../Services/ui/file-converter.service";

@Component({
  selector: 'app-students-info',
  templateUrl: './students-info.component.html',
  styleUrls: ['./students-info.component.scss']
})
export class StudentsInfoComponent implements OnInit {
constructor(private studentService: StudentService,
            private jobUnitService: JobUnitService,
            private toastrService: CustomToastrService,
            private router: Router) {}


  studentClass: any[] = [];
  uploadedFiles: any;
  studentDialog: boolean = false;

  deleteStudentDialog: boolean = false;

  deleteallstudentDialog: boolean = false;

  allStudent: Student[] = [];

  student: Student = {};

  selectedStudents: Student[] = [];

  submitted: boolean = false;

  cols: any[] = [];

  allJobUnit: JobUnit[] = [];
  selectedJobUnit?: JobUnit;

  rowsPerPageOptions = [5, 10, 20];
  whatis?: string;
  ImageByteFile!: File;
  filteredJobUnit: JobUnit[] = [];

  ngOnInit(){
    this.studentService.getAllStudent().then(data => this.allStudent = data);
    this.jobUnitService.getAllJobUnit().then(data => this.allJobUnit = data);

    this.studentClass = [
      { label: 'Hazırlık', value: 0 },
      { label: '1. Sınıf', value: 1 },
      { label: '2. Sınıf', value: 2 },
      { label: '3. Sınıf', value: 3 },
      { label: '4. Sınıf', value: 4 },
      { label: '5. Sınıf', value: 5 },
      { label: '6. Sınıf', value: 6 }
    ];
  }

  openNew() {
    this.whatis = "Öğrenci Ekle"
    this.student = {};
    this.submitted = false;
    this.studentDialog = true;
  }

  returnMyJobUnit(jobUnitId: string) {
    // @ts-ignore
    const myjobUnit: JobUnit  = this.allJobUnit.find((res: JobUnit) => res.jobUnitGuidId === jobUnitId);
    if (myjobUnit !== undefined) {
      return myjobUnit.jobUnitName as string;
    }

    return "Bulunamadı";
  }

  navigateToDetail(studentGuidId: string) {
    this.router.navigate(['/comp/students/puantaj', studentGuidId]);
  }


  editStudent(myStudent: Student) {
    this.whatis = myStudent.nameSurname + " bilgilerini düzenle"
    this.student = { ...myStudent };
    this.studentDialog = true;
    this.selectedJobUnit = this.allJobUnit.find((res: JobUnit) => res.jobUnitGuidId === myStudent.jobUnitGuidId);
  }

  deleteStudent(myStudent: Student) {
    this.deleteStudentDialog = true;
    this.student = { ...myStudent };
  }
  hideDialog() {
    this.studentDialog = false;
    this.submitted = false;
    this.selectedJobUnit = {}
  }

  confirmDeleteSelected() {
    this.deleteallstudentDialog = false;
    if(this.selectedStudents){
      for(const val of this.selectedStudents){
        this.studentService.DeleteStudent(val.studentGuidId!)
      }
      this.allStudent = this.allStudent.filter(val => !this.selectedStudents.includes(val));
    }else{
      this.toastrService.message("Öğrenci bilgileri silinemedi, Lütfen bir yetki seçiniz!! ", "Silinemedi", {
        messageType: ToastrMessageType.Error,
        position: ToastrPosition.TopRight
      });
    }
    this.selectedStudents = [];
    this.selectedJobUnit = {}
  }

  confirmDelete() {
    this.deleteStudentDialog = false;
    if(this.student.studentGuidId){
      this.studentService.DeleteStudent(this.student.studentGuidId);
      this.allStudent = this.allStudent.filter(val => val.studentGuidId !== this.student.studentGuidId);
    }else{
      this.toastrService.message("Öğrenci bilgileri silinemedi, Lütfen bir öğrenci seçiniz!! ", "Silinemedi", {
        messageType: ToastrMessageType.Error,
        position: ToastrPosition.TopRight
      });
    }
    this.student = {};
    this.selectedJobUnit = {}
  }

  async saveStudent() {
    this.submitted = true;
    if (this.student.nameSurname?.trim()) {
      this.student.jobUnitGuidId = this.selectedJobUnit?.jobUnitGuidId;
      if (this.student.studentGuidId) {
        await this.studentService.UpdateStudent(this.student);
      } else {
        debugger
        await this.studentService.AddStudent(this.student);
      }

      await this.studentService.getAllStudent().then(data => this.allStudent = data);
      this.allStudent = [...this.allStudent];
      this.studentDialog = false;
      this.student = {};
      this.selectedJobUnit = {}
    }
  }

  onGlobalFilter(table: Table, event: Event) {
    table.filterGlobal((event.target as HTMLInputElement).value, 'contains');
  }

  filterJobUnit(event: any) {
    const filtered: any[] = [];
    const query = event.query;
    for (let i = 0; i < (this.allJobUnit as any[]).length; i++) {
      const myJobUnit = (this.allJobUnit as any[])[i];

      // @ts-ignore
      if (myJobUnit.Name.toLowerCase().indexOf(query.toLowerCase()) == 0) {
        filtered.push(myJobUnit);
      }
    }

    this.filteredJobUnit = filtered;
  }

  onFilter(dv: DataView, event: Event) {
    dv.filter((event.target as HTMLInputElement).value);
  }

  getBase64(event: any) {

    const file = event.target.files[0];
    const reader = new FileReader();
    reader.onloadend = () => {
      const base64String = reader.result as string;
      this.student.imageByteString = base64String.replace(/^data:image\/(png|jpg|jpeg);base64,/, '');
    };
    if (file){
      reader.readAsDataURL(file);
    }
  }
}
