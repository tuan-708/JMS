import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { postRequest } from 'src/app/service/api-requests';
import { AuthorizationMode, apiCandidate } from 'src/app/service/constant';


@Component({
   selector: 'app-forgot-password',
   templateUrl: './forgot-password.component.html',
   styleUrls: ['./forgot-password.component.css']
})
export class CandidateForgotPasswordComponent {
   Email = ""

   showSuccess() {
      this.toastr.success('Thay đổi thành công, vui lòng kiểm tra Email!', 'Thành công', {
         progressBar: true,
         timeOut: 3000,
      });
   }

   showFail() {
      this.toastr.error('Thay đổi mật khẩu thất bại, vui lòng thử lại sau!', 'Thất bại', {
         progressBar: true,
         timeOut: 3000,
      });
   }

   constructor(private toastr: ToastrService) {

   }

   Submit() {
      postRequest(`${apiCandidate.FORGOT_PASSWORD_CANDIDATE}?email=${this.Email}`, AuthorizationMode.PUBLIC, { Email: this.Email })
         .then(res => {

            console.log(res);

         })
         .catch(res => {
            console.warn(res);

         })
   }
}
