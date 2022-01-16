import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Announcement } from '../shared/announcement';
import { AnnouncementService } from '../shared/announcement.service';

@Component({
  selector: 'app-announcementlist',
  templateUrl: './announcementlist.component.html',
  styleUrls: ['./announcementlist.component.scss']
})
export class AnnouncementlistComponent implements OnInit {
  page: number = 1;
  filter: string;
  constructor(public announcementService: AnnouncementService,
    private toastr: ToastrService,
    private router: Router) { }

  
  ngOnInit(): void {
    this.announcementService.getAnnouncements();
  }
  reloadSearch() { 
      window.location.reload(); 
   }
  populateForm(announcement:Announcement) {
    console.log(announcement);
    this.announcementService.formData = Object.assign({}, announcement);
  }
}
