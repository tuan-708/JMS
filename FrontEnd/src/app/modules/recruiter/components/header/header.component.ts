import { Component, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';
import { postRequest } from 'src/app/service/api-requests';
import { AuthorizationMode, apiRecruiter } from 'src/app/service/constant';
import { getProfile, getToken, isLogin, saveItem, signOut } from 'src/app/service/localstorage';

@Component({
   selector: 'app-header-recruiter',
   templateUrl: './header.component.html',
   styleUrls: ['./header.component.css'],
   encapsulation: ViewEncapsulation.None
})
export class HeaderComponent {
   isLog:boolean = true;
   hasCompany: boolean = true;
   profile: any;

   auth(){
      this.isLog = isLogin();
      this.profile = getProfile();
      
  
      if(!this.isLog){
         const token = getToken()
         postRequest(apiRecruiter.GET_PROFILE_RECRUITER + "?token=" + token, AuthorizationMode.BEARER_TOKEN, {})
         .then(res => {
           if (res.statusCode == 200) {
             saveItem("profile", res.data);
             this.isLog = true;
           }
         })
         .catch(data => {
           signOut();
           this.router.navigate(['/recruiter/sign-in']);
           console.log("Lỗi", apiRecruiter.GET_PROFILE_RECRUITER + "?token=" + token);
         })
      }
   }

   constructor(private router: Router){
      this.profile = getProfile();
      if(this.profile.companyId === null){
         this.hasCompany = false
      }
   }

   signOut(){
      signOut();
      this.isLog = false
      this.router.navigate(['/recruiter/sign-in']);
   }
}
