import { TestReportService } from './../shared/test-report.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../shared/auth.service';

@Component({
  selector: 'app-testreports-list',
  templateUrl: './testreports-list.component.html',
  styleUrls: ['./testreports-list.component.scss']
})
export class TestreportsListComponent implements OnInit {

  empId:number;
  page: number = 1;
  filter: string;
  atId: number;
  constructor(
    public testReportService:TestReportService ,
    private route: ActivatedRoute,
    public toastrservice: ToastrService,
    public authService: AuthService,
    private router: Router
    ) { }

  ngOnInit(): void {
    this.empId =  this.route.snapshot.params['empId'];
    console.log(this.empId);
    this.testReportService.getLabRecords(this.empId);
  }

  logout() {
    this.authService.logout();
    this.router.navigateByUrl('login');
  }

  // navigate to view lab result
  viewLabReport(empId: number,testReportId:number) {
    console.log(empId);
    console.log(testReportId);
    this.testReportService.toggleReadOnlyMode(true);
    this.router.navigate(['testreport',empId,testReportId]);
  }
}
