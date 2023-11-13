import { Component } from '@angular/core';
import { getRequest } from 'src/app/service/api-requests';
import { AuthorizationMode, apiCandidate } from 'src/app/service/constant';
import { getProfile, isLogin } from 'src/app/service/localstorage';
import { environment } from 'src/environments/environment';
declare var $: any; 

@Component({
   selector: 'app-my-cvs',
   templateUrl: './my-cvs.component.html',
   styleUrls: ['./my-cvs.component.css']
})
export class CandidateMyCvsComponent {
   Url = environment.Url;
   list = [1,2,3,4,5,6,7,8,9]
   listCVs:any; 

   ngAfterViewInit() {
      $('#prev').on('click', function () {
         $('#cards').animate({
            scrollLeft: '-=250'
         }, 300, 'swing');
      });

      $('#next').on('click', function () {
         $('#cards').animate({
            scrollLeft: '+=250'
         }, 300, 'swing');
      });
   }

   constructor(){
      const isLog = isLogin();
      if(isLog){
         const profile = getProfile();

         getRequest(`${apiCandidate.GET_ALL_CV_BY_ID}/${profile.id}`, AuthorizationMode.BEARER_TOKEN, {})
         .then(res => {
            this.listCVs = res?.data
            console.log(this.listCVs);
         })
         .catch(data => {
            console.warn(apiCandidate.GET_ALL_CV_BY_ID, data);
         })
      }
    
   }

   gotoEditCV(id: number){
      console.log(id);
      
   }
}
