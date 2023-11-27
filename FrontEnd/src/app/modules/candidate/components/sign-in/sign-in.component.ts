import { Component, ViewEncapsulation } from '@angular/core';
import { postRequest } from 'src/app/service/api-requests';
import { AuthorizationMode, apiCandidate } from 'src/app/service/constant';
import { ToastrService } from 'ngx-toastr';
import { saveToken, saveItem } from 'src/app/service/localstorage';
import { Router } from '@angular/router';

declare var $: any;
@Component({
   selector: 'app-sign-in',
   templateUrl: './sign-in.component.html',
   styleUrls: ['./sign-in.component.css'],
})


export class CandidateSignInComponent {
   username: any;
   password: any;

   showSuccess() {
      this.toastr.success('Đăng nhập thành công', 'Thành công',  {
         progressBar: true,
         timeOut: 3000,
      });
   }

   showError() {
      this.toastr.error('Tài khoản hoặc mật khẩu không chính xác','Thất bại',  {
         progressBar: true,
         timeOut: 3000,
      });
   }


   constructor(private toastr: ToastrService, private router: Router) {
      // deleteToken()
   }

   signIn(even: any) {
      const data = {
         username: this.username,
         password: this.password
      }
      postRequest(apiCandidate.LOGIN_CANDIDATE, AuthorizationMode.PUBLIC, data)
         .then(res => {
            if (res?.statusCode == 200) {
               saveToken(res.data)

               postRequest(apiCandidate.GET_PROFILE_USER+"?token="+res.data, AuthorizationMode.BEARER_TOKEN, {})
               .then(res => {
                  if(res.statusCode == 200){

                     setTimeout(() => {
                        saveItem("profile", res.data);
                      }, 1000);
                      
                      setTimeout(() => {
                        this.showSuccess()
                        this.router.navigate(['/candidate/']);
                      }, 1000);
                  }
               })
               .catch(data => {
                  this.showError()
                  console.error(apiCandidate.GET_PROFILE_USER+"?token="+res.data, data);
               })
            }else{
               this.showError()
            }
         })
         .catch(data => {
            this.showError()
            console.error(apiCandidate.LOGIN_CANDIDATE, data);
         })
   }
}
