import { PatientService } from './../shared/patient.service';
import { Doctor } from './../shared/doctor';
import { DoctornotesService } from './../doctornotes.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../shared/auth.service';
import { DoctorService } from '../shared/doctor.service';
import { PrescriptionService } from '../shared/prescription.service';
import { TestReportService } from '../shared/test-report.service';
import { NgForm } from '@angular/forms';
import { DatePipe } from '@angular/common';
import { AppointmentService } from '../shared/appointment.service';

@Component({
  selector: 'app-doctornotes',
  templateUrl: './doctornotes.component.html',
  styleUrls: ['./doctornotes.component.scss'],
})
export class DoctornotesComponent implements OnInit {
  doctorId: number;
  patientId: number;
  apId: number;
  currentDate: Date = new Date();
  page: number = 1;
  filter: string;
  patientName: string;
  constructor(
    private route: ActivatedRoute,
    public doctornoteService: DoctornotesService,
    public patientService: PatientService,
    public toastrservice: ToastrService,
    private router: Router,
    public authService: AuthService,
    public appService: AppointmentService
  ) {}

  ngOnInit(): void {
    this.doctorId = this.route.snapshot.params['empId'];
    this.apId = this.route.snapshot.params['apId'];
    this.patientId = this.route.snapshot.params['patientId'];
    this.doctornoteService.GetNotesById(this.patientId);
    this.doctornoteService.GetPatientById(this.patientId).subscribe((data) => {
      this.patientName = data.PatientName;
    });
    console.log('doctor notes component');
    console.log(this.doctornoteService.notes);
  }

  onSubmit(form: NgForm) {
    let addId = this.doctornoteService.notesForm.NoteId;
    if (addId == 0 || addId == null) {
      this.insertNotes(form);
    }
  }

  //Insert
  insertNotes(form?: NgForm) {
    console.log('Inserting a record...');
    form.value.PatientId = this.patientId;
    form.value.DoctorId = this.doctorId;
    var datePipe = new DatePipe('en-UK');
    let formatDate: any = datePipe.transform(this.currentDate, 'yyyy-MM-dd');
    form.value.NoteDate = formatDate;
    this.doctornoteService.AddDoctorNotes(form.value).subscribe((data) => {
      console.log(data);
      this.toastrservice.success('Note added', 'CMSApp v2021');
    });
    this.updateStatus(this.apId);
    this.router.navigate(['doctor', this.doctorId]);
  }

  updateStatus(id: number) {
    this.appService.UpdateStatus(id).subscribe(
      (data) => {
        this.toastrservice.success(
          'Appointment Status Updated',
          'CMSApp v2021'
        );
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
