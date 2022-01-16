import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-contacts',
  templateUrl: './contacts.component.html',
  styleUrls: ['./contacts.component.scss']
})
export class ContactsComponent implements OnInit {

  firstName = "";
  contactNumber = "";
  emailId = "";
  submitted = false;
  emailPattern = "^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$";
  queries = "";
  ContactForm: FormGroup;
  constructor(private formBuilder: FormBuilder, private router: Router,
    private toastr: ToastrService,) { }

  ngOnInit(): void {
    this.ContactForm = this.formBuilder.group(
      {
        firstName: new FormControl(this.firstName, [
          Validators.required,
          Validators.minLength(4)
        ]),
        emailId: new FormControl(this.emailId, [
          Validators.required,
          Validators.minLength(4),
          Validators.maxLength(50),
          Validators.pattern(this.emailPattern)
        ]),
        contactNumber: new FormControl(this.contactNumber, [
          Validators.required,
          Validators.minLength(4)
        ]),
        queries: new FormControl(this.queries, [
          Validators.required,
          Validators.minLength(4)
        ]),
      }
    );
  }

  get f() {
    return this.ContactForm.controls;
  }

  onSubmit() {
    this.submitted = true;
    if (this.ContactForm.invalid) {
      return;
    }
    this.toastr.success('Queries send', 'CMSApp v2021');

    console.log(this.ContactForm.value);

    // const contact: Contact = {
    //   patientId: 1, //Random
    //   firstName: this.ContactForm.value["firstName"],
    //   lastName: this.ContactForm.value["lastName"],
    //   emailId: this.ContactForm.value["emailId"],
    //   password: this.ContactForm.value["password"],
    //   contactNumber: this.ContactForm.value["contactNumber"],
    //   altContactNumber: this.ContactForm.value["altContactNumber"],
    //   securityQuestion: this.ContactForm.value["securityQuestion"],
    //   securityAnswer: this.ContactForm.value["securityAnswer"],
    //   dateOfBirth: new Date(this.ContactForm.value["dateOfBirth"]),
    //   gender: this.ContactForm.value["gender"],
    //   address1: this.ContactForm.value["address1"],
    //   address2: this.ContactForm.value["address2"],
    //   city: this.ContactForm.value["city"],
    //   state: this.ContactForm.value["state"],
    //   zipcode: this.ContactForm.value["zipcode"],
    //   approve: false
    // };
    // this.signUpService.signUpPatient(patient).subscribe(() => {
    //   console.log("Signup successful");
    //   Swal.fire(
    //     "Good job!",
    //     "Sign up successful. You can login once admin approves you.",
    //     "success"
    //   );      this.router.navigateByUrl('/login');
    // }, (err) => console.log("Error!"));
   // console.log("PATIENT :" + patient);
  }

  mustMatch(controlName: string, matchingControlName: string) {
    return (formGroup: FormGroup) => {
      const control = formGroup.controls[controlName];
      const matchingControl = formGroup.controls[matchingControlName];

      if (matchingControl.errors && !matchingControl.errors.mustMatch) {
        // return if another validator has already found an error on the matchingControl
        return;
      }

      // set error on matchingControl if validation fails
      if (control.value !== matchingControl.value) {
        matchingControl.setErrors({ mustMatch: true });
      } else {
        matchingControl.setErrors(null);
      }
    };
  }

}
