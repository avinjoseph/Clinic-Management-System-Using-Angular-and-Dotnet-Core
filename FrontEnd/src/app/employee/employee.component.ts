import { Employee } from './../shared/employee';
import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../shared/employee.service';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.scss'],
})
export class EmployeeComponent implements OnInit {
  empId: number;
  employee: Employee = new Employee();
  status: boolean;
  constructor(
    public empService: EmployeeService,
    private toastr: ToastrService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    //geting departments and roles for binding
    this.empService.getAllDepartments();
    this.empService.getAllRoles();
    //get empId from activated route
    this.empId = this.route.snapshot.params['empId'];
    //this.resetform();
    if (this.empId != 0 || this.empId != null) {
      //get employee
      this.status = false;
      this.empService.getEmployee(this.empId).subscribe(
        (data) => {
          console.log(data);
          //date format
          var datePipe = new DatePipe('en-UK');
          let formatDate: any = datePipe.transform(
            data.DateOfJoining,
            'yyyy-MM-dd'
          );
          data.DateOfJoining = formatDate;
          this.empService.formData = data;
        },
        (error) => console.log(error)
      );
    } else {
      this.status = true;
    }
  }

  //onSubmit function
  onSubmit(form: NgForm) {
    console.log(form.value);
    let addId = this.empService.formData.EmployeeId;
    //insert
    if (addId == 0 || addId == null) {
      this.insertEmployee(form);
    } else {
      console.log('updating record');
      this.updateEmployee(form);
    }
  }

  //clear all contents and Initialization
  resetForm(from?: NgForm) {
    if (from != null) {
      from.resetForm();
    }
  }

  //Insert
  insertEmployee(form?: NgForm) {
    console.log('Iserting a record...');
    form.value.IsActive = true;
    this.empService.insertEmployee(form.value).subscribe((data) => {
      console.log(data);
      this.toastr.success('Employee added', 'CMSApp v2021');
      //this.resetForm(form);
      console.log(form.value.RoleId);
      if (form.value.RoleId == 1 || form.value.RoleId == 2) {
        this.router.navigate(['specialization', data, form.value.RoleId]);
      } else {
        this.router.navigate(['signup', data, form.value.RoleId]);
      }
    });
  }

  //Update
  updateEmployee(form?: NgForm) {
    console.log('updating a record...');
    this.empService.updateEmployee(form.value).subscribe((data) => {
      console.log(data);
      this.resetForm(form);
      this.toastr.success('Employee updated', 'CMSApp v2021');
      this.router.navigateByUrl('employeelist');
    });
  }
}
