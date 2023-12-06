import { Component } from '@angular/core';
import { getRequest } from 'src/app/service/api-requests';
import { AuthorizationMode, apiAdmin, apiRecruiter } from 'src/app/service/constant';
import { NgModel } from '@angular/forms';
import { PageEvent } from '@angular/material/paginator';
import { MatDialog } from '@angular/material/dialog';
import { CompanyViewComponent } from '../company-view/company-view.component';

@Component({
  selector: 'app-company',
  templateUrl: './company.component.html',
  styleUrls: ['./company.component.css']
})
export class CompanyComponent {

  companies: any
  searchText: any = ''
  pageIndex: any = 0
  pageSize: any = 10
  listDisplay: any

  constructor(public dialog: MatDialog) {
    this.getListCompany();
  }

  getListCompany() {
    getRequest(apiAdmin.GET_ALL_COMPANY, AuthorizationMode.PUBLIC)
      .then(res => {
        this.companies = res?.data
        console.log(this.companies)
        this.getPageRange()
      })
      .catch(data => {
        console.warn("Call API GET COMPANY Fail:" + data)
      })
  }

  handlePage(e: PageEvent) {
    this.pageSize = e.pageSize;
    this.pageIndex = e.pageIndex;
    this.getPageRange();
  }

  getPageRange() {
    const start = this.pageIndex * this.pageSize;
    const end = Math.min((this.pageIndex + 1) * this.pageSize, this.companies.length);
    this.listDisplay = this.companies.slice(start, end)
  }

  onInputChange() {
    try {
      if (this.searchText.length != 0) {
        this.listDisplay = this.companies.filter((obj: { name: string | any[]; }) => obj?.name.includes(this.searchText));
      } else {
        this.getPageRange()
      }
    } catch (error) {
      console.warn('Fail in search:' + error)
    }
  }

  openCompanyDialog(id: any): void {
    this.dialog.open(CompanyViewComponent, {
      width: '80%',
      height: '90%',
      data: id
    });
  }
}
