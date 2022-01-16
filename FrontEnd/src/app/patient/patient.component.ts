import { PatientService } from './../shared/patient.service';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute, Router } from '@angular/router';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-patient',
  templateUrl: './patient.component.html',
  styleUrls: ['./patient.component.scss'],
})
export class PatientComponent implements OnInit {
  patientId: number;
  constructor(
    public patientService: PatientService,
    private toastrService: ToastrService,
    public router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    //get patientId from activated route
    this.patientId = this.route.snapshot.params['patientId'];
    //this.resetform();
    if (this.patientId != 0 || this.patientId != null) {
      //get employee
      this.patientService.GetPatientById(this.patientId).subscribe(
        (data) => {
          console.log(data);
          this.patientService.formData = data;
        },
        (error) => console.log(error)
      );
    }
  }

  onSubmit(form: NgForm) {
    console.log(form.value);

    let addId = this.patientService.formData.PatientId;

    if (addId == 0 || addId == null) {
      //Insert
      this.InsertPatientRecord(form);
    } else {
      //Update
      console.log('Updating record...');
      this.UpdatePatientRecord(form);
    }
  }

  //Clear all content at Initialization
  resetForm(form?: NgForm) {
    if (form != null) {
      form.resetForm();
    }
  }

  //Insert
  InsertPatientRecord(form?: NgForm) {
    console.log('Inserting a record...');
    form.value.IsActive = true;
    this.patientService.InsertPatient(form.value).subscribe((result) => {
      console.log(result);
      this.resetForm(form);
      this.toastrService.success(
        'Patient record has been inserted',
        'ClinicApp v2021'
      );

      this.router.navigate(['appointments', result]);
    });
    //window.location.reload();
  }

  //Update
  UpdatePatientRecord(form?: NgForm) {
    console.log('Updating a record...');
    this.patientService.UpdatePatient(form.value).subscribe((result) => {
      console.log(result);
      //this.resetForm(form);
      this.toastrService.success(
        'Patient record has been updated',
        'ClinicApp v2021'
      );
      this.router.navigateByUrl('patientlist');
    });
    //window.location.reload();
  }
}
