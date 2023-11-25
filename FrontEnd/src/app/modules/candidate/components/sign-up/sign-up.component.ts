import { Component, ViewEncapsulation } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { postRequest } from 'src/app/service/api-requests';
import { AuthorizationMode, apiCandidate } from 'src/app/service/constant';

@Component({
   selector: 'app-register',
   templateUrl: './sign-up.component.html',
   styleUrls: ['./sign-up.component.css'],
})
export class CandidateRegisterComponent {

   FullName = ""
   UserName = ""
   Email = ""
   Password = ""
   rePassword = ""

   showSuccess() {
      this.toastr.success('Thông báo!', 'Đăng ký tài khoản thành công!', {
         progressBar: true,
         timeOut: 3000,
      });
   }

   showError() {
      this.toastr.error('Thông báo!', 'Đăng ký tài khoản thất bại, vui lòng thử lại sau', {
         progressBar: true,
         timeOut: 3000,
      });
   }


   constructor(private toastr: ToastrService) {

   }

   Submit() {

      postRequest(`${apiCandidate.REGISTER_ACCOUNT_CANDIDATE}?email=${this.Email}
      &fullName=${this.FullName}&username=${this.UserName}&password=${this.Password}&confirmPassword=${this.rePassword}`, AuthorizationMode.PUBLIC, {})
         .then(res => {
            if (res.statusCode == 200) {
               this.showSuccess()
            } else {
               this.showError()
            }
         })
         .catch(res => {
            this.showError()
            console.warn(res);

         })
   }
}
