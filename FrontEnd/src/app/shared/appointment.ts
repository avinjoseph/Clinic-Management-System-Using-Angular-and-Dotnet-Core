// import { Appointmenttypes } from './appointmenttypes';

// import { Employee } from './employee';
// import { Patient } from './patient';
export class Appointment {
  AppointmentId: number;
  AppointmentDate: Date = new Date();
  PatientId: number;
  EmployeeId: number;
  AppointmentStatus: boolean;
  AppointmentTypeId: number;

  // //object oriented model
  // Patient:Patient;
  // Employee:Employee;
  // Appointmenttypes:Appointmenttypes;
}
