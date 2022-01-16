import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Appointment } from './appointment';
import { Doctor } from './doctor';
import { Employee } from './employee';
import { Patient } from './patient';

@Injectable({
  providedIn: 'root',
})
export class AppointmentService {
  //create instance
  formData: Appointment = new Appointment();
  appointments: Doctor[];
  employees: Employee[];
  patients: Patient[];
  constructor(private httpClient: HttpClient, private toastr: ToastrService) {}

  //Get all doctors
  GetAllDoctors(id: number) {
    this.httpClient
      .get(environment.apiUrl + '/api/employee/' + id)
      .toPromise()
      .then((response) => (this.employees = response as Employee[]));
    console.log(this.employees);
  }

  //GET patients for binding
  GetAllPatients() {
    this.httpClient
      .get(environment.apiUrl + '/api/patient/get')
      .toPromise()
      .then((response) => (this.patients = response as Patient[]));
    console.log(this.patients);
  }

  labAppoinment(id: number, date: Date, atId: number) {
    console.log('app service');
    this.formData.PatientId = id;
    this.formData.EmployeeId = atId;
    this.formData.AppointmentTypeId = atId;
    this.formData.AppointmentStatus = true;
    this.formData.AppointmentDate = date;
    this.InsertAppoinment(this.formData).subscribe((data) => {
      console.log(data);
      this.toastr.success('Lab Appointment added', 'CMSApp v2021');
    });
  }
  //Add appointment i.e insert appointment
  InsertAppoinment(appointment: Appointment): Observable<any> {
    console.log(appointment);
    return this.httpClient.post(
      environment.apiUrl + '/api/appointment',
      appointment
    );
  }

  //Update Appointment
  UpdateAppointment(appointment: Appointment): Observable<any> {
    return this.httpClient.put(
      environment.apiUrl + '/api/appointment',
      appointment
    );
  }

  //View all appointments
  GetAllAppoinments() {
    this.httpClient
      .get(environment.apiUrl + '/api/appointment')
      .toPromise()
      .then((response) => (this.appointments = response as Doctor[]));
  }

  //View all appointments by date
  GetAllAppointmentsByDate(appDate: Date): Observable<any> {
    return this.httpClient.get(
      environment.apiUrl + '/api/appointment/' + appDate
    );
  }

  //view all appointments by doctor
  GetAllAppointmentsByDoctor(empId: number): Observable<any> {
    return this.httpClient.get(
      environment.apiUrl + '/api/appointment/' + empId
    );
  }

  UpdateStatus(id: number): Observable<any> {
    return this.httpClient.delete(
      environment.apiUrl + '/api/appointment/' + id
    );
  }
}
