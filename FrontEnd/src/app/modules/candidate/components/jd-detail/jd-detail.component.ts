import { Component, ViewEncapsulation } from '@angular/core';
import { getRequest, postRequest } from 'src/app/service/api-requests';
import { AuthorizationMode, apiCandidate } from 'src/app/service/constant';
import { ActivatedRoute } from '@angular/router';
import { environment } from 'src/environments/environment';
@Component({
  selector: 'app-jd-detail',
  templateUrl: './jd-detail.component.html',
  styleUrls: ['./jd-detail.component.css'],
  encapsulation: ViewEncapsulation.None
})

export class JdDetailComponent {

  jd:any;

  constructor(private route: ActivatedRoute){
    let id: any;
    this.route.params.subscribe(params => {
      id = params['id'];
    });

    getRequest(apiCandidate.GET_JD_BY_ID, AuthorizationMode.PUBLIC, {jdId: id})
    .then(res => {
       this.jd = res?.data
      console.log(this.jd);
      

       
    })
    .catch(data => {
       console.warn(apiCandidate.GET_JD_BY_ID, AuthorizationMode.PUBLIC, data);
    })
  }
}
