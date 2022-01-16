import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AppointmentService } from '../shared/appointment.service';
import { Prescription } from '../shared/prescription';
import { PrescriptionService } from '../shared/prescription.service';

@Component({
  selector: 'app-labtest',
  templateUrl: './labtest.component.html',
  styleUrls: ['./labtest.component.scss']
})
export class LabtestComponent implements OnInit {

  empId: number;
  patientId: number;
  //prescriptionForm:Prescription= new Prescription();
  constructor(
    public preService: PrescriptionService,
    private toastr: ToastrService,
    private router: Router,
    private route: ActivatedRoute,
    public appService: AppointmentService
  ) { }

  ngOnInit(): void {
    this.empId = this.route.snapshot.params['empId'];
    this.patientId = this.route.snapshot.params['patientId'];
  }

}
