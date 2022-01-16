import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Patient } from './patient';

@Injectable({
  providedIn: 'root',
})
export class PatientService {
  formData: Patient = new Patient();
  patients: Patient[];

  constructor(private httpClient: HttpClient) {}

  //InsertPatient
  InsertPatient(patient: Patient): Observable<any> {
    return this.httpClient.post(environment.apiUrl + '/api/patient', patient);
  }

  //UpdatePatient
  UpdatePatient(patient: Patient): Observable<any> {
    return this.httpClient.put(environment.apiUrl + '/api/patient', patient);
  }

  //get all patients
  GetAllPatients() {
    this.httpClient
      .get(environment.apiUrl + '/api/patient')
      .toPromise()
      .then((response) => (this.patients = response as Patient[]));
    console.log(this.patients);
  }

  //get patient by id
  GetPatientById(Id: number): Observable<any> {
    return this.httpClient.get(
      environment.apiUrl + '/api/patient/ViewPatientById?id=' + Id
    );
  }

  //get all patient by date
  GetAllPatientByDate(date: Date): Observable<any> {
    return this.httpClient.get(environment.apiUrl + '/api/patient/' + date);
  }
  deleteappointment(id: number) {
    return this.httpClient.delete(environment.apiUrl + '/api/appoinment/' + id);
  }
}
