import { Doctor } from './doctor';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class DoctorService {
  //create an instance
  patients: Doctor[];
  constructor(private httpClient: HttpClient) {}

  GetAllPatientsOfDoctor(id: number) {
    this.httpClient
      .get(environment.apiUrl + '/api/appointment/GetByDoctor?id=' + id)
      .toPromise()
      .then((response) => (this.patients = response as Doctor[]));
    console.log(this.patients);
  }

  //delete a appointment by doctor
  deleteappointment(id: number) {
    return this.httpClient.delete(
      environment.apiUrl + '/api/appointment/' + id
    );
  }
}
