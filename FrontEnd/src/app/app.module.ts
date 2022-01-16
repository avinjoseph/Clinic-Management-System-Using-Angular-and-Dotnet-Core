import { AppointmentsListComponent } from './appointments-list/appointments-list.component';
import { TestreportComponent } from './testreport/testreport.component';
import { AppointmentsComponent } from './appointments/appointments.component';
import { AppointmentService } from './shared/appointment.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { EmployeeService } from './shared/employee.service';
import { AuthInterceptor } from './shared/auth.interceptor';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgxPaginationModule } from 'ngx-pagination';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { LoginComponent } from './login/login.component';
import { AdminComponent } from './admin/admin.component';
import { AuthService } from './shared/auth.service';
import { AuthGuard } from './shared/auth.guard';
import { EmployeeComponent } from './employee/employee.component';
import { PaymentComponent } from './payment/payment.component';
import { PaymentlistComponent } from './paymentlist/paymentlist.component';
import { EmployeeListComponent } from './employee-list/employee-list.component';
import { SpecializationComponent } from './specialization/specialization.component';
import { PatientComponent } from './patient/patient.component';
import { ReceptionistComponent } from './receptionist/receptionist.component';
import { PatientService } from './shared/patient.service';
import { PatientlistComponent } from './patientlist/patientlist.component';
import { SignupComponent } from './signup/signup.component';
import { PrescriptionComponent } from './prescription/prescription.component';
import { DoctorComponent } from './doctor/doctor.component';
import { LabTechnicianComponent } from './lab-technician/lab-technician.component';
import { TestreportsListComponent } from './testreports-list/testreports-list.component';
import { NavbarComponent } from './navbar/navbar.component';
import { FooterComponent } from './footer/footer.component';
import { PatientappointmentsComponent } from './patientappointments/patientappointments.component';
import { LabtestComponent } from './labtest/labtest.component';
import { HomeComponent } from './home/home.component';
import { MakepaymentComponent } from './makepayment/makepayment.component';
import { TestsComponent } from './tests/tests.component';
import { AboutusComponent } from './aboutus/aboutus.component';
import { ContactsComponent } from './contacts/contacts.component';
import { LabresultsComponent } from './labresults/labresults.component';
import { AnnouncementComponent } from './announcement/announcement.component';
import { AnnouncementlistComponent } from './announcementlist/announcementlist.component';
import { DoctornotesComponent } from './doctornotes/doctornotes.component';
import { PrescriptionHistoryComponent } from './prescription-history/prescription-history.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    AdminComponent,
    PaymentComponent,
    PaymentlistComponent,
    EmployeeComponent,
    EmployeeListComponent,
    ReceptionistComponent,
    AppointmentsComponent,
    PatientComponent,
    SpecializationComponent,
    PatientlistComponent,
    SignupComponent,
    PrescriptionComponent,
    DoctorComponent,
    TestreportComponent,
    LabTechnicianComponent,
    AppointmentsListComponent,
    TestreportsListComponent,
    NavbarComponent,
    FooterComponent,
    PatientappointmentsComponent,
    LabtestComponent,
    HomeComponent,
    MakepaymentComponent,
    TestsComponent,
    AboutusComponent,
    ContactsComponent,
    LabresultsComponent,
    AnnouncementComponent,
    AnnouncementlistComponent,
    DoctornotesComponent,
    PrescriptionHistoryComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    NgxPaginationModule,
    HttpClientModule,
    BrowserAnimationsModule, // required animations module
    ToastrModule.forRoot(),
    Ng2SearchPipeModule,
    ReactiveFormsModule,
  ],
  providers: [
    EmployeeService,
    AppointmentService,
    PatientService,
    AuthService,
    AuthGuard,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
