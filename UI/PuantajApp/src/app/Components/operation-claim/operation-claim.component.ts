import {ChangeDetectorRef, Component, OnInit} from '@angular/core';
import { Table } from 'primeng/table';
import {OperationClaim} from "../../Models/operation-claim";
import {OperationclaimService} from "../../Services/ui/Components/operationclaim.service";
import {Competency} from "../../Models/competency";
import { CompetencyService } from "../../Services/ui/Components/competency.service";
import { CustomToastrService, ToastrMessageType, ToastrPosition } from '../../Services/ui/custom-toastr.service';
import {delay} from "rxjs";
import {OperationCompetencyService} from "../../Services/ui/Components/operation-competency.service";
import {OperationCompetency} from "../../Models/operation-competency";

@Component({
  selector: 'app-operation-claim',
  templateUrl: './operation-claim.component.html',
  styleUrls: ['./operation-claim.component.scss']
})
export class OperationClaimComponent implements OnInit {

  operationClaimDialog: boolean = false;

  deleteoperationClaimDialog: boolean = false;

  deleteoperationClaimsDialog: boolean = false;

  operationClaims: OperationClaim[] = [];

  operationClaim: OperationClaim = {};

  selectedOC: OperationClaim[] = [];

  submitted: boolean = false;

  cols: any[] = [];

  competencies: Competency[] = [];

  selectedMultiCompetency?: Competency[] = [];
  myOPCompetency?: OperationCompetency = {};

  myOperationCompetency: OperationCompetency[] = [];

  rowsPerPageOptions = [5, 10, 20];

  constructor(private operationClaimService: OperationclaimService,
              private competencyService: CompetencyService,
              private operationCompetencyService: OperationCompetencyService,
              private toastrService: CustomToastrService) { }

  ngOnInit(){
    this.operationClaimService.getAllOperationClaimWithCompetency().then(data => this.operationClaims = data);
    this.competencyService.getAllCompetencies().then(data => this.competencies = data);
  }

  openNew() {
    this.operationClaim = {};
    this.submitted = false;
    this.operationClaimDialog = true;
  }

  deleteSelectedoperationClaims() {
    this.deleteoperationClaimsDialog = true;
  }

  async editoperationClaim(myoperationClaim: OperationClaim) {
    this.operationClaim = { ...myoperationClaim };
    this.selectedMultiCompetency = myoperationClaim.getCompetencyGetListDtos;
    this.operationClaimDialog = true;
  }

  deleteoperationClaim(operationClaim: OperationClaim) {
    this.deleteoperationClaimDialog = true;
    this.operationClaim = { ...operationClaim };
  }

  confirmDeleteSelected() {
    this.deleteoperationClaimsDialog = false;
    if(this.selectedOC){
      for(const val of this.selectedOC){
        this.operationClaimService.DeleteOperationClaim(val.operationClaimGuidId!)
      }
      this.operationClaims = this.operationClaims.filter(val => !this.selectedOC.includes(val));
    }else{
      this.toastrService.message("Yetki silinemedi, Lütfen bir yetki seçiniz!! ", "Silinemedi", {
        messageType: ToastrMessageType.Error,
        position: ToastrPosition.TopRight
      });
    }
    this.selectedOC = [];
  }

  confirmDelete() {
    this.deleteoperationClaimDialog = false;
    if(this.operationClaim.operationClaimGuidId){
      this.operationClaimService.DeleteOperationClaim(this.operationClaim.operationClaimGuidId);
      this.operationClaims = this.operationClaims.filter(val => val.operationClaimGuidId !== this.operationClaim.operationClaimGuidId);
    }else{
      this.toastrService.message("Yetki silinemedi, Lütfen bir yetki seçiniz!! ", "Silinemedi", {
        messageType: ToastrMessageType.Error,
        position: ToastrPosition.TopRight
      });
    }
    this.operationClaim = {};
  }

  hideDialog() {
    this.operationClaimDialog = false;
    this.submitted = false;
  }

  async saveoperationClaim() {
    this.submitted = true;
    if (this.operationClaim.operationClaimName?.trim()) {
      if (this.operationClaim.operationClaimGuidId) {

        await this.operationClaimService.UpdateOperationClaim(this.operationClaim);

        await this.operationCompetencyService.BulkDeleteOperationCompetency(this.operationClaim.operationClaimGuidId);

        const promiseArray: Promise<void>[] = [];
        for (let i = 0; i < this.selectedMultiCompetency!.length; i++) {
          const competency = this.selectedMultiCompetency![i];
          const promise = new Promise<void>(resolve => {
            this.myOPCompetency!.competencyGuidId = competency.competencyGuidId;
            this.myOPCompetency!.operationClaimGuidId = this.operationClaim.operationClaimGuidId;
            this.myOperationCompetency.push(this.myOPCompetency!);
            this.myOPCompetency = {};
            resolve();
          });
          promiseArray.push(promise);
        }
        await Promise.all(promiseArray);
        await this.operationCompetencyService.BulkAddOperationCompetency(this.myOperationCompetency);
      } else {
        await this.operationClaimService.AddOperationClaim(this.operationClaim);
      }
      await this.operationClaimService.getAllOperationClaimWithCompetency().then(data => this.operationClaims = data);
      this.operationClaims = [...this.operationClaims];
      this.operationClaimDialog = false;
      this.operationClaim = {};
    }
  }

  onGlobalFilter(table: Table, event: Event) {
    table.filterGlobal((event.target as HTMLInputElement).value, 'contains');
  }

}
