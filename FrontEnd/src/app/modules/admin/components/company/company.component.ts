import { Component } from '@angular/core';
import { getRequest } from 'src/app/service/api-requests';
import { AuthorizationMode, apiRecruiter } from 'src/app/service/constant';
import { NgModel } from '@angular/forms';

@Component({
  selector: 'app-company',
  templateUrl: './company.component.html',
  styleUrls: ['./company.component.css']
})
export class CompanyComponent {
  companiesFake = [
    { id: 'E001', name: 'ABC Company', location: 'Ha Noi', industry: 'Technology', dateCreated: '12:00:00 12/12/2022', admin: 'Nguyen Van An', totalPost: 125 },
    { id: 'E002', name: 'ABC Company', location: 'Ha Noi', industry: 'Technology', dateCreated: '12:00:00 12/12/2022', admin: 'Nguyen Van An', totalPost: 125 },
    { id: 'E003', name: 'ABC Company', location: 'Ha Noi', industry: 'Technology', dateCreated: '12:00:00 12/12/2022', admin: 'Nguyen Van An', totalPost: 125 },
    { id: 'E004', name: 'ABC Company', location: 'Ha Noi', industry: 'Technology', dateCreated: '12:00:00 12/12/2022', admin: 'Nguyen Van An', totalPost: 125 },
    { id: 'E005', name: 'ABC Company', location: 'Ha Noi', industry: 'Technology', dateCreated: '12:00:00 12/12/2022', admin: 'Nguyen Van An', totalPost: 125 }
  ]

companies: any
searchText: any = ''

  constructor(){
    this.getListCompany();
  }

  getListCompany(){
    getRequest(apiRecruiter.GET_COMPANY_PAGING, AuthorizationMode.PUBLIC, { page:1})
      .then(res => {
         this.companies = res?.data
         console.log(this.companies)
      })
      .catch(data => {
        console.warn("Call API GET COMPANY Fail:" + data)
      })
  }
}
