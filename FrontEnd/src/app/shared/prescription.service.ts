import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Employee } from './employee';
import { Patient } from './patient';
import { Prescription } from './prescription';

@Injectable({
  providedIn: 'root',
})
export class PrescriptionService {
  //create instance of Prescription
  prescriptions: Prescription[];
  pres: Prescription;
  patients: Patient[];
  employees: Employee[];
  prescriptionForm: Prescription = new Prescription();

  constructor(private httpClient: HttpClient) {}

  // get all the doctors
  GetAllDoctors() {
    this.httpClient
      .get(environment.apiUrl + '/api/employee')
      .toPromise()
      .then((response) => (this.employees = response as Employee[]));
  }

  //get all patients for binding
  GetAllPatients() {
    this.httpClient
      .get(environment.apiUrl + '/api/patient')
      .toPromise()
      .then((response) => (this.patients = response as Patient[]));
  }

  //get prescription details
  GetPrescriptionDetails() {
    this.httpClient
      .get(environment.apiUrl + '/api/prescriptions')
      .toPromise()
      .then((response) => (this.prescriptions = response as Prescription[]));
  }

  //Add prescription
  AddPrescription(prescription: Prescription): Observable<any> {
    //console.log('hi');
    console.log(prescription);
    return this.httpClient.post(
      environment.apiUrl + '/api/prescription',
      prescription
    );
  }

  //Update Prescription
  UpdatePrescription(prescription: Prescription): Observable<any> {
    return this.httpClient.put(
      environment.apiUrl + '/api/prescription',
      prescription
    );
  }

  //Get all prescription by patient by id
  GetPrescriptionByPatientId(patientId: number): Observable<any> {
    return this.httpClient.get(
      environment.apiUrl + '/api/prescription/test?id=' + patientId
    );
  }

  //Get all prescription by patient by id
  GetPrescriptionById(Id: number): Observable<any> {
    return this.httpClient.get(
      environment.apiUrl + '/api/prescription/reportById?id=' + Id
    );
  }

  // Get all the prescription
  GetAllPrescription(id: number) {
    this.httpClient
      .get(
        environment.apiUrl + '/api/prescription/GetAllPrescriptions?id=' + id
      )
      .toPromise()
      .then((response) => (this.prescriptions = response as Prescription[]));
  }

  //Get all prescription of patient by date
  GetPrescriptionByDate(patientDate: Date): Observable<any> {
    return this.httpClient.get(
      environment.apiUrl + '/api/prescription/' + patientDate
    );
  }

  //Get all prescription of patient by date
  GetPrescriptionForPeriod(patientDate: Date): Observable<any> {
    return this.httpClient.get(
      environment.apiUrl + '/api/prescription/Upto/' + patientDate
    );
  }
}
