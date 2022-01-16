import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../shared/auth.service';
import { LabtechnicianService } from '../shared/labtechnician.service';
import { TestReportService } from '../shared/test-report.service';

@Component({
  selector: 'app-patientappointments',
  templateUrl: './patientappointments.component.html',
  styleUrls: ['./patientappointments.component.scss'],
})
export class PatientappointmentsComponent implements OnInit {
  empId: number;
  page: number = 1;
  filter: string;
  date: Date = new Date();
  constructor(
    private route: ActivatedRoute,
    public toastrservice: ToastrService,
    private router: Router,
    public authService: AuthService,
    public labTechnicianService: LabtechnicianService,
    public testReportService: TestReportService
  ) {}

  ngOnInit(): void {
    var datePipe = new DatePipe('en-UK');
    let formatDate: any = datePipe.transform(this.date, 'yyyy-MM-dd');
    this.labTechnicianService.getAllPatients();
  }

  addPayment(patientId: number, empId: number) {
    this.router.navigate(['payment', empId, patientId]);
  }

  isDisabled(status: boolean) {
    if (status === true) {
      return true;
    } else {
      return false;
    }
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
          this.toastrservice.success(
            'Appointment record has been deleted',
            'ClinicApp v2021'
          );
          window.location.reload();
        },
        (error) => {
          console.log(error);
        }
      );
    }
  }
}
