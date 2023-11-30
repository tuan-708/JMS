import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { postFileRequest, postRequest } from 'src/app/service/api-requests';
import { AuthorizationMode, apiCandidate } from 'src/app/service/constant';
import { getProfile, getToken, saveItem, saveToken, signOut } from 'src/app/service/localstorage';

declare var $: any;
@Component({
   selector: 'app-candidate-profile',
   templateUrl: './profile.component.html',
   styleUrls: ['./profile.component.css']
})

export class ProfileComponent {
   profile: any

   FullName: any
   Phone: any
   Dob: any
   Male: boolean = true
   Female: any


   invalidFullName: boolean = false;
   invalidPhone: boolean = false;
   invalidDob: boolean = false;

   validateFullName(event: any) {
      this.FullName = event

      const vietnameseNameRegex: RegExp = /^[\p{L} ]+$/u;
      this.invalidFullName = !vietnameseNameRegex.test(this.FullName);
   }

   validatePhone(event: any) {
      this.Phone = event

      const PhoneRegex: RegExp = /^\d{10}$/;
      this.invalidPhone = !PhoneRegex.test(this.Phone);
   }

   validateDob(event: any) {
      this.Dob = event

      const DobRegex: RegExp = /^\d{4}-\d{2}-\d{2}$/
      this.invalidDob = !DobRegex.test(this.Dob);
   }

   validAllFiled() {
      if (!this.invalidFullName && !this.invalidPhone && !this.invalidDob &&
         this.FullName !== "" && this.Phone !== "" && this.Dob !== "") {
         return true
      }
      return false
   }

   showSuccess() {
      this.toastr.success('Chỉnh sửa thông tin cá nhân thành công', 'Thành công', {
         progressBar: true,
         timeOut: 3000,
      });
   }

   showError() {
      this.toastr.error('Chỉnh sửa thông tin cá nhân thất bại', 'Thất bại', {
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

   showTokenExpiration() {
      this.toastr.info('Phiên đăng nhập hết hạn', 'Thông báo', {
         progressBar: true,
         timeOut: 3000,
      });
   }

   showUploadAvatarSuccess() {
      this.toastr.success('Chỉnh sửa ảnh thành công', 'Thành công', {
         progressBar: true,
         timeOut: 3000,
      });
   }


   getProfile = () =>{
      var token = getToken()

      postRequest(apiCandidate.GET_PROFILE_USER + "?token=" + token, AuthorizationMode.BEARER_TOKEN, {})
         .then(res => {
            if (res.statusCode == 200) {
               this.profile = res.data

               this.FullName = this.profile.fullName
               this.Dob = this.profile.dob.split('T')[0]
               this.Phone = this.profile.phoneNumber

               saveItem("profile", res.data);
            }
         })
         .catch(error => {
            this.router.navigate(['/candidate/sign-in']);
            this.showTokenExpiration()
            signOut()
         })
   }

   constructor(private toastr: ToastrService, private router: Router) {
      this.getProfile()
   }

   getFile(event: any) {
      if ($('#avatarCv')[0].files[0]) {

         let formData: FormData = new FormData();
         let file: File = $('#avatarCv')[0].files[0];
         formData.append('file', file, file.name);

         postFileRequest(`${apiCandidate.UPDATE_AVATAR_CANDIDATE}/${this.profile.id}`, AuthorizationMode.BEARER_TOKEN, formData)
           .then(res => {
             if(res.statusCode == 200){
               this.showUploadAvatarSuccess()
               this.getProfile()
             }
           })
           .catch(data => {
             this.showError()
             console.log(data);
           })
       }
   }

   SubmitForm() {
      if (this.validAllFiled()) {
         console.log($('input[name="gender"]:checked').val());

         postRequest(`${apiCandidate.UPDATE_PROFILE_CANDIDATE}?candidateId=${this.profile.id}
         &fullName=${this.FullName}&phone=${this.Phone}&DOB=${this.Dob}&genderId=${$('input[name="gender"]:checked').val()}`, AuthorizationMode.BEARER_TOKEN, {})
            .then(res => {
               if (res.statusCode == 200) {
                  this.showSuccess()
                  this.getProfile()
               }
               if (res.statusCode == 400) {
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
