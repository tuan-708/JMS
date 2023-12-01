import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { showError, showSuccess } from 'src/app/service/common';

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
         showSuccess(this.toastr, "Mật khẩu mới đã được gửi về tài khoản!")
      } else {
         showError(this.toastr, "Vui lòng nhập email hợp lệ!")
      }

   }

   isValidEmail(email: string): boolean {
      const emailRegex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
      return emailRegex.test(email);
   }
}
