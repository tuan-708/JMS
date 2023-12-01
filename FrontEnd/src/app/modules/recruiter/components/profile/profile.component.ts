import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { getRequest, postFileRequest, postRequest } from 'src/app/service/api-requests';
import { showError, showSuccess } from 'src/app/service/common';
import { AuthorizationMode, apiRecruiter } from 'src/app/service/constant';
import { getProfile, getToken, saveItem, signOut } from 'src/app/service/localstorage';

declare var $: any;
@Component({
   selector: 'app-profile',
   templateUrl: './profile.component.html',
   styleUrls: ['./profile.component.css']
})
export class ProfileComponent {

   profile: any
   company: any
   newProfile: any = { fullname: '', phone: '', dob: '', gender: '', desc: null }
   genderDisplay: any

   constructor(public toastr: ToastrService, private router: Router) {
      this.profile = getProfile()
      this.getCompany();
   }

   getCompany() {
      getRequest(apiRecruiter.GET_COMPANY_BY_ID + "/" + this.profile.id, AuthorizationMode.PUBLIC)
         .then(res => {
            this.company = res?.data
         })
         .catch(data => {
            console.warn("Get API fail!" + data);
         })
   }

   updateProfile(fullname: HTMLInputElement, gender: HTMLSelectElement, phone: HTMLInputElement, dob: HTMLInputElement) {
      if (this.validatePhoneNumber(phone.value.trim()) && this.validateDate(dob.value.trim()) && this.validateString(fullname.value)) {
         this.newProfile.fullname = fullname.value == "" ? this.profile.fullName : fullname.value
         this.newProfile.phone = this.validatePhoneNumber(phone.value.trim()) ? phone.value : this.profile.phoneNumber
         this.newProfile.dob = this.validateDate(dob.value.trim()) ? dob.value : this.profile.doB_Display
         this.newProfile.gender = gender.value == "" ? this.profile.genderTitle : gender.value
      } else {
         return
      }
      // this.newProfile.fullname = fullname.value == "" ? this.profile.fullName : fullname.value
      // this.newProfile.phone = this.validatePhoneNumber(phone.value.trim()) ? phone.value : this.profile.phoneNumber
      // this.newProfile.dob = this.validateDate(dob.value.trim()) ? dob.value : this.profile.doB_Display
      // this.newProfile.gender = gender.value == "" ? this.profile.genderTitle : gender.value
      console.log(this.newProfile)

      postRequest(apiRecruiter.UPDATE_PROFILE + "?recruiterId=" + this.profile.id + "&fullName=" + this.newProfile.fullname + "&phoneNumber=" + this.newProfile.phone + "&DOB=" + this.newProfile.dob + "&genderId=1&description=" + this.newProfile.desc, AuthorizationMode.BEARER_TOKEN, {})
         .then(res => {
            console.log(res)
            if (res.statusCode == 200) {
               this.profile.fullName = this.newProfile.fullname
               this.profile.phoneNumber = this.newProfile.phone
               this.profile.doB_Display = this.newProfile.dob
               this.profile.genderTitle = this.newProfile.gender
               console.log(this.profile)
               saveItem("profile", this.profile);
               showSuccess(this.toastr, "Cập nhật thông tin thành công!")
            } else {
               showError(this.toastr, "Cập nhật thất bại! Vui lòng thử lại.")
            }
         })
         .catch(data => {
            console.log("Update fail", data);
            showError(this.toastr, "Cập nhật thất bại! Vui lòng thử lại.")
         })
   }

   validatePhoneNumber(phoneNumber: string): boolean {
      if (phoneNumber.length < 9 || phoneNumber.length > 10) {
         showError(this.toastr, "Cập nhật thất bại! Độ dài số điện thoại không hợp lệ.")
         return false;
      }

      if (!/^\d+$/.test(phoneNumber)) {
         showError(this.toastr, "Cập nhật thất bại! Số điện thoại không hợp lệ.")
         return false;
      }

      return true;
   }

