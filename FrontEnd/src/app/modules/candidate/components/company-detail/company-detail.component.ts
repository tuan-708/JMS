import { Component } from '@angular/core';
import { getRequest, postRequest } from 'src/app/service/api-requests';
import { AuthorizationMode, apiRecruiter } from 'src/app/service/constant';
import { ActivatedRoute } from '@angular/router';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-company-detail',
  templateUrl: './company-detail.component.html',
  styleUrls: ['./company-detail.component.css']
})
export class CompanyDetailComponent {
  company: any;
  Url = environment.Url;
  linkMap: any;
  htmlContent: any;
  countJob: number = 0

  constructor(private route: ActivatedRoute) {
    let id: any;
    this.route.params.subscribe(params => {
      id = params['id'];
    });

    getRequest(apiRecruiter.GET_COMPANY_BY_ID + "/" + id, AuthorizationMode.PUBLIC)
      .then(res => {
        if (res?.statusCode == 200) {
          this.company = res?.data
          this.countJob = this.company?.jDs.length
          this.htmlContent = this.company?.description;
        }
      })
      .catch(data => {
        console.warn(apiRecruiter.GET_COMPANY_BY_ID + "/" + id, AuthorizationMode.PUBLIC);
      })
  }
}
