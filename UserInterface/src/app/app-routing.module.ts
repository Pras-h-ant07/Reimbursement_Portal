import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ApprovalReimbursement } from './Models/approval-reimbursement.model';
import { AdminDashboardComponent } from './MyComponents/Admin/admin-dashboard/admin-dashboard.component';
import { ApprovedClaimComponent } from './MyComponents/Admin/approved-claim/approved-claim.component';
import { ClaimApprovalFormComponent } from './MyComponents/Admin/claim-approval-form/claim-approval-form.component';
import { DeclinedClaimComponent } from './MyComponents/Admin/declined-claim/declined-claim.component';
import { PendingClaimComponent } from './MyComponents/Admin/pending-claim/pending-claim.component';
import { AddReimbursementComponent } from './MyComponents/Employee/add-reimbursement/add-reimbursement.component';
import { EditReimbursementComponent } from './MyComponents/Employee/edit-reimbursement/edit-reimbursement.component';
import { EmployeeDashboardComponent } from './MyComponents/Employee/employee-dashboard/employee-dashboard.component';
import { SignUpComponent } from './MyComponents/Employee/sign-up/sign-up.component';
import { LoginComponent } from './MyComponents/Login/login.component';
import { AuthAdminGuard } from './Services/auth-admin.guard';
import { AuthEmpGuard } from './Services/auth-emp.guard';

const routes: Routes = [
  { path: 'Login', component: LoginComponent },
  { path: 'Employee/sign-up', component: SignUpComponent },
  { path: 'Employee/employee-dashboard/:id', component: EmployeeDashboardComponent, canActivate : [AuthEmpGuard]},
  { path: 'Employee/add-reimbursement', component: AddReimbursementComponent, canActivate : [AuthEmpGuard] },
  { path: 'Employee/edit-reimbursement/:id', component: EditReimbursementComponent, canActivate : [AuthEmpGuard] },
  { path: 'Admin/admin-dashboard/:id', component: AdminDashboardComponent, canActivate : [AuthAdminGuard] },
  { path: 'Admin/approved-claim', component: ApprovedClaimComponent, canActivate : [AuthAdminGuard] },
  { path: 'Admin/declined-claim', component: DeclinedClaimComponent, canActivate : [AuthAdminGuard] },
  { path: 'Admin/pending-claim', component: PendingClaimComponent, canActivate : [AuthAdminGuard] },
  { path: 'Admin/claim-approval-form/:ClaimId', component: ClaimApprovalFormComponent, canActivate : [AuthAdminGuard] },
  { path: '', redirectTo: 'Login', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
