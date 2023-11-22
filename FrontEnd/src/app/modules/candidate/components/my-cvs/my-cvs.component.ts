import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { getRequest } from 'src/app/service/api-requests';
import { AuthorizationMode, apiCandidate } from 'src/app/service/constant';
import { getProfile, isLogin } from 'src/app/service/localstorage';
import { environment } from 'src/environments/environment';
import { ViewCvComponent } from '../view-cv/view-cv.component';
import { Router } from '@angular/router';
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
   profile: any

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

   constructor(public dialog: MatDialog, private router: Router){
      const isLog = isLogin();
      if(isLog){
         this.profile = getProfile();

         getRequest(`${apiCandidate.GET_ALL_CV_BY_ID}/${this.profile.id}`, AuthorizationMode.BEARER_TOKEN, {})
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
     this.router.navigate([`/candidate/update-cv/`]);
   }
}
