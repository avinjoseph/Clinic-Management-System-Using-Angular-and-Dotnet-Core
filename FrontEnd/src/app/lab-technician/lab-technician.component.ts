import { LabtechnicianService } from './../shared/labtechnician.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../shared/auth.service';

@Component({
  selector: 'app-lab-technician',
  templateUrl: './lab-technician.component.html',
  styleUrls: ['./lab-technician.component.scss'],
})
export class LabTechnicianComponent implements OnInit {
  empId: number;
  userName: string;

  constructor(
    private route: ActivatedRoute,
    private authService: AuthService,
    public labTechnicianService: LabtechnicianService,
    public toastrservice: ToastrService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.empId = this.route.snapshot.params['empId'];
    this.labTechnicianService.getLabTechnicianData(this.empId);
    this.userName = localStorage.getItem('name');
  }

  logout() {
    this.authService.logout();
    this.router.navigateByUrl('login');
  }

  viewAppointments() {
    this.router.navigate(['appoinmentlist', this.empId]);
  }

  viewLabRecords() {
    this.router.navigate(['testreportlist',this.empId]);
  }
}
