import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { postRequest } from 'src/app/service/api-requests';
import { AuthorizationMode, apiCandidate } from 'src/app/service/constant';
import { getToken, isLogin, saveItem, signOut } from 'src/app/service/localstorage';
import { environment } from 'src/environments/environment';

@Component({
   selector: 'candidate-header',
   templateUrl: './header.component.html',
   styleUrls: ['./header.component.css']
})
export class HeaderComponent {
   backgroudSelectedLink = `${environment.Url}/assets/background-gradients/gradients-backgrounds-sexy-blue1.png`

   isLog:boolean = false;

   auth(){
      this.isLog = isLogin();
      if(!this.isLog){
         const token =  getToken()
         postRequest(apiCandidate.GET_PROFILE_USER+"?token="+token, AuthorizationMode.BEARER_TOKEN, {})
         .then(res => {
            if(res.statusCode == 200){
               saveItem("profile", res.data);
                 this.isLog = isLogin();
            }
         })
         .catch(data => {
            signOut();
            this.isLog = isLogin();
            console.log("Lỗi",apiCandidate.GET_PROFILE_USER+"?token="+token);
         })
      }
   }

   constructor(private router: Router){
      this.auth()
   }

   signOut(){
      signOut();
      this.router.navigate(['/candidate/sign-in']);
   }
}
