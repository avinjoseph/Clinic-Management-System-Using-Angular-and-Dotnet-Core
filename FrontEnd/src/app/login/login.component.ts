import { AuthService } from './../shared/auth.service';
import { JWTResponse } from './../shared/jwtresponse';
import { Login } from './../shared/login';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  //declaring variables
  loginForm: FormGroup;
  isSubmitted: boolean = false;
  loginUser: Login = new Login();
  error = '';
  jwtResponse: any = new JWTResponse();
  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private authService: AuthService
  ) {}

  ngOnInit(): void {
    //FormGroup
    this.loginForm = this.formBuilder.group({
      UserName: ['', [Validators.required, Validators.minLength(2)]],
      Password: ['', [Validators.required]],
    });
  }

  //get controls
  get formControls() {
    return this.loginForm.controls;
  }

  //login verify credntials
  loginCredentials() {
    this.isSubmitted = true;
    console.log(this.loginForm.value);

    //invalid
    if (this.loginForm.invalid) return;

    //valid
    if (this.loginForm.valid) {
      this.authService.loginVerify(this.loginForm.value).subscribe(
        (data) => {
          console.log(data);
          this.jwtResponse = data;
          sessionStorage.setItem('jwtToken', this.jwtResponse.Token);
          //Check the role--based on TRoleIdit redirect to the respective component
          if (this.jwtResponse.RoleId === 3) {
            //logged as Admin
            console.log('Admin');

            //storing in localStorage/sessionStorage
            localStorage.setItem('username', this.jwtResponse.UserName);
            localStorage.setItem('name', this.jwtResponse.Name);
            localStorage.setItem(
              'ACCESS_ROLE',
              this.jwtResponse.RoleId.toString()
            );
            localStorage.setItem('empId', this.jwtResponse.EmployeeId.toString());
            sessionStorage.setItem('username', this.jwtResponse.UserName);
            this.router.navigateByUrl('/admin');
          } else if (this.jwtResponse.RoleId === 2) {
            //logged as Lab Technician
            console.log('Lab Technician');
            //storing in localStorage/sessionStorage
            localStorage.setItem('username', this.jwtResponse.UserName);
            localStorage.setItem('name', this.jwtResponse.Name);
            localStorage.setItem(
              'ACCESS_ROLE',
              this.jwtResponse.RoleId.toString()
            );
            sessionStorage.setItem('username', this.jwtResponse.UserName);
            this.router.navigate([
              'labtechnician',
              this.jwtResponse.EmployeeId,
            ]);
          } else if (this.jwtResponse.RoleId === 1) {
            //logged as Doctor
            console.log('Doctor');
            //storing in localStorage/sessionStorage
            localStorage.setItem('username', this.jwtResponse.UserName);
            localStorage.setItem('name', this.jwtResponse.Name);
            localStorage.setItem(
              'ACCESS_ROLE',
              this.jwtResponse.RoleId.toString()
            );
            sessionStorage.setItem('username', this.jwtResponse.UserName);
            this.router.navigate(['doctor', this.jwtResponse.EmployeeId]);
          } else if (this.jwtResponse.RoleId === 4) {
            //logged  as receptionist
            localStorage.setItem('username', this.jwtResponse.UserName);
            localStorage.setItem('name', this.jwtResponse.Name);
            localStorage.setItem(
              'ACCESS_ROLE',
              this.jwtResponse.RoleId.toString()
            );
            sessionStorage.setItem('username', this.jwtResponse.UserName);
            this.router.navigateByUrl('receptionist');
          } else {
            this.error =
              'Sorry! not allowed to access ... Invalid authorization';
          }
        },
        (error) => {
          this.error = 'Invalid username or password';
        }
      );
    }
  }

  //LoginVerify Test

  loginVerifyTest() {
    if (this.loginForm.valid) {
      this.authService.getUserByPassword(this.loginForm.value).subscribe(
        (data) => {
          console.log(data);
        },

        (error) => {
          console.log(error);
        }
      );
    }
  }
}
