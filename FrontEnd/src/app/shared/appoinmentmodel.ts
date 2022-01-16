export class Appoinmentmodel {
  AppointmentId: number;
  PatientId: number;
  AppointmentType: string;
  PatientName: string;
  Age: number;
  MobileNo: number;
  Gender: string;
  Address: string;
  EmployeeId: number;
  EmployeeName: string;
  AppointmentStatus: boolean;
  AppointmentDate: Date = new Date();
}