   validateDate(dateString: string): boolean {
      const regex = /^(0[1-9]|[12][0-9]|3[01])\/(0[1-9]|1[0-2])\/\d{4}$/;

      if (!regex.test(dateString)) {
         showError(this.toastr, "Cập nhật thất bại! Định dạng ngày tháng không hợp lệ (dd/MM/yyyy).")
         return false; // Không khớp định dạng
      }

      const parts = dateString.split('/');
      const day = parseInt(parts[0], 10);
      const month = parseInt(parts[1], 10);
      const year = parseInt(parts[2], 10);

      if (isNaN(day) || isNaN(month) || isNaN(year)) {
         showError(this.toastr, "Cập nhật thất bại! Ngày tháng không hợp lệ.")
         return false; // Không phải là số
      }

      const maxDays = new Date(year, month, 0).getDate();

      if (day < 1 || day > maxDays || month < 1 || month > 12) {
         showError(this.toastr, "Cập nhật thất bại! Ngày tháng không hợp lệ.")
         return false; // Ngày tháng không hợp lệ
      }

      return true;
   }

   validateString(string: any) {
      if (string == null || string.trim().length == 0) {
         showError(this.toastr, "Cập nhật thất bại! Tên không được để trống.")
         return false
      }
      return true
   }

   changePassword(oldPass: HTMLInputElement, newPass: HTMLInputElement, rePass: HTMLInputElement) {
      console.log(oldPass.value + " = " + newPass.value + " = " + rePass.value)
      if (this.isOldPassValid(oldPass.value) && this.isPasswordValid(newPass.value) && this.isRePassMatch(newPass.value, rePass.value)) {
         postRequest(apiRecruiter.CHANGE_PASSWORD + "?recruiterId=" + this.profile.id + "&fullName=" + this.newProfile.fullname + "&oldPassword=" + oldPass.value + "&newPassword=" + newPass.value + "&confirmPassword=" + rePass.value, AuthorizationMode.BEARER_TOKEN, {})
            .then(res => {
               console.log(res)
               if (res.statusCode == 200) {
                  showSuccess(this.toastr, "Thay đổi mật khẩu thành công!")
               } else {
                  showError(this.toastr, "Thay đổi thất bại! Vui lòng thử lại sau.")
               }
            })
            .catch(data => {
               console.log("Update fail", data);
               showError(this.toastr, "Thay đổi thất bại! Vui lòng thử lại sau.")
            })
      }
   }

   isOldPassValid(oldPass: any) {
      if (oldPass.trim().length == 0) {
         showError(this.toastr, "Hãy nhập mật khẩu!")
         return false
      }
      return true
   }

   isPasswordValid(password: string): boolean {
      if (password.trim().length == 0) {
         showError(this.toastr, "Hãy nhập mật khẩu mới!")
         return false
      }

      if (password.length < 8 || password.length > 20) {
         showError(this.toastr, "Độ dài mật khẩu không hợp lệ!")
         return false;
      }

      if (password.includes(' ')) {
         showError(this.toastr, "Mật khẩu chứa khoảng trắng!")
         return false;
      }

      return true;
   }

   isRePassMatch(newPass: any, rePass: any) {
      if (rePass.trim().length == 0) {
         showError(this.toastr, "Hãy xác nhận mật khẩu!")
         return false
      }

      if (newPass !== rePass) {
         showError(this.toastr, "Mật khẩu xác nhận không trùng khớp!")
         return false
      }

      return true
   }

   showUploadAvatarSuccess() {
      this.toastr.success('Chỉnh sửa ảnh thành công', 'Thành công', {
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

   getProfile = () => {
      var token = getToken()

      postRequest(apiRecruiter.GET_PROFILE_RECRUITER + "?token=" + token, AuthorizationMode.BEARER_TOKEN, {})
         .then(res => {
            if (res.statusCode == 200) {
               this.profile = res.data

               setTimeout(() => {
                  saveItem("profile", res.data);
               }, 1000);
            }
         })
         .catch(error => {
            this.router.navigate(['/candidate/sign-in']);
            this.showTokenExpiration()
            signOut()
         })
   }

   showErrorUploadImage() {
      this.toastr.error('Chỉnh sửa thông tin cá nhân thất bại', 'Thất bại', {
         progressBar: true,
         timeOut: 3000,
      });
   }


   getFile(event: any) {
      if ($('#avatarCv')[0].files[0]) {

         let formData: FormData = new FormData();
         let file: File = $('#avatarCv')[0].files[0];
         formData.append('file', file, file.name);

         postFileRequest(`${apiRecruiter.UPDATE_IMAGE_RECRUITER}/${this.profile.id}`, AuthorizationMode.BEARER_TOKEN, formData)
            .then(res => {
               if (res.statusCode == 200) {

                  this.getProfile()
                  this.showUploadAvatarSuccess()
               }
            })
            .catch(data => {
               this.showErrorUploadImage()
               console.log(data);
            })
      }
   }
}
