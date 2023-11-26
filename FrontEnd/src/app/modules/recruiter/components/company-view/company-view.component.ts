import { Component } from '@angular/core';
import { getRequest } from 'src/app/service/api-requests';
import { AuthorizationMode, apiRecruiter } from 'src/app/service/constant';
import { getProfile } from 'src/app/service/localstorage';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-company-view',
  templateUrl: './company-view.component.html',
  styleUrls: ['./company-view.component.css']
})
export class CompanyViewComponent {
  company:any;
  Url = environment.Url;
  linkMap:any;
  htmlContent:any;
  profile: any;

  constructor() {
    this.profile = getProfile();
    getRequest(apiRecruiter.GET_COMPANY_BY_ID + "/" + this.profile.id, AuthorizationMode.PUBLIC)
    .then(res => {
       this.company = res?.data
       this.htmlContent = this.company?.description;
       console.log(this.company)
    })
    .catch(data => {
       console.warn("Get API fail!" + data);
    })
  }

  onClickView(jd:any){
    
  }
}
