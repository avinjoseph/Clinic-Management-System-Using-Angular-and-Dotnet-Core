import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Payment } from '../shared/payment';
import { PaymentService } from './../shared/payment.service';
@Component({
  selector: 'app-paymentlist',
  templateUrl: './paymentlist.component.html',
  styleUrls: ['./paymentlist.component.scss'],
})
export class PaymentlistComponent implements OnInit {
  page: number = 1;
  filter: string;
  constructor(
    public payService: PaymentService,
    private toastr: ToastrService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.payService.bindListPayments();
  }
  reloadSearch() { 
      window.location.reload(); 
   }
  populateForm(payment: Payment) {
    console.log(payment);
    this.payService.formData = Object.assign({}, payment);
  }
  //update
  updatePayment(payId: number) {
    console.log(payId);
    this.router.navigate(['payment', payId]);
  }
}
