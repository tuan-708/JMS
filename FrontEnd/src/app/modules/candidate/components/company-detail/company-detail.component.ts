import { Component  } from '@angular/core';
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
  company:any;
  Url = environment.Url;
  linkMap:any;
  htmlContent:any;

  constructor(private route: ActivatedRoute) {
    let id: any;
    this.route.params.subscribe(params => {
      id = params['id'];
    });

    getRequest(apiRecruiter.GET_COMPANY_BY_ID+"/"+id, AuthorizationMode.PUBLIC)
    .then(res => {
       this.company = res?.data
       const address = "60 ngõ 109 quan nhân hà nội";
       this.htmlContent = this.company?.description;
       this.linkMap =  "https://maps.google.com/maps?width=100%&amp;height=600&amp;hl=en&amp;q=123 Cầu Giấy Hà nội&amp;ie=UTF8&amp;t=&amp;z=18&amp;iwloc=B&amp;output=embed"
      console.log(this.linkMap);
       
    })
    .catch(data => {
       console.warn(apiRecruiter.GET_COMPANY_BY_ID+"/"+id, AuthorizationMode.PUBLIC);
    })
  }
}
