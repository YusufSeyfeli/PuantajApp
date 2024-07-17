import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MonthlyplanComponent} from "./monthlyplan/monthlyplan.component";
import { SignchartComponent } from './signchart/signchart.component';
import { MonthlyrulerComponent } from './monthlyruler/monthlyruler.component';
import {ButtonModule} from "primeng/button";
import {RippleModule} from "primeng/ripple";



@NgModule({
  declarations: [
    MonthlyplanComponent,
    SignchartComponent,
    MonthlyrulerComponent
  ],
  exports: [
    SignchartComponent,
    MonthlyrulerComponent,
    MonthlyplanComponent
  ],
  imports: [
    CommonModule,
    ButtonModule,
    RippleModule
  ]
})
export class DocreateModule { }
