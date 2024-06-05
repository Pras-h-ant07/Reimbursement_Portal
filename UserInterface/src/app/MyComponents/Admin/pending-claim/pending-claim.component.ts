import { Component, OnInit } from '@angular/core';
import { DeclineReimbursement } from 'src/app/Models/decline-reimbursement.model';
import { Reimbursement } from 'src/app/Models/reimbursement.model';
import { AuthorizeService } from 'src/app/Services/authorize.service';
import { EmployeeService } from 'src/app/Services/employee.service';

@Component({
  selector: 'app-pending-claim',
  templateUrl: './pending-claim.component.html',
  styleUrls: ['./pending-claim.component.css']
})
export class PendingClaimComponent implements OnInit {

  reimbursements: any;
  requestedBy: string = '';
  reimbursementType: string = '';

  constructor(public service: EmployeeService, private authService: AuthorizeService) { }
  decline: DeclineReimbursement = { claimId: 100 };

  ngOnInit(): void {
    this.service.getAllPendingRequest().subscribe(
      (result: any) => this.service.adminReimbursement = result
    )
  }

  SearchRequestedBy(email: string) {
    this.requestedBy = email;
  }

  Decline(id: number) {
    this.decline.claimId = id;
    this.service.DeclineReimbursement(this.decline).subscribe(
      (err: any) => console.log(err)
    );
     window.location.reload()
  }

  logout() {
    this.authService.logout();
  }

}
