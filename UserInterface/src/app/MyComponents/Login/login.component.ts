import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/Models/employee.model';
import { Reimbursement } from 'src/app/Models/reimbursement.model';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { EmployeeService } from 'src/app/Services/employee.service';
import { AuthorizeService } from 'src/app/Services/authorize.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private service: EmployeeService, private router: Router, private Authservice: AuthorizeService) { }

  ngOnInit(): void {
  }

  OriginalEmployee: Employee = {
    signUp_id: 0,
    email: '',
    password: '',
    reEnterPassword: 'q',
    fullName: 'a',
    bank: 'ICICI',
    panNumber: 'DL12345678',
    accountNumber: '123456789123',
    isApprover: 'No'
  };

  InvalidAttempt: boolean = false;
  Employee: Employee = { ...this.OriginalEmployee };
  errorMessage: any;

  onSubmit(form: NgForm) {

    this.service.Login(this.Employee).subscribe(
      (data: any) => {
        if (data.status) {
          if (data.isApprover == "Yes") {
            localStorage.setItem('IsApprover', data.isApprover);
            this.router.navigate(['/Admin/admin-dashboard', data.signUp_Id]);
          }
          else {
            localStorage.setItem('CurrentEmployeeId', data.signUp_Id);
            this.router.navigate(['/Employee/employee-dashboard', data.signUp_Id]);
          }

        }
        else {
          form.resetForm();
          this.router.navigate(['/Login']);
        }
      },
      (error: { message: any; }) => {
        this.InvalidAttempt = true;
        this.errorMessage = error.message;
      }
    );

  }
}
