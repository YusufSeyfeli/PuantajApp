import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {PrintdocComponent} from "./printdoc.component";
import {PrintdocRoutingModule} from "../printdoc/printdoc-routing.module";
import {ButtonModule} from "primeng/button";
import {InputTextModule} from "primeng/inputtext";
import {RippleModule} from "primeng/ripple";
import {DocreateModule} from "../../docreate/docreate.module";

@NgModule({
    imports: [
        PrintdocRoutingModule,
        ButtonModule,
        InputTextModule,
        RippleModule,
        DocreateModule,
    ],
  declarations: [PrintdocComponent]
})
export class PrintdocModule { }
