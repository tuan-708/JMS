import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { postRequest } from 'src/app/service/api-requests';
import { showError, showSuccess } from 'src/app/service/common';
import { AuthorizationMode, apiRecruiter } from 'src/app/service/constant';

@Component({
   selector: 'app-forgot-password',
   templateUrl: './forgot-password.component.html',
   styleUrls: ['./forgot-password.component.css']
})
export class ForgotPasswordComponent {
   constructor(private toastr: ToastrService) {

   }

   getPassword(email: HTMLInputElement) {
      if (this.isValidEmail(email.value)) {
         postRequest(`${apiRecruiter.FORGOT_PASSWORD_RECRUITER}?email=${email.value}`, AuthorizationMode.PUBLIC, { Email: email.value })
         .then(res => {
            if(res?.statusCode == 200){
               if(res?.data == "email does not exist! Check again"){
                  showError(this.toastr, "Email không tồn tại.")
                  return
               }
               showSuccess(this.toastr, "Tại mật khẩu mới thành công, vui lòng kiểm tra Email")
            }
            console.log(res);
         })
         .catch(res => {
            showError(this.toastr, "Thay đổi mật khẩu thất bại, vui lòng thử lại sau")
         })
      } else {
         showError(this.toastr, "Vui lòng nhập email hợp lệ!")
      }

   }

   isValidEmail(email: string): boolean {
      const emailRegex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
      return emailRegex.test(email);
   }
}
