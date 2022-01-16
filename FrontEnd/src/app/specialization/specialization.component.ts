import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { EmployeeService } from '../shared/employee.service';

@Component({
  selector: 'app-specialization',
  templateUrl: './specialization.component.html',
  styleUrls: ['./specialization.component.scss'],
})
export class SpecializationComponent implements OnInit {
  empId: number;
  roleId: number;
  constructor(
    public empService: EmployeeService,
    private toastr: ToastrService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.empId = this.route.snapshot.params['empId'];
    this.roleId = this.route.snapshot.params['roleId'];
    this.empService.getSpecializations();
  }

  //onSubmit function
  onSubmit(form: NgForm) {
    console.log(form.value);
    let addId = this.empService.specializationForm.ESId;
    form.value.EmployeeId = this.empId;
    //insert
    if (addId == 0 || addId == null) {
      this.insertSpecialization(form);
    }
  }

  //clear all contents and Initialization
  resetForm(from?: NgForm) {
    if (from != null) {
      from.resetForm();
    }
  }

  //Insert
  insertSpecialization(form?: NgForm) {
    console.log('Iserting a record...');
    this.empService.insertSpecialization(form.value).subscribe((data) => {
      console.log(data);
      this.resetForm(form);
      this.toastr.success('Specialization added', 'CMSApp v2021');
      this.router.navigateByUrl('admin');
      this.router.navigate(['signup', this.empId, this.roleId]);
    });
  }
}
