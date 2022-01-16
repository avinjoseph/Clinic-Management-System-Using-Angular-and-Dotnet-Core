export class PrescriptionHistory {
    PrescriptionId: number = 0;
    Prescription: string;
    PrescriptionDate: Date = new Date();
    DoctorId: number;
    DoctorName: string;
    PatientId: number;
    PatientName: string;
    Tests: string = '';
}
