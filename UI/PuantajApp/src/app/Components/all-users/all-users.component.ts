import {Component, OnInit} from '@angular/core';
import {JobUnitService} from "../../Services/ui/Components/job-unit.service";
import {CustomToastrService, ToastrMessageType, ToastrPosition} from "../../Services/ui/custom-toastr.service";
import {UserService} from "../../Services/ui/Components/user.service";
import {Student} from "../../Models/student";
import {JobUnit} from "../../Models/job-unit";
import {postUser, User} from "../../Models/user";
import {Table} from "primeng/table";
import {MyOperationClaim, OperationClaim} from "../../Models/operation-claim";
import {OperationclaimService} from "../../Services/ui/Components/operationclaim.service";
import {UserOperationClaimService} from "../../Services/ui/Components/user-operation-claim.service";
import {UserJobUnitService} from "../../Services/ui/Components/user-job-unit.service";
import {UserOperationClaim} from "../../Models/user-operation-claim";
import {UserJobUnit} from "../../Models/UserJobUnit";
import {delay} from "rxjs";

@Component({
  selector: 'app-all-users',
  templateUrl: './all-users.component.html',
  styleUrls: ['./all-users.component.scss']
})
export class AllUsersComponent implements OnInit{
  constructor(private userService: UserService,
              private jobUnitService: JobUnitService,
              private userJobUnitService: UserJobUnitService,
              private opearationClaimService: OperationclaimService,
              private userOperationServices: UserOperationClaimService,
              private toastrService: CustomToastrService) {
  }

  ngOnInit(){
    this.myGetAllUser().then(res => {
      this.myGetAllUnit();
    }).then(res => {
      this.mygetAllOClaim();
    });
    //this.userService.getAllUser().then(data => this.allUser = data);
    //this.jobUnitService.getAllJobUnit().then(data => this.allJobUnit = data);
    //this.opearationClaimService.getAllOperationClaim().then(data => this.allOperationClaim = data);
  }
  mygetAllOClaim(){
    return new Promise<void>((resolve, reject) => {
      this.opearationClaimService.getAllOperationClaim().then(data => this.allOperationClaim = data);
      resolve();
    });
  }
  myGetAllUnit(){
    return new Promise<void>((resolve, reject) => {
      this.jobUnitService.getAllJobUnit().then(data => this.allJobUnit = data);
      resolve();
    });
  }
  async myGetAllUser(){
    return new Promise<void>((resolve, reject) => {
      this.userService.getAllUser().then(data => this.allUser = data);
      resolve();
    });
  }

  userDialog: boolean = false;

  deleteUserDialog: boolean = false;

  deleteallUserDialog: boolean = false;

  allUser: User[] = [];

  user: User = {};
  myPostUser: postUser = {}

  selectedUsers: User[] = [];

  submitted: boolean = false;

  cols: any[] = [];

  rowsPerPageOptions = [5, 10, 20];

  allJobUnit: JobUnit[] = [];

  allOperationClaim: MyOperationClaim[] = [];

  selectedMultiOperation?: MyOperationClaim[] = [];

  myUserOPClaim?:UserOperationClaim = {};
  myUserOperationClaims:UserOperationClaim[] = [];

  filteredJobUnit?: JobUnit[] = [];
  myUserJu?: UserJobUnit = {};
  myUserJobUnits: UserJobUnit[] = [];
  getBase64(event: any) {
    const file = event.target.files[0];
    const reader = new FileReader();
    reader.onloadend = () => {
      const base64String = reader.result as string;
      this.user.imageByte = base64String.replace(/^data:image\/(png|jpg|jpeg);base64,/, '');
    };
    if (file){
      reader.readAsDataURL(file);
    }
  }
  openNew() {
    this.user = {};
    this.submitted = false;
    this.userDialog = true;
  }

  deleteSelectedAllStudent() {
    this.deleteallUserDialog = true;
  }

  editStudent(myUser: User) {
    this.user = { ...myUser };
    this.filteredJobUnit = myUser.jobUnitDtos;
    this.selectedMultiOperation = myUser.operationClaimGetListDtos;
    console.log(this.selectedMultiOperation);
    console.log(this.allOperationClaim);
    this.userDialog = true;
  }

  deleteStudent(myUser: User) {
    this.deleteUserDialog = true;
    this.user = { ...myUser };
  }
  hideDialog() {
    this.userDialog = false;
    this.selectedMultiOperation = [];
    this.filteredJobUnit = [];
    this.submitted = false;
  }

  confirmDeleteSelected() {
    this.deleteallUserDialog = false;
    if(this.selectedUsers){
      for(const val of this.selectedUsers){
        this.userService.DeleteUser(val.userGuidId!)
      }
      this.allUser = this.allUser.filter(val => !this.selectedUsers.includes(val));
    }else{
      this.toastrService.message("Kullanıcı bilgileri silinemedi, Lütfen bir yetki seçiniz!! ", "Silinemedi", {
        messageType: ToastrMessageType.Error,
        position: ToastrPosition.TopRight
      });
    }
    this.selectedUsers = [];
  }

