import { NgModule } from "@angular/core";
import { HttpClientModule } from "@angular/common/http";
import { RouterModule } from "@angular/router";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";

import { AcceuilRoutes } from "./acceuil.routing";   

import { NgbModule } from "@ng-bootstrap/ng-bootstrap";
import { DashboardAcceuilComponent } from './dashboard-acceuil/dashboard-acceuil.component';
import { LoginComponent } from './login/login.component';
import { MatIconModule } from "@angular/material/icon";
import {MatDialogModule, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';

@NgModule({
  imports: [
    MatDialogModule,
    CommonModule,
    RouterModule.forChild(AcceuilRoutes),
    FormsModule,
    HttpClientModule,
    NgbModule,
    MatIconModule
  ],
  declarations: [   
     DashboardAcceuilComponent, LoginComponent
  ]
}) 

export class AcceuilModule { } 
