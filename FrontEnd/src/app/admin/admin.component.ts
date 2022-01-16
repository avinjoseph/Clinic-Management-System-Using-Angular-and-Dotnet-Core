import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../shared/auth.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss'],
})
export class AdminComponent implements OnInit {
  loggedUserName: string;
  empId: number;
  constructor(private authService: AuthService, private router: Router) {}

  ngOnInit(): void {
    this.loggedUserName = localStorage.getItem('name');
    this.empId = parseInt(localStorage.getItem('empId'));
  }

  logout() {
    this.authService.logout();
    this.router.navigateByUrl('login');
  }
  addAnnouncement() {
    this.router.navigate(['announcement', this.empId]);
  }
}
