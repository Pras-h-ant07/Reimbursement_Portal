import { Component, OnInit } from '@angular/core';
import { Reimbursement } from 'src/app/Models/reimbursement.model';
import { AuthorizeService } from 'src/app/Services/authorize.service';
import { EmployeeService } from 'src/app/Services/employee.service';

@Component({
  selector: 'app-declined-claim',
  templateUrl: './declined-claim.component.html',
  styleUrls: ['./declined-claim.component.css']
})
export class DeclinedClaimComponent implements OnInit {

  Reimbursements: Reimbursement[];

  constructor(public service: EmployeeService,private authService : AuthorizeService) {
    this.Reimbursements = [];
   }

  ngOnInit(): void {
    this.service.getAllDeclinedRequest().subscribe(
      (result: any) => this.service.adminReimbursement = result
    )
  }
  
  logout() {
    this.authService.logout();
  }

}
