import { TestReportService } from './../shared/test-report.service';
import { LabtechnicianService } from './../shared/labtechnician.service';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../shared/auth.service';

@Component({
  selector: 'app-appointments-list',
  templateUrl: './appointments-list.component.html',
  styleUrls: ['./appointments-list.component.scss'],
})
export class AppointmentsListComponent implements OnInit {
  empId: number;
  page: number = 1;
  filter: string;

  constructor(
    private route: ActivatedRoute,
    public toastrservice: ToastrService,
    private router: Router,
    public authService: AuthService,
    public labTechnicianService: LabtechnicianService,
    public testReportService: TestReportService
  ) {}

  ngOnInit(): void {
    this.empId = this.route.snapshot.params['empId'];
    this.labTechnicianService.getAllPatientsOfLabTechnician(this.empId);
  }

  logout() {
    this.authService.logout();
    this.router.navigateByUrl('login');
  }

  isDisabled(status: boolean) {
    if (status) {
      return true;
    } else {
      return false;
    }
  }

  viewPrescribedTests(patientId: number, aId: number) {
    this.router.navigate(['tests', patientId, aId]);
  }

  addLabReport() {
    this.testReportService.resetTestReport();
    this.router.navigate(['testreport', this.empId, 0]);
  }

  deleteAppointment(id: number) {
    console.log('cancel the appointment');

    if (
      confirm(
        'Are you sure you want to cancel or you had completed this appointment ? '
      )
    ) {
      this.labTechnicianService.deleteAppointment(id).subscribe(
        (result) => {
          console.log(result);
          this.labTechnicianService.getAllPatientsOfLabTechnician(this.empId);
          this.toastrservice.success(
            'Appointment record has been deleted',
            'ClinicApp v2021'
          );
        },
        (error) => {
          console.log(error);
        }
      );
    }
  }
}
