import { Component, ViewEncapsulation } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { postRequest } from 'src/app/service/api-requests';
import { AuthorizationMode, apiRecruiter } from 'src/app/service/constant';
import { environment } from 'src/environments/environment';
import { getToken, saveItem, saveToken } from 'src/app/service/localstorage';
import { Router } from '@angular/router';

@Component({
   selector: 'app-sign-in',
   templateUrl: './sign-in.component.html',
   styleUrls: ['./sign-in.component.css'],
})
export class RecruiterSignInComponent {
   backgroudSelectedLink = `${environment.Url}/assets/images/imageRecruiterRegister.png`


   username: any;
   password: any;

   showSuccess() {
      this.toastr.success('Đăng nhập thành công', 'Thành công', {
         progressBar: true,
         timeOut: 3000,
      });
   }

   showError() {
      this.toastr.error('Tài khoản mật khẩu không chính xác', 'Thất bại', {
         progressBar: true,
         timeOut: 3000,
         enableHtml: true
      });
   }

   constructor(private toastr: ToastrService, private router: Router) {

   }

   signIn(even: any) {
      const data = {
         username: this.username,
         password: this.password
      }
      postRequest(apiRecruiter.LOGIN_RECRUITER, AuthorizationMode.PUBLIC, data)
         .then(res => {
            if (res?.statusCode == 200) {
               saveToken(res.data)

               postRequest(apiRecruiter.GET_PROFILE_RECRUITER + "?token=" + res.data, AuthorizationMode.BEARER_TOKEN, {})
                  .then(res => {

                     if (res.statusCode == 200) {

                        setTimeout(() => {
                           saveItem("profile", res.data);
                        }, 1000);

                        setTimeout(() => {
                           this.showSuccess()
                           if (res.data.companyId) {
                              this.router.navigate(['/recruiter/list-jds']);
                           } else {
                              this.router.navigate(['/recruiter/create-conpany']);
                           }

                        }, 1000);

                     }
                  })
                  .catch(data => {
                     console.log(apiRecruiter.GET_PROFILE_RECRUITER + "?token=" + res.data, data);
                  })
            } else {
               this.showError()
            }
         })
         .catch(data => {
            this.showError()
            console.error(apiRecruiter.LOGIN_RECRUITER, data);

         })
   }

}
