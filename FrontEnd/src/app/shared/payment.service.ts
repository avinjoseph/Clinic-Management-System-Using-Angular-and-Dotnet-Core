import { Patient } from './patient';
import { Payment } from './payment';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class PaymentService {
  formData:Payment=new Payment();
  patients:Patient[];
  payments: Payment[];
  constructor(private httpClient:HttpClient) { }
 
  //get patients for binding
  BindCmbPatients() {
    this.httpClient
      .get(environment.apiUrl + '/api/patient')
      .toPromise()
      .then((response) => (this.patients = response as Patient[]));
      console.log(this.patients);
  }
  
  //insert a employee
  insertPayment(payment: Payment):Observable<any> {
    return this.httpClient.post(environment.apiUrl+"/api/payment",payment);


  }
  updatePayment(payment: Payment):Observable<any> {
    return this.httpClient.put(environment.apiUrl+"/api/payment",payment);
    

  }
  //get all Payment
  bindListPayments(){
    this.httpClient.get(environment.apiUrl+"/api/payment")
    .toPromise().then((response )=> 
    this.payments= response as Payment[]);
  }
  //particular employee from

  getPaymentPatientId(patientId: number): Observable<any> {

    return this.httpClient.get(

      environment.apiUrl + '/api/payment/id?' + patientId

    );

  }
  getPaymentById(payId: number): Observable<any> {

    return this.httpClient.get(

      environment.apiUrl + '/api/payment/' + payId

    );

  }
}
