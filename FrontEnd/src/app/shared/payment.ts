export class Payment {
  PaymentId: number = 0;
  Amount: number;
  PatientId: number;
  PaymentDate: Date = new Date();
  status: string;
}
