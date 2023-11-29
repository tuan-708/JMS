import { Component } from '@angular/core';
import ClassicEditor from '@ckeditor/ckeditor5-build-classic';
import { FormControl, Validators } from '@angular/forms';
import { getRequest, postRequest } from 'src/app/service/api-requests';
import { AuthorizationMode, apiRecruiter } from 'src/app/service/constant';
import { getProfile, isLogin, signOut } from 'src/app/service/localstorage';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
   selector: 'app-company-register',
   templateUrl: './create-company.component.html',
   styleUrls: ['./create-company.component.css']
})
export class CreateCompanyComponent {
   //upload img
   displayImage = "none"
   fileSrc: any;
   public Editor = ClassicEditor;
   categories: any;


   constructor(private router: Router,private toastr: ToastrService) {
      getRequest(apiRecruiter.GET_ALL_CATEGORY, AuthorizationMode.PUBLIC, { page: 10 })
         .then(res => {
            this.categories = res?.data
         })
         .catch(data => {
            console.warn(apiRecruiter.GET_ALL_CATEGORY, data);
         })
   }

   nameRq = new FormControl('', [Validators.required]);
   emailRq = new FormControl('', [Validators.required, Validators.email]);
   taxNumRq = new FormControl('', [Validators.required]);
   websiteRq = new FormControl('');
   categoryRq = new FormControl('0', [Validators.required, Validators.min(1)]);
   sizeRq = new FormControl('0', [Validators.required, Validators.min(1)]);
   addressRq = new FormControl('', [Validators.required]);
   yearOfEstablishmentRq = new FormControl('');
   phoneRq = new FormControl('', [Validators.required, Validators.pattern(/^\d{10,}$/)]);
   descriptionRq = new FormControl('', [Validators.required]);

   getErrorMessageName() {
      if (this.nameRq.hasError('required')) {
         return 'Tên công ty không được để trống!'
      }
      return
   }
   getErrorMessageEmail() {
      if (this.emailRq.hasError('required')) {
         return 'Email không được để trống!'
      }
      if (this.emailRq.hasError('email')) {
         return 'Email không hợp lệ!'
      }
      return
   }
   getErrorMessageTaxNum() {
      if (this.taxNumRq.hasError('required')) {
         return 'Mã số thuế không được để trống!'
      }
      return
   }
   getErrorMessageCategory() {
      if (this.categoryRq.hasError('required')) {
         return 'Lĩnh vực không được để trống!'
      }
      if (this.categoryRq.hasError('min')) {
         return 'Lĩnh vực không được để trống!'
      }
      return
   }
   getErrorMessageSize() {
      if (this.sizeRq.hasError('required')) {
         return 'Quy mô không được để trống!'
      }
      if (this.sizeRq.hasError('min')) {
         return 'Quy mô không được để trống!'
      }
      return
   }
   getErrorMessageAddress() {
      if (this.addressRq.hasError('required')) {
         return 'Địa chỉ không được để trống!'
      }
      return
   }

   getErrorMessagePhone(){
      if (this.phoneRq.hasError('required')) {
         return 'Số điện thoại không hợp lệ!'
      }
      return
   }

   getErrorMessageDescriptionRequirement() {
      if (this.descriptionRq.hasError('required')) {
         return 'Miêu cả không được để trống!'
      }
      return
   }

   checkReq: any = false;

   showSuccess() {
      this.toastr.success('Đăng ký công ty thành công', 'Thành công',  {
         progressBar: true,
         timeOut: 3000,
      });
   }

   showFail() {
      this.toastr.error('Đăng ký công ty thất bại', 'Thất bại', {
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


   submitButtonClicked() {

      if (this.nameRq.valid && this.emailRq.valid && this.taxNumRq.valid
         && this.categoryRq.valid && this.sizeRq.valid && this.addressRq.valid
         && this.phoneRq.valid) {
         const companyName = this.nameRq.value;
         const email = this.emailRq.value;
         const phone = this.phoneRq.value;
         const address = this.addressRq.value;
         const description = this.descriptionRq.value;
         const tax = this.taxNumRq.value?.toString();
         const webURL = this.websiteRq.value;
         const categoryName = this.categoryRq.value;
         const size = this.sizeRq.value;
         const yearOfEstablishment = this.yearOfEstablishmentRq.value;

         const profile = getProfile();

         const data = {
            companyName: companyName,
            email: email,
            phone: phone,
            address: address,
            description: description,
            webURL: webURL,
            tax: tax,
            categoryName: categoryName,
            size: size,
            recuirterFounder: profile.id,
            recuirtersInCompany: [],
            jDs: [],
            yearOfEstablishment: yearOfEstablishment
         }

         postRequest(apiRecruiter.CREATE_COMPANY_BY_ID + "/" + profile.id, AuthorizationMode.BEARER_TOKEN, data)
            .then(res => {
               this.showSuccess();
            })
            .catch(data => {
               this.showFail()
            })
      }

      this.checkReq = true;
      this.nameRq.markAllAsTouched()
      this.emailRq.markAllAsTouched()
      this.taxNumRq.markAllAsTouched()
      this.categoryRq.markAllAsTouched()
      this.sizeRq.markAllAsTouched()
      this.addressRq.markAllAsTouched()
      this.phoneRq.markAllAsTouched()
      this.descriptionRq.markAllAsTouched()


      return
   }

   getFile(event: any) {
      if (event.target.files && event.target.files[0]) {
         this.displayImage = "block"

         var reader = new FileReader();

         reader.readAsDataURL(event.target.files[0]);

         reader.onload = (event) => {
            this.fileSrc = event.target?.result;
         }
      }
   }
}
