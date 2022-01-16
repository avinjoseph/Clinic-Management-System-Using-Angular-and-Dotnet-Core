import { Labtechnician } from './../shared/labtechnician';
import { EmployeeService } from './../shared/employee.service';
import { PatientService } from './../shared/patient.service';
import { TestReportService } from './../shared/test-report.service';
import { ToastrService } from 'ngx-toastr';
import { TestReport } from './../shared/test-report';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { DatePipe } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'app-testreport',
  templateUrl: './testreport.component.html',
  styleUrls: ['./testreport.component.scss'],
})
export class TestreportComponent implements OnInit {
  employeeId: number;
  testReportId: number;
  testReport: TestReport = new TestReport();
  constructor(
    public testReportService: TestReportService,
    private toastr: ToastrService,
    private router: Router,
    private route: ActivatedRoute,
    public patientService: PatientService,
    public empService: EmployeeService
  ) {}

  ngOnInit(): void {
    this.testReportId = this.route.snapshot.params['testReportId'];
    this.employeeId = this.route.snapshot.params['empId'];
    this.patientService.GetAllPatients();
    this.testReportService.getDoctors();
    if (this.testReportId != 0 || this.testReportId != null) {
      //get test report
      this.testReportService.getTestReportById(this.testReportId).subscribe(
        (data) => {
          console.log('test report component');
          console.log(data);
          //date format
          var datePipe = new DatePipe('en-UK');
          let formatDate: any = datePipe.transform(
            data.ReportGeneratedDate,
            'yyyy-MM-dd'
          );
          data.ReportGeneratedDate = formatDate;
          this.testReportService.newTestReport = data;
        },
        (error) => console.log(error)
      );
    }
  }

  //onSubmit function
  onSubmit(form: NgForm) {
    console.log(form.value);
    let addId = this.testReportService.newTestReport.TestReportId;
    //insert
    if (addId == 0 || addId == null) {
      form.value.LabtechnicianId = this.employeeId;
      this.insertTestReport(form);
    }
    // else {
    //   console.log('updating record');
    //   this.updateEmployee(form);
    // }
  }

  //clear all contents and Initialization
  resetForm(from?: NgForm) {
    if (from != null) {
      from.reset();
      this.router.navigate(['testreportlist', this.employeeId]);
    }
  }

  //Insert
  insertTestReport(form?: NgForm) {
    console.log('Inserting a record...');
    this.testReportService.insertTestReport(form.value).subscribe((data) => {
      console.log(data);
      this.toastr.success('Test Report added', 'CMSApp v2021');
      //this.resetForm(form);
      this.router.navigate(['labtechnician', this.employeeId]);
    });
  }

  //Update
  // updateTestReport(form?: NgForm) {
  //   console.log('updating a record...');
  //   this.testReportService.updateTestReport(form.value).subscribe((data) => {
  //     console.log(data);
  //     this.resetForm(form);
  //     this.toastr.success('TestReport updated', 'CMSApp v2021');
  //     this.router.navigateByUrl('testreportlist');
  //   });
  // }
}
