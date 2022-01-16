import { Employee } from './employee';
import { Patient } from './patient';
export class Prescription {
  PrescriptionId: number = 0;
  Prescription: string;
  PrescriptionDate: Date = new Date();
  EmployeeId: number;
  PatientId: number;
  Tests: string = '';
  Patient: Patient;
  Employee: Employee;
}
