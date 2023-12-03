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


   oldPassword: string = "";
   newPassword: string = "";
   conformPassword: string = "";

   invalidOldPassword: boolean = false
   invalidNewPassword: boolean = false
   invalidConformPassword: boolean = false

   displayOldPassword: boolean = false
   displayNewPassword: boolean = false
   displayConformPassword: boolean = false

   typeOldPassword = "password"
   typeNewPassword = "password"
   typeConformPassword = "password"

   invalidName: any = false
   invalidNameMsg: any
   invalidPhone: any = false
   invalidPhoneMsg: any
   invalidDob: any = false
   invalidDobMsg: any

   validateOldPassword(event: any) {
      this.oldPassword = event

      console.log(this.oldPassword);
      
      if(this.oldPassword === "" || this.oldPassword === null ) this.invalidOldPassword = true
      else{
         this.invalidOldPassword = false
      }

   }

   validateNewPassword(event: any) {
      this.newPassword = event

      const passwordRegex: RegExp = /^(?=.*[A-Z])(?=.*[\W_]).{8,}$/;
      this.invalidNewPassword = !passwordRegex.test(this.newPassword);
   }

   validateConformPassword(event: any) {
      this.conformPassword = event

      if (!(this.newPassword === this.conformPassword)) {
         this.invalidConformPassword = true
      } else {
         this.invalidConformPassword = false
      }
   }


   changeStatusOldPassword() {
      this.displayOldPassword = !this.displayOldPassword
      this.typeOldPassword = this.typeOldPassword == "password" ? "text" : "password"
   }

   changeStatusNewPassword() {
      this.displayNewPassword = !this.displayNewPassword
      this.typeNewPassword = this.typeNewPassword == "password" ? "text" : "password"
   }

   changeStatusConformPassword() {
      this.displayConformPassword = !this.displayConformPassword
      this.typeConformPassword = this.typeConformPassword == "password" ? "text" : "password"
   }


   constructor(public toastr: ToastrService, private router: Router) {
      this.profile = getProfile()
      this.getCompany();
   }

   validAllFiled() {
      if (!this.invalidOldPassword && !this.invalidNewPassword && !this.invalidConformPassword &&
         this.oldPassword !== "" && this.newPassword !== "" && this.conformPassword !== "") {
         return true
      }
      return false
   }

   showInfoInput() {
      this.toastr.info('Điền các trường ở bên dưới', 'Thông báo', {
         progressBar: true,
         timeOut: 3000,
      });
   }


   
   SubmitFormChangePassword() {
      if (this.validAllFiled()) {

         postRequest(`${apiRecruiter.CHANGE_PASSWORD}?recruiterId=${this.profile.id}
      &oldPassword=${this.oldPassword}&newPassword=${this.newPassword}&confirmPassword=${this.conformPassword}`, AuthorizationMode.BEARER_TOKEN, {})
            .then(res => {
               console.log(res);
               if (res.statusCode == 200) {
                  showSuccess(this.toastr, "Thay đổi mật khẩu thành công")
                  this.oldPassword = ""
                  this.newPassword = ""
                  this.conformPassword = ""
               }
               if (res.statusCode == 400) {
                  if (res?.message == "Old password is not correct") showError(this.toastr, "Mật khẩu cũ không chính xác")
               }
            })
            .catch(res => {
               showError(this.toastr, "Đã có lỗi xảy ra")
               console.warn(res);

            })
      } else {
         this.showInfoInput()
      }
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
      if (!/^\d+$/.test(phoneNumber)) {
         this.invalidPhone = true
         this.invalidPhoneMsg = 'Số điện thoại không hợp lệ'
         return false;
      }

      if (phoneNumber.length < 9 || phoneNumber.length > 10) {
         this.invalidPhone = true
         this.invalidPhoneMsg = 'Độ dài không hợp lệ'
         return false;
      }

      this.invalidPhone = false
      return true;
   }

   validateDate(dateString: string): boolean {
      const regex = /^(0[1-9]|[12][0-9]|3[01])\/(0[1-9]|1[0-2])\/\d{4}$/;

      if (!regex.test(dateString)) {
         this.invalidDob = true
         this.invalidDobMsg = 'Ngày tháng không hợp lệ! (dd//MM//yyyy)'
         return false
      }

      const parts = dateString.split('/');
      const day = parseInt(parts[0], 10);
      const month = parseInt(parts[1], 10);
      const year = parseInt(parts[2], 10);

      if (isNaN(day) || isNaN(month) || isNaN(year)) {
         this.invalidDob = true
         this.invalidDobMsg = 'Ngày tháng không hợp lệ! (dd//MM//yyyy)'
         return false; // Không phải là số
      }

      const maxDays = new Date(year, month, 0).getDate();

      if (day < 1 || day > maxDays || month < 1 || month > 12) {
         this.invalidDob = true
         this.invalidDobMsg = 'Ngày tháng không hợp lệ!'
         return false; // Ngày tháng không hợp lệ
      }

      this.invalidDob = false
      return true;
   }

   validateString(string: any) {
      const regex = /^[ a-zA-Zàáạảãâầấậẩẫăằắặẳẵèéẹẻẽêềếệểễđìíịỉĩòóọỏõôồốộổỗơờớợởỡùúụủũưừứựửữỳýỵỷỹ\s']+$/;


      if (string == null || string.trim().length == 0) {
         this.invalidName = true
         this.invalidNameMsg = 'Tên không được để trống!'
         return false
      }

      if (!regex.test(string)) {
         this.invalidName = true
         this.invalidNameMsg = 'Tên không được chứa số hoặc ký tự đặc biệt!'
         return false
      }

      this.invalidName = false
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
               }else{
                  showError(this.toastr, res.message)
               }
            })
            .catch(data => {
               this.showErrorUploadImage()
               console.log(data);
            })
      }
   }
}
