import { Patient } from './../shared/patient';
import { PrescriptionHistory } from './../shared/prescription-history';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PrescriptionService } from '../shared/prescription.service';
import { DoctornotesService } from '../doctornotes.service';
import {Location} from '@angular/common';

@Component({
  selector: 'app-prescription-history',
  templateUrl: './prescription-history.component.html',
  styleUrls: ['./prescription-history.component.scss'],
})
export class PrescriptionHistoryComponent implements OnInit {
  prescriptionList: PrescriptionHistory[];
  patientId: number;
  page: number = 1;
  filter: string;
  patientName: string;
  constructor(
    private router: Router,
    private route: ActivatedRoute,
    public doctornoteService: DoctornotesService,
    public prescriptionService: PrescriptionService,
    private location: Location
  ) {}

  ngOnInit(): void {
    this.patientId = this.route.snapshot.params['patientId'];
    this.prescriptionService.GetAllPrescription(this.patientId);
    this.doctornoteService.GetPatientById(this.patientId).subscribe((data) => {
      this.patientName = data.PatientName;
    });
  }

  goBack() {
    this.location.back();
  }
}
