import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { PageEvent } from '@angular/material/paginator';
import { getRequest } from 'src/app/service/api-requests';
import { AuthorizationMode, apiAdmin } from 'src/app/service/constant';

@Component({
  selector: 'app-recruiter',
  templateUrl: './recruiter.component.html',
  styleUrls: ['./recruiter.component.css']
})
export class RecruiterComponent {
  recruiters: any
  searchText: any = ''
  pageIndex: any = 0
  pageSize: any = 10
  listDisplay: any

  constructor(public dialog: MatDialog) {
    this.getListRecruiter();
  }

  getListRecruiter() {
    getRequest(apiAdmin.GET_ALL_RECRUITER, AuthorizationMode.PUBLIC)
      .then(res => {
        this.recruiters = res?.data
        console.log(this.recruiters);
        
        this.getPageRange()
      })
      .catch(data => {
        console.warn("Call API GET RECRUITERS Fail:" + data)
      })
  }

  handlePage(e: PageEvent) {
    this.pageSize = e.pageSize;
    this.pageIndex = e.pageIndex;
    this.getPageRange();
  }

  getPageRange() {
    const start = this.pageIndex * this.pageSize;
    const end = Math.min((this.pageIndex + 1) * this.pageSize, this.recruiters.length);
    this.listDisplay = this.recruiters.slice(start, end)
  }

  onInputChange() {
    try {
      if (this.searchText.length != 0) {
        this.listDisplay = this.recruiters.filter((obj: { name: string | any[]; }) => obj?.name.includes(this.searchText));
      } else {
        this.getPageRange()
      }
    } catch (error) {
      console.warn('Fail in search:' + error)
    }
  }
}
