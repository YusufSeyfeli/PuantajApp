import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import {PrintdocComponent} from "./printdoc.component";



@NgModule({
  imports: [RouterModule.forChild([
    { path: '', component: PrintdocComponent }
  ])],
  exports: [RouterModule]
})
export class PrintdocRoutingModule { }
