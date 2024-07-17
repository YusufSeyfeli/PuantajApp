import { NgModule } from '@angular/core';
import {ComponentsRoutingModule} from './components.routing.module';
import { OperationClaimComponent } from './operation-claim/operation-claim.component';
import { StudentsInfoComponent } from './students-info/students-info.component';
import { UserInfoComponent } from './user-info/user-info.component';
import { NotFoundComponent } from './not-found/not-found.component';

import {ToastModule} from "primeng/toast";
import {ToolbarModule} from "primeng/toolbar";
import {TableModule} from "primeng/table";
import {DialogModule} from "primeng/dialog";
import {FormsModule} from "@angular/forms";
import {ButtonModule} from "primeng/button";
import {RippleModule} from "primeng/ripple";
import {InputTextModule} from "primeng/inputtext";
import {NgClass, NgForOf, NgIf} from "@angular/common";
import {MessageService} from "primeng/api";
import { AllUsersComponent } from './all-users/all-users.component';
import {InputNumberModule} from "primeng/inputnumber";
import {FileUploadModule} from "primeng/fileupload";
import {DropdownModule} from "primeng/dropdown";
import {AutoCompleteModule} from "primeng/autocomplete";
import {ImageModule} from "primeng/image";
import {MultiSelectModule} from "primeng/multiselect";
import {ListboxModule} from "primeng/listbox";
import {HolidaysComponent} from "./holidays/holidays.component";
import {CalendarModule} from "primeng/calendar";
import {JobDepartmentsComponent} from "./job-departments/job-departments.component";
import {JobUnitsComponent} from "./job-units/job-units.component";
import {DataViewModule} from "primeng/dataview";
import {TallyComponent} from "./tally/tally.component";
import {GeneralSettingsComponent} from "./general-settings/general-settings.component";
import {ChipModule} from "primeng/chip";
import {MonthlyplanComponent} from "../docreate/monthlyplan/monthlyplan.component";
import { WeeklyTallyComponent } from '../Components/weekly-tally/weekly-tally.component';
import {DocreateModule} from "../docreate/docreate.module";
@NgModule({
  declarations: [
    OperationClaimComponent,
    StudentsInfoComponent,
    UserInfoComponent,
    NotFoundComponent,
    AllUsersComponent,
    HolidaysComponent,
    JobDepartmentsComponent,
    JobUnitsComponent,
    TallyComponent,
    GeneralSettingsComponent,
    WeeklyTallyComponent
  ],
    imports: [
        ComponentsRoutingModule,
        ToastModule,
        ToolbarModule,
        TableModule,
        DialogModule,
        FormsModule,
        ButtonModule,
        RippleModule,
        InputTextModule,
        NgClass,
        NgIf,
        InputNumberModule,
        FileUploadModule,
        DropdownModule,
        AutoCompleteModule,
        ImageModule,
        MultiSelectModule,
        ListboxModule,
        NgForOf,
        CalendarModule,
        DataViewModule,
        ChipModule,
        DocreateModule
    ],
  providers: [MessageService]
})
export class ComponentsModule { }
