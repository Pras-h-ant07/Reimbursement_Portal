import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Reimbursement } from 'src/app/Models/reimbursement.model';
import { AuthorizeService } from 'src/app/Services/authorize.service';
import { EmployeeService } from 'src/app/Services/employee.service';

@Component({
  selector: 'app-employee-dashboard',
  templateUrl: './employee-dashboard.component.html',
  styleUrls: ['./employee-dashboard.component.css']
})

export class EmployeeDashboardComponent implements OnInit {
  [x: string]: any;
  Reimbursements: Reimbursement[];
  constructor(public service: EmployeeService, private route: ActivatedRoute, private authService: AuthorizeService) {
    this.Reimbursements = [];
  }
  
  ngOnInit(): void {
    const id = this.route.snapshot.params['id'];
    console.log(id);
    this.service.getReimbursementsforEmployee(id).subscribe((data:any)=>{
      this.service.reimbursementList=data
      console.log(this.service.reimbursementList)
    })
  }
  
  delete(id: number) {
    this.service.DeleteReimbursement(id).subscribe(
      (error: any) => console.log(error)
    );
    window.location.reload();
  }

  logout() {
    this.authService.logout();
  }

}
