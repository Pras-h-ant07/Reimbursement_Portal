import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Employee } from 'src/app/Models/employee.model';
import { EmployeeService } from 'src/app/Services/employee.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {

  OriginalEmployee: Employee = {
    signUp_id: 0,
    email: '',
    password: '',
    reEnterPassword: '',
    fullName: '',
    bank: '',
    panNumber: '',
    accountNumber: '',
    isApprover: 'Y'
  };
  EmailAvailable: boolean = true;
  Employee: Employee = { ...this.OriginalEmployee };
  constructor(private service: EmployeeService, private router: Router) { }

  ngOnInit(): void {
  }

  onSubmit(form: NgForm) {
    this.service.EmailAvailable(this.Employee.email).subscribe((result: any) => {
      console.log(result);
      if (result.available) {
        this.service.CreateEmployee(this.Employee).subscribe(
          result => console.log('Sucess' + result),
        )
        this.router.navigate(['Login']);
      }
      else {
        this.EmailAvailable = false;
      }
    }
    );
  }
}
