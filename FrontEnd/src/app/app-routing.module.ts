import { DoctornotesComponent } from './doctornotes/doctornotes.component';
import { AnnouncementlistComponent } from './announcementlist/announcementlist.component';
import { TestreportsListComponent } from './testreports-list/testreports-list.component';
import { AppointmentsListComponent } from './appointments-list/appointments-list.component';
import { TestreportComponent } from './testreport/testreport.component';
import { AppointmentsComponent } from './appointments/appointments.component';

import { PaymentlistComponent } from './paymentlist/paymentlist.component';
import { AuthGuard } from './shared/auth.guard';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminComponent } from './admin/admin.component';
import { LoginComponent } from './login/login.component';
import { PaymentComponent } from './payment/payment.component';
import { EmployeeComponent } from './employee/employee.component';
import { EmployeeListComponent } from './employee-list/employee-list.component';
import { SpecializationComponent } from './specialization/specialization.component';
import { ReceptionistComponent } from './receptionist/receptionist.component';
import { PatientComponent } from './patient/patient.component';
import { PatientlistComponent } from './patientlist/patientlist.component';
import { SignupComponent } from './signup/signup.component';
import { PrescriptionComponent } from './prescription/prescription.component';
import { DoctorComponent } from './doctor/doctor.component';
import { LabTechnicianComponent } from './lab-technician/lab-technician.component';
import { PatientappointmentsComponent } from './patientappointments/patientappointments.component';
import { LabtestComponent } from './labtest/labtest.component';
import { HomeComponent } from './home/home.component';
import { TestsComponent } from './tests/tests.component';
import { AboutusComponent } from './aboutus/aboutus.component';
import { ContactsComponent } from './contacts/contacts.component';
import { LabresultsComponent } from './labresults/labresults.component';
import { AnnouncementComponent } from './announcement/announcement.component';
import { PrescriptionHistoryComponent } from './prescription-history/prescription-history.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'home', component: HomeComponent },
  { path: 'contacts', component: ContactsComponent },
  {
    path: 'prescription-history/:patientId',
    component: PrescriptionHistoryComponent,
  },
  { path: 'aboutus', component: AboutusComponent },
  // { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'payment', component: PaymentComponent },
  { path: 'paymentlist', component: PaymentlistComponent },
  { path: 'payment/:paymentId', component: PaymentComponent },
  { path: 'payment/:empId/:patientId', component: PaymentComponent },
  { path: 'employee', component: EmployeeComponent },
  { path: 'patient', component: PatientComponent },
  { path: 'patientlist', component: PatientlistComponent },
  { path: 'patient/:patientId', component: PatientComponent },
  { path: 'appointments', component: AppointmentsComponent },
  { path: 'appointments/:patientid', component: AppointmentsComponent },
  {
    path: 'doctornotes/:patientId/:empId/:apId',
    component: DoctornotesComponent,
  },
  { path: 'employee/:empId', component: EmployeeComponent },
  { path: 'employeelist', component: EmployeeListComponent },
  { path: 'specialization/:empId/:roleId', component: SpecializationComponent },
  { path: 'appointments/:patientid', component: AppointmentsComponent },
  { path: 'signup/:empId/:roleId', component: SignupComponent },
  { path: 'prescription/:patientId/:empId', component: PrescriptionComponent },
  { path: 'appoinmentlist/:empId', component: AppointmentsListComponent },
  { path: 'testreportlist/:empId', component: TestreportsListComponent },
  { path: 'tests/:patientId/:aId', component: TestsComponent },
  { path: 'patientappointments', component: PatientappointmentsComponent },
  { path: 'labtest/:patientId/:empId', component: LabtestComponent },
  {
    path: 'labresults/:patientId/:empId/:appointmentId',
    component: LabresultsComponent,
  },
  { path: 'prescription/:patientId/:empId', component: PrescriptionComponent },
  {
    path: 'prescription/:patientId/:empId/:aId',
    component: PrescriptionComponent,
  },
  {
    path: 'prescription/:patientId/:empId/:atId/:id',
    component: PrescriptionComponent,
  },
  { path: 'doctor', component: DoctorComponent },
  {
    path: 'receptionist',
    component: ReceptionistComponent,
    canActivate: [AuthGuard],
    data: { role: '4' },
  },
  {
    path: 'admin',
    component: AdminComponent,
    canActivate: [AuthGuard],
    data: { role: '3' },
  },
  {
    path: 'doctor/:empId',
    component: DoctorComponent,
    canActivate: [AuthGuard],
    data: { role: '1' },
  },
  {
    path: 'labtechnician/:empId',
    component: LabTechnicianComponent,
    canActivate: [AuthGuard],
    data: { role: '2' },
  },
  {
    path: 'testreport/:empId/:testReportId',
    component: TestreportComponent,
  },
  {
    path: 'testreport',
    component: TestreportComponent,
  },
  {
    path: 'announcement',
    component: AnnouncementComponent,
  },
  {
    path: 'announcement/:empId',
    component: AnnouncementComponent,
  },
  {
    path: 'announcementlist',
    component: AnnouncementlistComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
