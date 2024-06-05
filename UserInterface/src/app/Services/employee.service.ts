import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from 'src/app/Models/employee.model';
import { AdminReimbursement } from '../Models/admin-reimbursement.model';
import { ApprovalReimbursement } from '../Models/approval-reimbursement.model';
import { DeclineReimbursement } from '../Models/decline-reimbursement.model';
import { Reimbursement } from '../Models/reimbursement.model';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private http: HttpClient) { }

  readonly baseURL = 'https://localhost:44326/api';

  adminReimbursement: AdminReimbursement[] = [];
  reimbursementList:Reimbursement[]=[];
  reimbursementData:Reimbursement=new Reimbursement();
  //Register Employee-----
  CreateEmployee(Employee: Employee): Observable<any> {
    console.log(Employee);
    return this.http.post(this.baseURL + '/signUp/CreateEmployee', Employee);
  }

  //Login Employee-----
  EmailAvailable(email: string) { return this.http.get(this.baseURL + '/login/emailAvailable/' + email); }

  Login(Employee: Employee): any {
    console.log(Employee);
    return this.http.post<any>(this.baseURL + '/login/Logins', Employee);
  }

  //Employee dashboard----
  CreateReimbursement(Reimbursement: Reimbursement): any {
    return this.http.post<any>(this.baseURL + '/reimbursement/CreateReimbursement', Reimbursement);
  }
  getReimbursementsforEmployee(id: Number): any {
    return this.http.get<Reimbursement>(this.baseURL + '/reimbursement/getReimbursementsforEmployee/' + id);
  }

  public GetReimbursement(id: number): any {
    return this.http.get<Reimbursement>(this.baseURL + '/reimbursement/GetReimbursement/' + id);
  }

  public EditReimbursement(reimbursement: Reimbursement): Observable<any> {
    return this.http.put(this.baseURL + '/reimbursement/EditReimbursement', reimbursement);
  }

  public DeleteReimbursement(id: Number): Observable<any> {
    return this.http.delete(this.baseURL + '/reimbursement/deleteReimbursement/' + id);
  }

  //Admin dashboard-----
  getAllPendingRequest(): Observable<AdminReimbursement[]> {
    return this.http.get<AdminReimbursement[]>(this.baseURL + '/reimbursement/getAllPendingRequest');
  }

  getAllAcceptedRequest(): any {
    return this.http.get<Reimbursement>(this.baseURL + '/reimbursement/getAllAcceptedRequest');
  }

  getAllDeclinedRequest(): any {
    return this.http.get<Reimbursement>(this.baseURL + '/reimbursement/getAllDeclinedRequest');
  }

  DeclineReimbursement(DeclineReimbursement: DeclineReimbursement): Observable<any> {
    return this.http.put(this.baseURL + '/reimbursement/DeclineReimbursement/', DeclineReimbursement);
  }

  ApproveReimbursement(ApprovalReimbursement: ApprovalReimbursement): Observable<any> {
    return this.http.post<any>(this.baseURL + '/reimbursement/ApproveReimbursement', ApprovalReimbursement);
  }
}
