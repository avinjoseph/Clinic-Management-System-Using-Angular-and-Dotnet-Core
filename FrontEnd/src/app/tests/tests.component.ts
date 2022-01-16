import { Tests } from './../shared/tests';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../shared/auth.service';
import { LabtechnicianService } from '../shared/labtechnician.service';
import { TestReportService } from '../shared/test-report.service';
import { NgForm } from '@angular/forms';
import { DatePipe } from '@angular/common';
import { PrescriptionService } from '../shared/prescription.service';
import { AppointmentService } from '../shared/appointment.service';

@Component({
  selector: 'app-tests',
  templateUrl: './tests.component.html',
  styleUrls: ['./tests.component.scss'],
})
export class TestsComponent implements OnInit {
  patientId: number;
  aId: number;
  prescribedTests: Array<string>;
  date: Date = new Date();
  tests: Tests = new Tests();
  constructor(
    private toastr: ToastrService,
    private route: ActivatedRoute,
    public toastrservice: ToastrService,
    private router: Router,
    public authService: AuthService,
    public labTechnicianService: LabtechnicianService,
    public testReportService: TestReportService,
    public preService: PrescriptionService,
    public appService: AppointmentService
  ) {}

  ngOnInit(): void {
    this.patientId = this.route.snapshot.params['patientId'];
    this.aId = this.route.snapshot.params['aId'];
    this.labTechnicianService.getTests(this.patientId);
    this.preService.GetPrescriptionByPatientId(this.patientId).subscribe(
      (data) => {
        console.log(data);
        this.tests = data;
        let afterJson = JSON.parse(data.Tests);
        this.prescribedTests = afterJson['tests'];
        console.log(afterJson);
        console.log(this.prescribedTests);
      },
      (error) => console.log(error)
    );
    //console.log(this.labTechnicianService.tests.Tests);

    var datePipe = new DatePipe('en-UK');
    let formatDate: any = datePipe.transform(this.date, 'yyyy-MM-dd');
    this.date = formatDate;
  }

  //onSubmit function
  onSubmit(form: NgForm) {
    console.log(form.value);
    let addId = this.labTechnicianService.testForm.TestReportId;
    //insert
    if (addId == 0 || addId == null) {
      this.insertTestReport(form);
    }
  }

  updateStatus(id: number) {
    this.appService.UpdateStatus(id).subscribe(
      (data) => {
        this.toastr.success('Appointment Status Updated', 'CMSApp v2021');
      },
      (error) => {
        console.log(error);
      }
    );
  }

  insertTestReport(form: NgForm) {
    form.value.ReportGeneratedDate = this.date;
    form.value.PatientId = this.patientId;
    form.value.DoctorId = this.tests.DoctorId;
    form.value.LabTechnicianId = 2;
    console.log('form values');
    console.log(form.value);
    this.labTechnicianService.insertTestReport(form.value).subscribe((data) => {
      console.log(data);
      this.toastr.success('report added', 'CMSApp v2021');
      this.updateStatus(this.aId);
      this.router.navigate(['labtechnician', 2]);
    });
  }
}
