import { Component } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { getRequest, postRequest } from 'src/app/service/api-requests';
import { AuthorizationMode, apiRecruiter } from 'src/app/service/constant';

@Component({
   selector: 'app-list-companys',
   templateUrl: './list-companys.component.html',
   styleUrls: ['./list-companys.component.css']
})
export class CandidateListCompanysComponent {
   categories: any;
   companies: any;

   categoryRq = new FormControl('0', [Validators.required, Validators.min(1)]);

   constructor() {
      getRequest(apiRecruiter.GET_ALL_CATEGORY, AuthorizationMode.PUBLIC, { })
      .then(res => {
         this.categories = res?.data
      })
      .catch(data => {
         console.warn(apiRecruiter.GET_ALL_CATEGORY, data);
      })

      getRequest(apiRecruiter.GET_COMPANY_PAGING, AuthorizationMode.PUBLIC, { page: 10})
      .then(res => {
         this.companies = res?.data
         console.log(this.companies);
         
      })
      .catch(data => {
         console.warn(apiRecruiter.GET_ALL_CATEGORY, data);
      })

   }

}
