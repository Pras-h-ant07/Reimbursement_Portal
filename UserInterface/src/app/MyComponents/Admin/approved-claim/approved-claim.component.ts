import { Component, OnInit } from '@angular/core';
import { Reimbursement } from 'src/app/Models/reimbursement.model';
import { AuthorizeService } from 'src/app/Services/authorize.service';
import { EmployeeService } from 'src/app/Services/employee.service';

@Component({
  selector: 'app-approved-claim',
  templateUrl: './approved-claim.component.html',
  styleUrls: ['./approved-claim.component.css']
})
export class ApprovedClaimComponent implements OnInit {

  Reimbursements: Reimbursement[];

  constructor(public service: EmployeeService, private authService: AuthorizeService) {
    this.Reimbursements = [];
  }

  ngOnInit(): void {
    this.service.getAllAcceptedRequest().subscribe(
      (result: any) => this.service.adminReimbursement = result
    )
  }

  logout() {
    this.authService.logout();
  }

}
