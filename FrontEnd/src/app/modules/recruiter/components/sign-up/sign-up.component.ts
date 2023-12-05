import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { postRequest } from 'src/app/service/api-requests';
import { showError } from 'src/app/service/common';
import { AuthorizationMode, apiCandidate, apiRecruiter } from 'src/app/service/constant';

@Component({
   selector: 'app-register',
   templateUrl: './sign-up.component.html',
   styleUrls: ['./sign-up.component.css']
})
export class RegisterRecruiterComponent {

   FullName = ""
   UserName = ""
   Email = ""
   Password = ""
   rePassword = ""

   invalidFullName: boolean = false;
   invalidUserName: boolean = false;
   invalidEmail: boolean = false;
   invalidPassword: boolean = false;
   invalidRePassword: boolean = false;
   checkbox: boolean = false;

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

      const passwordRegex: RegExp = /^(?=.*[A-Z])(?=.*[\W_]).{8,}$/;
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

   showInfoInput() {
      this.toastr.info('Điền các trường ở bên dưới', 'Thông báo', {
         progressBar: true,
         timeOut: 3000,
      });
   }

   showInfoNoCheck() {
      this.toastr.info('Hãy chấp nhận điều khoản của chúng tôi', 'Thông báo', {
         progressBar: true,
         timeOut: 3000,
      });
   }

   ChangeStatusCheckbox(event: any){
      this.checkbox = ! this.checkbox 
   }


   constructor(private toastr: ToastrService, private router: Router) {

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

         if(!this.checkbox){
            this.showInfoNoCheck()
            return
         } 

         postRequest(`${apiRecruiter.REGISTER_ACCOUNT_RECRUITER}?email=${this.Email}
         &fullName=${this.FullName}&username=${this.UserName}&password=${this.Password}&confirmPassword=${this.rePassword}`, AuthorizationMode.PUBLIC, {})
            .then(res => {
               if (res.statusCode == 200 && res.data === "Register successful") {
                  this.showSuccess()
                  this.router.navigate(['/recruiter/sign-in']);
               }else if(res.data === "Email exist in system"){
                  showError(this.toastr ,"Email đã tồn tại trên hệ thống!")
               }else {
                  this.showError()
               }
            })
            .catch(data => {
               this.showError()
               console.warn(data);

            })
      } else {
         this.showInfoInput()
      }
   }
}
