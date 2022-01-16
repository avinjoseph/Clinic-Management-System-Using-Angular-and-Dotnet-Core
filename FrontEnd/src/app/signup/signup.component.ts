import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { EmployeeService } from '../shared/employee.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss'],
})
export class SignupComponent implements OnInit {
  empId: number;
  roleId: number;
  constructor(
    public empService: EmployeeService,
    private toastr: ToastrService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    //get empId from activated route
    this.empId = this.route.snapshot.params['empId'];
    this.roleId = this.route.snapshot.params['roleId'];
  }

  //onSubmit function
  onSubmit(form: NgForm) {
    console.log(form.value);
    let addId = this.empService.loginForm.LoginId;
    //insert
    if (addId == 0 || addId == null) {
      this.insertLogin(form);
    }
  }

  //clear all contents and Initialization
  resetForm(from?: NgForm) {
    if (from != null) {
      from.resetForm();
    }
  }

  //Insert
  insertLogin(form?: NgForm) {
    console.log('Iserting a record...');
    form.value.RoleId = this.roleId;
    form.value.EmployeeId = this.empId;
    this.empService.insertLogin(form.value).subscribe((data) => {
      console.log(data);
      this.toastr.success('User added', 'CMSApp v2021');
      this.router.navigateByUrl('/admin');
    });
  }
}
