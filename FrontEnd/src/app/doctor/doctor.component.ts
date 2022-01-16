import { DoctorService } from './../shared/doctor.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../shared/auth.service';
import { PrescriptionService } from '../shared/prescription.service';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-doctor',
  templateUrl: './doctor.component.html',
  styleUrls: ['./doctor.component.scss'],
})
export class DoctorComponent implements OnInit {
  empId: number;
  page: number = 1;
  filter: string;
  atId: number;
  date: Date = new Date();
  docId: number;
  patientId: number;
  prescriptionDate: Date = new Date();
  preId: number;
  appointmentId: number;
  constructor(
    private route: ActivatedRoute,
    public doctorService: DoctorService,
    public toastrservice: ToastrService,
    private router: Router,
    public authService: AuthService,
    public preService: PrescriptionService
  ) {}

  ngOnInit(): void {
    //window.location.reload();
    var datePipe = new DatePipe('en-UK');
    let formatDate: any = datePipe.transform(this.date, 'yyyy-MM-dd');
    this.date = formatDate;
    this.empId = this.route.snapshot.params['empId'];
    this.doctorService.GetAllPatientsOfDoctor(this.empId);
    // this.preService.GetPrescriptionByDate(this.date).subscribe((data) => {
    //   console.log(data);
    //   var datePipe = new DatePipe('en-UK');
    //   let formatDate: any = datePipe.transform(
    //     data.PrescriptionDate,
    //     'yyyy-MM-dd'
    //   );
    //   this.prescriptionDate = formatDate;
    //   this.docId = this.empId;
    //   this.patientId = data.PatientId;
    //   this.preId = data.PrescriptionId;
    // });
  }

  AddPrescription(id: number, appointmentId: number) {
    console.log(id, this.empId);
    this.appointmentId = appointmentId;
    this.router.navigate(['prescription', id, this.empId, appointmentId, 2]);
  }

  logout() {
    this.authService.logout();
    this.router.navigateByUrl('login');
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
          this.doctorService.GetAllPatientsOfDoctor(this.empId);
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

  //to enable or diasable the button
  isDisabled(status: boolean): boolean {
    if (status) {
      return true;
    } else {
      return false;
    }
  }
  ViewHistory(patientId: number){
    this.router.navigate(['prescription-history', patientId]);

  }

  ViewLabResults(patientId: number, appointmentId: number) {
    console.log(patientId);
    this.router.navigate(['labresults', patientId, this.empId, appointmentId]);
  }
}
