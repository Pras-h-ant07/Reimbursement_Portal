import { Component, Input, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ApprovalReimbursement } from 'src/app/Models/approval-reimbursement.model';
import { EmployeeService } from 'src/app/Services/employee.service';

@Component({
  selector: 'app-claim-approval-form',
  templateUrl: './claim-approval-form.component.html',
  styleUrls: ['./claim-approval-form.component.css']
})
export class ClaimApprovalFormComponent implements OnInit {

  Reimbursement : ApprovalReimbursement = {
    approvedValue : 0,
    approvedBy : '',
    internalNotes : '',
    claimId: 0
  };
  
  @Input() id! : number;

  constructor(private service:EmployeeService,private route: ActivatedRoute,private router : Router) {
    const reimbursementId = this.route.snapshot.params['ClaimId'];
    console.log(reimbursementId);
    this.Reimbursement.claimId = reimbursementId;
   }

  ngOnInit(): void {
    console.log(this.Reimbursement.claimId);
  }
  onSubmit(form : NgForm) {
    this.service.ApproveReimbursement(this.Reimbursement).subscribe(
      (error: any) => {console.log(error)}
    )
    this.router.navigate(['/Admin/pending-claim']);
  }

}