  confirmDelete() {
    this.deleteUserDialog = false;
    if(this.user.userGuidId){

      this.userService.DeleteUser(this.user.userGuidId);
      this.allUser = this.allUser.filter(val => val.userGuidId !== this.user.userGuidId);
    }else{
      this.toastrService.message("Kullanıcı bilgileri silinemedi, Lütfen bir öğrenci seçiniz!! ", "Silinemedi", {
        messageType: ToastrMessageType.Error,
        position: ToastrPosition.TopRight
      });
    }
    this.user = {};
  }

  myBulkAddForUserOperatinClaim(myUserOperationClaim: UserOperationClaim[]){
    return new Promise<void>((resolve, reject) => {
      this.userOperationServices.BulkAddUserOperationClaim(myUserOperationClaim);
      resolve();
    });
  }
  myBulkAddForUserJobUnit(myuserJobUnit: UserJobUnit[]){
    return new Promise<void>((resolve, reject) => {
      this.userJobUnitService.BulkAddUserJobUnit(myuserJobUnit);
      resolve();
    });
  }
  async UpdatemyUser(myUser: postUser){
    return new Promise<void>((resolve, reject) => {
      this.userService.UpdateUser(this.myPostUser);
      resolve();
    });
  }
  async saveMyUser() {
    this.submitted = true;
    if (this.user.nameSurname?.trim()) {
      if (this.user.userGuidId) {

          this.myPostUser.userGuidId = this.user.userGuidId;
          this.myPostUser.nameSurname = this.user.nameSurname
          this.myPostUser.imageByteString = this.user.imageByte
          this.myPostUser.email = this.user.email;


        const UserOPpromiseArray: Promise<void>[] = [];
        for (let i = 0; i < this.selectedMultiOperation!.length; i++) {
          const myOperationClaim = this.selectedMultiOperation![i];
          const promise = new Promise<void>(resolve => {
            this.myUserOPClaim!.operationClaimGuidId = myOperationClaim.operationClaimGuidId;
            this.myUserOPClaim!.userGuidId = this.user.userGuidId;
            this.myUserOperationClaims.push(this.myUserOPClaim!);
            this.myUserOPClaim = {};
            resolve();
          });
          UserOPpromiseArray.push(promise);
        }
        await Promise.all(UserOPpromiseArray);

        const promiseArray: Promise<void>[] = [];
        for (let i = 0; i < this.filteredJobUnit!.length; i++) {
          const JobUnits = this.filteredJobUnit![i];
          const UserJupromise = new Promise<void>(resolve => {
            this.myUserJu!.jobUnitGuidId = JobUnits.jobUnitGuidId;
            this.myUserJu!.userGuidId = this.user.userGuidId;
            this.myUserJobUnits.push(this.myUserJu!);
            this.myUserJu = {};
            resolve();
          });
          promiseArray.push(UserJupromise);
        }
        await Promise.all(promiseArray);

          this.UpdatemyUser(this.myPostUser).then(res =>{

            if(this.myUserOperationClaims.length != 0) {
              return this.myBulkAddForUserOperatinClaim(this.myUserOperationClaims);
            }else {
              return this.userOperationServices.BulkDeleteUserOperationClaim(this.user.userGuidId!)
            }
          }).then(res =>{

            if(this.myUserJobUnits.length != 0) {
              return this.myBulkAddForUserJobUnit(this.myUserJobUnits);
            }else {
              return this.userJobUnitService.BulkDeleteUserJobUnit(this.user.userGuidId!);
            }

          }).then(res => {return this.myGetAllUser();})
            .catch(err => {
            this.toastrService.message(" Bir şeyler yanlış gitti!! ", "Hata", {
              messageType: ToastrMessageType.Error,
              position: ToastrPosition.TopRight
            });
          })
      } else {
        this.toastrService.message(" Lütfen bir Kullanıcı seçiniz!! ", "Hata", {
          messageType: ToastrMessageType.Error,
          position: ToastrPosition.TopRight
        });
      }

      //await this.userService.getAllUser().then(data => this.allUser = data);
      this.allUser = [...this.allUser];
      this.userDialog = false;
      /*
      this.selectedMultiOperation = [];
      this.filteredJobUnit = [];
      this.myPostUser = {};
      this.user = {};
       */
    }
  }
  onGlobalFilter(table: Table, event: Event) {
    table.filterGlobal((event.target as HTMLInputElement).value, 'contains');
  }

  filterJobUnit(event: any) {
    const filtered: any[] = [];
    const query = event.query;
    for (let i = 0; i < this.allJobUnit.length; i++) {
      const myJobUnit = this.allJobUnit[i];
      // @ts-ignore
      if (myJobUnit.Name.toLowerCase().indexOf(query.toLowerCase()) == 0) {
        filtered.push(myJobUnit);
      }
    }

    this.filteredJobUnit = filtered;
  }
}
