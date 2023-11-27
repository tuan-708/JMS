import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { getRequest, postRequest } from 'src/app/service/api-requests';
import { showError, showSuccess } from 'src/app/service/common';
import { AuthorizationMode, apiRecruiter } from 'src/app/service/constant';
import { getProfile, saveItem } from 'src/app/service/localstorage';

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

  constructor(public toastr: ToastrService) {
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
    this.newProfile.fullname = fullname.value == "" ? this.profile.fullName : fullname.value
    this.newProfile.phone = this.validatePhoneNumber(phone.value.trim()) ? phone.value : this.profile.phoneNumber
    this.newProfile.dob = this.validateDate(dob.value.trim()) ? dob.value : this.profile.doB_Display
    this.newProfile.gender = gender.value == "" ? this.profile.genderTitle : gender.value
    console.log(this.newProfile)

    postRequest(apiRecruiter.UPDATE_PROFILE + "?recruiterId=" + this.profile.id + "&fullName=" + this.newProfile.fullname +"&phoneNumber=" + this.newProfile.phone + "&DOB=" + this.newProfile.dob + "&genderId=1&description=" + this.newProfile.desc, AuthorizationMode.BEARER_TOKEN, {})
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
        }else{
          showError(this.toastr, "Cập nhật thất bại! Vui lòng xem lại thông tin.")
        }
      })
      .catch(data => {
        console.log("Update fail", data);
        showError(this.toastr, "Cập nhật thất bại! Vui lòng xem lại thông tin.")
      })
  }

  validatePhoneNumber(phoneNumber: string): boolean {
    if (phoneNumber.length < 9 || phoneNumber.length > 10) {
      return false;
    }

    if (!/^\d+$/.test(phoneNumber)) {
      return false;
    }

    return true;
  }

  validateDate(dateString: string): boolean {
    const regex = /^(0[1-9]|[12][0-9]|3[01])\/(0[1-9]|1[0-2])\/\d{4}$/;

    if (!regex.test(dateString)) {
      return false; // Không khớp định dạng
    }

    const parts = dateString.split('/');
    const day = parseInt(parts[0], 10);
    const month = parseInt(parts[1], 10);
    const year = parseInt(parts[2], 10);

    if (isNaN(day) || isNaN(month) || isNaN(year)) {
      return false; // Không phải là số
    }

    const maxDays = new Date(year, month, 0).getDate();

    if (day < 1 || day > maxDays || month < 1 || month > 12) {
      return false; // Ngày tháng không hợp lệ
    }

    return true;
  }
}
