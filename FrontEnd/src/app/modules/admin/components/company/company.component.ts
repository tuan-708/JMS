import { Component } from '@angular/core';

@Component({
  selector: 'app-company',
  templateUrl: './company.component.html',
  styleUrls: ['./company.component.css']
})
export class CompanyComponent {
  companies = [
    { id: 'E001', name: 'ABC Company', location: 'Ha Noi', industry: 'Technology', dateCreated: '12:00:00 12/12/2022', admin: 'Nguyen Van An', totalPost: 125 },
    { id: 'E002', name: 'ABC Company', location: 'Ha Noi', industry: 'Technology', dateCreated: '12:00:00 12/12/2022', admin: 'Nguyen Van An', totalPost: 125 },
    { id: 'E003', name: 'ABC Company', location: 'Ha Noi', industry: 'Technology', dateCreated: '12:00:00 12/12/2022', admin: 'Nguyen Van An', totalPost: 125 },
    { id: 'E004', name: 'ABC Company', location: 'Ha Noi', industry: 'Technology', dateCreated: '12:00:00 12/12/2022', admin: 'Nguyen Van An', totalPost: 125 },
    { id: 'E005', name: 'ABC Company', location: 'Ha Noi', industry: 'Technology', dateCreated: '12:00:00 12/12/2022', admin: 'Nguyen Van An', totalPost: 125 }
  ]
}
