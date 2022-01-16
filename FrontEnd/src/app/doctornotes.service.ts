import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Doctornotes } from './shared/doctornotes';
import { Doctornotesmodel } from './shared/doctornotesmodel';

@Injectable({
  providedIn: 'root',
})
export class DoctornotesService {
  notes: Doctornotesmodel[];
  notesForm: Doctornotes = new Doctornotes();
  constructor(private httpClient: HttpClient) {}

  //Add prescription
  AddDoctorNotes(doctornotes: Doctornotes): Observable<any> {
    console.log(doctornotes);
    return this.httpClient.post(
      environment.apiUrl + '/api/doctornotes',
      doctornotes
    );
  }

  //get notes details
  GetNotesById(patientId: number) {
    this.httpClient
      .get(environment.apiUrl + '/api/doctornotes/' + patientId)
      .toPromise()
      .then((response) => (this.notes = response as Doctornotesmodel[]));
  }

  //get prescription details
  GetPatientById(patientId: number): Observable<any> {
    return this.httpClient.get(
      environment.apiUrl + '/api/patient/ViewPatientById?id=' + patientId
    );
  }
}
