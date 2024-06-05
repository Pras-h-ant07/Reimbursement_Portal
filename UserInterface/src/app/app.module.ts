import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http'

import { AppRoutingModule } from './app-routing.module';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { LoginComponent } from './MyComponents/Login/login.component';
import { SignUpComponent } from './MyComponents/Employee/sign-up/sign-up.component';
import { EmployeeDashboardComponent } from './MyComponents/Employee/employee-dashboard/employee-dashboard.component';
import { AddReimbursementComponent } from './MyComponents/Employee/add-reimbursement/add-reimbursement.component';
import { EditReimbursementComponent } from './MyComponents/Employee/edit-reimbursement/edit-reimbursement.component';
import { AdminDashboardComponent } from './MyComponents/Admin/admin-dashboard/admin-dashboard.component';
import { ClaimApprovalFormComponent } from './MyComponents/Admin/claim-approval-form/claim-approval-form.component';
import { PendingClaimComponent } from './MyComponents/Admin/pending-claim/pending-claim.component';
import { DeclinedClaimComponent } from './MyComponents/Admin/declined-claim/declined-claim.component';
import { ApprovedClaimComponent } from './MyComponents/Admin/approved-claim/approved-claim.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    SignUpComponent,
    EmployeeDashboardComponent,
    AddReimbursementComponent,
    EditReimbursementComponent,
    AdminDashboardComponent,
    ClaimApprovalFormComponent,
    PendingClaimComponent,
    DeclinedClaimComponent,
    ApprovedClaimComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
