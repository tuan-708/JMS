import { Component, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';
import { postRequest } from 'src/app/service/api-requests';
import { AuthorizationMode, apiRecruiter } from 'src/app/service/constant';
import { getToken, isLogin, saveItem, signOut } from 'src/app/service/localstorage';

@Component({
   selector: 'app-header-recruiter',
   templateUrl: './header.component.html',
   styleUrls: ['./header.component.css'],
   encapsulation: ViewEncapsulation.None
})
export class HeaderComponent {
   isLog:boolean = true;

   auth(){
      this.isLog = isLogin();
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
      this.auth()
   }

   signOut(){
      signOut();
      this.isLog = false
      this.router.navigate(['/recruiter/sign-in']);
   }
}
