import { AppointmentService } from './../shared/appointment.service';
import { PatientService } from './../shared/patient.service';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute, Router } from '@angular/router';
import { Patient } from '../shared/patient';
import { DoctorService } from '../shared/doctor.service';
import { AuthService } from '../shared/auth.service';

@Component({
  selector: 'app-patientlist',
  templateUrl: './patientlist.component.html',
  styleUrls: ['./patientlist.component.scss'],
})
export class PatientlistComponent implements OnInit {
  empId: number;
  page: number = 1;
  filter: string;

  constructor(
    public appointmentService: AppointmentService,
    public doctorService: DoctorService,
    public toastrservice: ToastrService,
    public router: Router,
    public authService: AuthService
  ) {}

  ngOnInit(): void {
    this.appointmentService.GetAllPatients();
  }

  UpdatePatient(patientId: number) {
    this.router.navigate(['patient', patientId]);
  }

  logout() {
    this.authService.logout();
    this.router.navigateByUrl('login');
  }

  AddAppointment(patientId: number) {
    this.router.navigate(['appointments', patientId]);
  }

  DeleteAppointment(id: number) {
    console.log('cancel the appointment');

    if (
      confirm(
        'Are you sure you want to cancel or you had completed this appointment ? '
      )
    ) {
      this.doctorService.deleteappointment(id).subscribe(
        (result) => {
          console.log(result);
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
