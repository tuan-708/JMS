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
   
   FullName=""
   UserName=""
   Email=""
   Password=""
   rePassword=""

   showSuccess() {
      this.toastr.success('Thông báo!', 'Đăng ký tài khoản thành công!', {
         progressBar: true,
         timeOut: 3000,
      });
   }

   showFail() {
      this.toastr.error('Thông báo!', 'Đăng ký tài khoản thất bại, vui lòng thử lại sau', {
         progressBar: true,
         timeOut: 3000,
      });
   }


   constructor(private toastr: ToastrService){

   }

   Submit(){
      const data = {
         fullName: this.FullName,
         UserName: this.UserName,
         email: this.Email,
         password: this.Password,
         rePassword: this.rePassword
      }


      postRequest(`${apiCandidate.REGISTER_ACCOUNT_CANDIDATE}`, AuthorizationMode.PUBLIC, data)
      .then(res => {
         console.log(res);
         
      }) 
      .catch(res => {
         console.warn(res);
         
      })
   }
}
