import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../shared/auth.service';
import { DoctorService } from '../shared/doctor.service';
import { PrescriptionService } from '../shared/prescription.service';
import { TestReport } from '../shared/test-report';
import { TestReportService } from '../shared/test-report.service';
import { Testreportmodel } from '../shared/testreportmodel';

@Component({
  selector: 'app-labresults',
  templateUrl: './labresults.component.html',
  styleUrls: ['./labresults.component.scss'],
})
export class LabresultsComponent implements OnInit {
  patientId: number;
  empId: number;
  report: Testreportmodel[];
  appointmentId: number;
  constructor(
    private route: ActivatedRoute,
    public doctorService: DoctorService,
    public toastrservice: ToastrService,
    private router: Router,
    public authService: AuthService,
    public preService: PrescriptionService,
    public testService: TestReportService
  ) {}

  ngOnInit(): void {
    this.patientId = this.route.snapshot.params['patientId'];
    this.empId = this.route.snapshot.params['empId'];
    this.appointmentId = this.route.snapshot.params['appointmentId'];
    console.log('appointment :' + this.appointmentId);
    console.log('test :' + this.patientId);
    
    //this.preId = this.route.snapshot.params['preId'];
    this.testService.getTestReport(this.patientId).subscribe((data) => {
      this.report = data;
      console.log(this.report);
    });
    //this.report = this.testService.testReports;
    //console.log('test 2');
    //console.log(this.report);
    //console.log('hi hi hi\n' + this.testService.testReports);

    //this.report = this.testService.testReports;
    //console.log('hi hi hi\n' + this.testService.testReports);
  }

  onSubmit() {
    this.router.navigate([
      'doctornotes',
      this.patientId,
      this.empId,
      this.appointmentId,
    ]);
  }
}
