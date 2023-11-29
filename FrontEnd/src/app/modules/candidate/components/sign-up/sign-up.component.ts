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

   invalidFullName: boolean = false;
   invalidUserName: boolean = false;
   invalidEmail: boolean = false;
   invalidPassword: boolean = false;
   invalidRePassword: boolean = false

   validateFullName(event: any) {
      this.FullName = event

      const vietnameseNameRegex: RegExp = /^[\p{L} ]+$/u;
      this.invalidFullName = !vietnameseNameRegex.test(this.FullName);
   }

   validateUserName(event: any) {
      this.UserName = event

      const usernameRegex: RegExp = /^[^\s]{6,}$/;
      this.invalidUserName = !usernameRegex.test(this.UserName);
   }

   validateEmail(event: any) {
      this.Email = event

      const emailRegex: RegExp = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
      this.invalidEmail = !emailRegex.test(this.Email);
   }

   validatePassword(event: any) {
      this.Password = event
      if(this.Password.length < 8){
         this.invalidPassword = true
         return
      }

      const passwordRegex: RegExp = /^(?=.*[A-Z])(?=.*[\W_]).{6,}$/;
      this.invalidPassword = !passwordRegex.test(this.Password);
   }

   validateRePassword(event: any) {
      this.rePassword = event

      if (!(this.Password === this.rePassword)) {
         this.invalidRePassword = true
      } else {
         this.invalidRePassword = false
      }
   }

   showSuccess() {
      this.toastr.success('Đăng ký tài khoản thành công', 'Thành công', {
         progressBar: true,
         timeOut: 3000,
      });
   }

   showError() {
      this.toastr.error('Đăng ký tài khoản thất bại, vui lòng thử lại sau', 'Thất bại', {
         progressBar: true,
         timeOut: 3000,
      });
   }

   showInfoInput() {
      this.toastr.info('Điền các trường ở bên dưới', 'Thông báo', {
         progressBar: true,
         timeOut: 3000,
      });
   }


   constructor(private toastr: ToastrService) {

   }

   validAllFiled() {
      if (!this.invalidFullName && !this.invalidUserName && !this.invalidEmail
         && !this.invalidPassword && !this.invalidRePassword &&
         this.Email !== "" && this.FullName !== "" && this.UserName !== ""
         && this.Password !== "" && this.rePassword !== "") {
         return true
      }
      return false
   }

   Submit() {

      if (this.validAllFiled()) {
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
      } else {
         this.showInfoInput()
      }
   }
}
