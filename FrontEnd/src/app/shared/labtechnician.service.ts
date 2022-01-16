import { Appoinmentmodel } from './appoinmentmodel';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Labtechnician } from './labtechnician';
import { Observable } from 'rxjs';
import { Tests } from './tests';
import { TestReport } from './test-report';

@Injectable({
  providedIn: 'root',
})
export class LabtechnicianService {
  //create an instance
  labTechnician: Labtechnician = new Labtechnician();
  appointments: Appoinmentmodel[];
  tests: Tests = new Tests();
  testForm: TestReport = new TestReport();
  constructor(private httpClient: HttpClient) {}

  getLabTechnicianData(id: number) {
    this.httpClient
      .get(environment.apiUrl + '/api/employee/GetEmployeeById?id=' + id)
      .toPromise()
      .then((response) => (this.labTechnician = response as Labtechnician));
    console.log(this.labTechnician);
    console.log(this.labTechnician.EmployeeId);
  }

  //get all appointments for lab technician

  getAllPatientsOfLabTechnician(id: number) {
    this.httpClient
      .get(environment.apiUrl + '/api/appointment/GetByDoctor?id=' + id)
      .toPromise()
      .then((response) => (this.appointments = response as Appoinmentmodel[]));
    console.log(this.appointments);
  }

  //delete a appointment for lab technician
  deleteAppointment(id: number) {
    return this.httpClient.delete(
      environment.apiUrl + '/api/appointment/delete?id=' + id
    );
  }

  //get tests by id
  getTests(patientId: number) {
    return this.httpClient.get(
      environment.apiUrl + '/api/Prescription/test?id=' + patientId
    );
    // this.httpClient
    //   .get(environment.apiUrl + '/api/Prescription/test?id=' + patientId)
    //   .toPromise()
    //   .then((response) => (this.tests = response as Tests));
    // console.log('hii' + this.tests.PatientId);
  }

  //getAllPatientsFor All doctors
  getAllPatients() {
    this.httpClient
      .get(environment.apiUrl + '/api/appointment/doctor?id=' + 1)
      .toPromise()
      .then((response) => (this.appointments = response as Appoinmentmodel[]));
    console.log(this.appointments);
  }

  //insert employee
  insertTestReport(test: TestReport): Observable<any> {
    return this.httpClient.post(
      environment.apiUrl + '/api/testreport/add',
      test
    );
  }
}
