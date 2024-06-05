import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Reimbursement } from 'src/app/Models/reimbursement.model';
import { AuthorizeService } from 'src/app/Services/authorize.service';
import { EmployeeService } from 'src/app/Services/employee.service';

@Component({
  selector: 'app-edit-reimbursement',
  templateUrl: './edit-reimbursement.component.html',
  styleUrls: ['./edit-reimbursement.component.css']
})
export class EditReimbursementComponent implements OnInit {

  Reimbursement!: Reimbursement;
  file!: File;
  response: any = null;
  fileType: boolean = true;
  fileUploaded: boolean = false;
  reimbursementCreated: boolean = false;
  id = this.route.snapshot.params['id'];
  constructor(private service: EmployeeService, private router: Router, private route: ActivatedRoute, private authService: AuthorizeService) { }

  ngOnInit(): void {
    this.service.GetReimbursement(this.id).subscribe(
      (data: any) => { this.Reimbursement = data; }
    );
  }

  onSubmit(form: NgForm) {
    if (this.file != null) {
      this.Reimbursement.receiptAttached = "Yes";
      console.log(this.Reimbursement);
      this.service.EditReimbursement(this.Reimbursement).subscribe(
        (error: any) => { console.log(error); }
      );
      this.reimbursementCreated = true;
    }
    else {
      this.Reimbursement.receiptAttached = 'No';
      console.log(this.Reimbursement);
      this.service.EditReimbursement(this.Reimbursement).subscribe(
        (error: any) => { console.log(error); }
      );
    }
    this.router.navigate(['Employee/employee-dashboard/'+this.Reimbursement.signUp_Id]);
  }

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

  fileSelected(files: FileList | null) {
    if (files != null) {
      this.file = files[0];
      if (this.file.type != "image/jpeg" && this.file.type != "image/pdf" && this.file.type != "image/png") {
        this.fileType = false;
      }
      else {
        this.fileUploaded = true;
        this.fileType = true;
      }
      console.log(this.file.type);
    }

  }

}
