import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Employee } from '../shared/employee';
import { EmployeeService } from '../shared/employee.service';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.scss'],
})
export class EmployeeListComponent implements OnInit {
  //assign default page number
  page: number = 1;
  filter: string;
  constructor(
    public empService: EmployeeService,
    private toastr: ToastrService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.empService.getAllEmployee();
  }

  //populate form by clicking the cloumn
  populateForm(emp: Employee) {
    console.log(emp);
    //date format
    var datePipe = new DatePipe('en-UK');
    let formatDate: any = datePipe.transform(emp.DateOfJoining, 'yyyy-MM-dd');
    emp.DateOfJoining = formatDate;
    this.empService.formData = Object.assign({}, emp);
  }

  //delete employee
  deleteEmployee(empId: number) {
    if (confirm('Are you sure to delete?')) {
      this.empService.deleteEmployee(empId).subscribe(
        (data) => {
          console.log(data);
          this.empService.getAllEmployee();
          this.toastr.success('Employee deleted', 'EmpApp v2021');
        },
        (error) => {
          console.log(error);
        }
      );
    } else {
      window.location.reload();
    }
  }

  updateEmployee(empId: number) {
    console.log(empId);
    this.router.navigate(['employee', empId]);
  }
}
