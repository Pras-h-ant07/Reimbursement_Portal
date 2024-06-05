import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthorizeService {

  constructor(private router: Router) { }

  getCurrentEmployee() {
    return localStorage.getItem('CurrentEmployeeId');
  }

  isLoggedIn() {
    let authToken = localStorage.getItem('CurrentEmployeeId');
    return (authToken != null) ? true : false;
  }

  logout() {
    let removeCurrentUser = localStorage.removeItem('CurrentEmployeeId');
    let IsApprover = localStorage.getItem('IsApprover');
    if (IsApprover != null) {
      localStorage.removeItem('IsApprover');
    }
    this.router.navigate(['/Login']);
  }

  isLoggedInAdmin() {
    let IsApprover = localStorage.getItem('IsApprover');
    return (IsApprover != null) ? true : false;
  }
}
