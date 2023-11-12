import { Component, ViewEncapsulation } from '@angular/core';
import { postRequest } from 'src/app/service/api-requests';
import { AuthorizationMode, apiCandidate } from 'src/app/service/constant';
import { ToastrService } from 'ngx-toastr';
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
      this.toastr.info('Thông báo!', 'Đăng nhập thành công!', {
         progressBar: true,
         timeOut: 3000,
      });
   }

   showFail() {
      this.toastr.error('Thông báo!', 'Đăng nhập thất bại!', {
         progressBar: true,
         timeOut: 3000,
      });
   }


   constructor(private toastr: ToastrService) {

   }

   signIn(even: any) {
      const data = {
         username: this.username,
         password: this.password
      }
      postRequest(apiCandidate.LOGIN_CANDIDATE, AuthorizationMode.PUBLIC, data)
         .then(res => {
            if (res?.statusCode == 401) {
               this.showFail()
            }
            if (res?.statusCode == 200) {
               localStorage.setItem('token', res.data);
               
               this.showSuccess()
            }
         })
         .catch(data => {
            this.showFail()
         })
   }
}
