import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { OperationClaimComponent } from './operation-claim/operation-claim.component';
import {StudentsInfoComponent} from "./students-info/students-info.component";
import {UserInfoComponent} from "./user-info/user-info.component";
import {AllUsersComponent} from "./all-users/all-users.component";
import {HolidaysComponent} from "./holidays/holidays.component";
import {JobDepartmentsComponent} from "./job-departments/job-departments.component";
import {JobUnitsComponent} from "./job-units/job-units.component";
import {TallyComponent} from "./tally/tally.component";
import {GeneralSettingsComponent} from "./general-settings/general-settings.component";
import {WeeklyTallyComponent} from "./weekly-tally/weekly-tally.component";

@NgModule({
  imports: [RouterModule.forChild([
    { path: 'operation', component: OperationClaimComponent },
    { path: 'students', component: StudentsInfoComponent },
    { path: 'settings', component: GeneralSettingsComponent },
    { path: 'students/puantaj/:id', component: WeeklyTallyComponent },
    { path: 'students/ozel-puantaj/:id', component: TallyComponent },
    { path: 'UserInfo', component: UserInfoComponent },
    { path: 'alluser', component: AllUsersComponent },
    { path: 'holiday', component: HolidaysComponent },
    { path: 'department', component: JobDepartmentsComponent },
    { path: 'department/unit/:id', component: JobUnitsComponent },
  ])],
  exports: [RouterModule]
})
export class ComponentsRoutingModule { }
