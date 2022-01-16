import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Login } from './login';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private httpClient: HttpClient, private router: Router) {}

  //get an user
  getUserByPassword(user: Login): Observable<any> {
    console.log(user.UserName);
    console.log(user.Password);
    return this.httpClient.get(
      environment.apiUrl + '/api/login/' + user.UserName + '/' + user.Password
    );
  }

  //authorize user
  public loginVerify(user: Login) {
    console.log(user);
    return this.httpClient.get(
      environment.apiUrl + '/api/login/' + user.UserName + '/' + user.Password
    );
  }

  //logout
  public logout() {
    localStorage.removeItem('username');
    localStorage.removeItem('ACCESS_ROLE');
    sessionStorage.removeItem('username');
    sessionStorage.removeItem('jwtToken');
  }
}
