import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../shared/auth.service';

@Component({
  selector: 'app-receptionist',
  templateUrl: './receptionist.component.html',
  styleUrls: ['./receptionist.component.scss'],
})
export class ReceptionistComponent implements OnInit {
  loggedUserName: string;
  empId: number;
  constructor(
    private authService: AuthService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.loggedUserName = localStorage.getItem('name');
    this.empId = this.route.snapshot.params['empId'];
  }
  logOut() {
    this.authService.logout();
    this.router.navigateByUrl('login');
  }
}
