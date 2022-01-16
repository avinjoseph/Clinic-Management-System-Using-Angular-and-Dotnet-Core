import { LabtechnicianService } from './labtechnician.service';
import { EmployeeService } from './employee.service';
import { PatientService } from './patient.service';
import { Employee } from './employee';
import { Patient } from './patient';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TestReport } from './test-report';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Testreportmodel } from './testreportmodel';

@Injectable({
  providedIn: 'root',
})
export class TestReportService {
  constructor(
    private httpClient: HttpClient,
    public patientService: PatientService,
    public empService: EmployeeService
  ) {}

  // create an instance of TestReport
  testReports: Testreportmodel[];
  newTestReport: TestReport = new TestReport();
  patients: Patient[];
  doctors: Employee[];
  isReadOnly: boolean = false;

  getTestReportsByEmployeeId(id: number) {}

  insertTestReport(testReport: TestReport): Observable<any> {
    return this.httpClient.post(
      environment.apiUrl + '/api/testreport/add',
      testReport
    );
  }

  // get test report by id
  getTestReport(id: number): Observable<any> {
    return this.httpClient.get(
      environment.apiUrl + '/api/testreport/byPatientId?id=' + id
    );
    // .toPromise()
    // .then((response) => {
    //   //console.log(response);
    //   this.testReports = response as Testreportmodel[];
    //   //console.log(this.testReports[0]);
    // });
  }

  getTestReportById(id: number): Observable<any> {
    return this.httpClient.get(
      environment.apiUrl + '/api/testreport/GetTestReportById?id=' + id
    );
  }

  //delete test report
  deleteTestReport(id: number) {
    return this.httpClient.delete(environment.apiUrl + '/api/testreport/' + id);
  }

  // get doctors
  getDoctors() {
    return this.httpClient
      .get(environment.apiUrl + '/api/employee/' + 1)
      .toPromise()
      .then((response) => (this.doctors = response as Employee[]));
  }

  //get all appointments for lab technician

  getLabRecords(id: number) {
    this.httpClient
      .get(environment.apiUrl + '/api/testreport/byemployeeid?id=' + id)
      .toPromise()
      .then((response) => (this.testReports = response as Testreportmodel[]));
    console.log(this.testReports);
  }

  toggleReadOnlyMode(value: boolean) {
    this.isReadOnly = value;
  }

  resetTestReport() {
    this.newTestReport = new TestReport();
    this.toggleReadOnlyMode(false);
  }
}
