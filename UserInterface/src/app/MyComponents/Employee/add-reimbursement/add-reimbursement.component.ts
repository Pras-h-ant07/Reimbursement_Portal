import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Reimbursement } from 'src/app/Models/reimbursement.model';
import { AuthorizeService } from 'src/app/Services/authorize.service';
import { EmployeeService } from 'src/app/Services/employee.service';

@Component({
  selector: 'app-add-reimbursement',
  templateUrl: './add-reimbursement.component.html',
  styleUrls: ['./add-reimbursement.component.css']
})
export class AddReimbursementComponent implements OnInit {

  CurrentUser!: string | null;
  OriginalReimbursement: Reimbursement = {
    claimId: 0,
    date: new Date(),
    reimbursementType: '',
    requestedValue: 0,
    approvedValue: 0,
    currency: '',
    requestPhase: 'To be processed',
    receiptAttached: '',
    signUp_Id: 0
  };
  Reimbursement: Reimbursement = { ...this.OriginalReimbursement };


  constructor(private service: EmployeeService, private router: Router, private route: ActivatedRoute, private authService: AuthorizeService) {
    this.CurrentUser = this.authService.getCurrentEmployee();
    if (this.CurrentUser != null) {
      this.Reimbursement.signUp_Id = parseInt(this.CurrentUser);
    }
  }

  ngOnInit(): void {
  }

  file!: File;
  fileType: boolean = false;
  fileUploaded: boolean = false;

  checkValue() {
    let num = this.Reimbursement.requestedValue.toString();
    let indexDecimal = num.indexOf('.');
    if (indexDecimal != -1) {
      let length = num.length;
      let decimals = length - indexDecimal - 1;
      if (decimals > 2) {
        num = num.slice(0, -(decimals - 2))
      }
      this.Reimbursement.requestedValue = parseFloat(num);
    }
  }

  fileSelected(file: FileList | null) {
    if (file != null) {
      this.file = file[0];
      if (this.file.type != "image/jpeg" && this.file.type != "image/pdf" && this.file.type != "image/png") {
        this.fileType = false;
      }
      else {
        this.fileUploaded = true;
        this.fileType = true;
      }
      this.Reimbursement.receiptAttached = "Yes";
      console.log(this.file.type);
    }
  }

  onSubmit(form: NgForm) {
    if (this.file != null) {

      this.Reimbursement.receiptAttached = "No";
      this.service.CreateReimbursement(this.Reimbursement).subscribe(
        (error: any) => { console.log(error); }
      );
    }
    else {
      this.Reimbursement.receiptAttached = "No";
      this.service.CreateReimbursement(this.Reimbursement).subscribe(
        (error: any) => { console.log(error); }
      );
    }
    this.router.navigate(['/Employee/employee-dashboard/' + this.Reimbursement.signUp_Id]);
  }

}
