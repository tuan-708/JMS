import { Component } from '@angular/core';
import ClassicEditor from '@ckeditor/ckeditor5-build-classic';
import { FormControl, Validators } from '@angular/forms';
import { getRequest, postRequest, putRequest, deleteRequest } from 'src/app/service/api-requests';
import { AuthorizationMode, apiRecruiter } from 'src/app/service/constant';

@Component({
   selector: 'app-company-update',
   templateUrl: './company-update.component.html',
   styleUrls: ['./company-update.component.css']
})
export class CompanyUpdateComponent {
   //upload img
   displayImage = "none"
   fileSrc: any;
   public Editor = ClassicEditor;
   categories: any;
   company: any;
   companyName: any

   constructor() {
      getRequest(apiRecruiter.GET_ALL_CATEGORY, AuthorizationMode.PUBLIC, { page: 10 })
         .then(res => {
            this.categories = res?.data
         })
         .catch(data => {
            console.warn(apiRecruiter.GET_ALL_CATEGORY, data);
         })

      getRequest(apiRecruiter.GET_COMPANY_BY_ID+"/5", AuthorizationMode.PUBLIC, { page: 10 })
         .then(res => {
            this.company = res?.data
            console.log(this.company);
            
            this.nameRq.setValue(this.company?.companyName)
            this.emailRq.setValue(this.company?.email)
            this.taxNumRq.setValue(this.company?.tax)
            this.taxNumRq.setValue(this.company?.tax)
            this.websiteRq.setValue(this.company?.webURL)
            this.categoryRq.setValue("7")
            this.sizeRq.setValue("1 - 100 người")
            this.yearOfEstablishmentRq.setValue(this.company?.yearOfEstablishment)
            this.phoneRq.setValue(this.company?.phone)
            this.addressRq.setValue(this.company?.address)
            this.descriptionRq.setValue(this.company?.description)

         })
         .catch(data => {
            console.warn(apiRecruiter.GET_COMPANY_BY_ID, data);
         })


   }

   nameRq = new FormControl('', [Validators.required]);
   emailRq = new FormControl('', [Validators.required, Validators.email]);
   taxNumRq = new FormControl('', [Validators.required]);
   websiteRq = new FormControl('');
   categoryRq = new FormControl('',[Validators.required, Validators.min(1)]);
   sizeRq = new FormControl('', [Validators.required, Validators.min(1)]);
   addressRq = new FormControl('', [Validators.required]);
   yearOfEstablishmentRq = new FormControl('');
   phoneRq = new FormControl('', [Validators.required]);
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


   getErrorMessageDescriptionRequirement() {
      if (this.descriptionRq.hasError('required')) {
         return 'Miêu cả không được để trống!'
      }
      return
   }



   checkReq: any = false;


   submitButtonClicked() {

      if (this.nameRq.valid && this.emailRq.valid && this.taxNumRq.valid
         && this.categoryRq.valid && this.sizeRq.valid && this.addressRq.valid) {
         const companyName = this.nameRq.value;
         const email = this.emailRq.value;
         const phone = this.phoneRq.value;
         const address = this.addressRq.value;
         const description = this.descriptionRq.value;
         const tax = this.taxNumRq.value?.toString();
         const webURL = this.websiteRq.value;
         const categoryName = this.categoryRq.value;
         const size = this.sizeRq.value;
         const recuirterFounder = "6";
         const yearOfEstablishment = this.yearOfEstablishmentRq.value;

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
            recuirterFounder: recuirterFounder,
            recuirtersInCompany: [],
            jDs: [],
            yearOfEstablishment: yearOfEstablishment
         }

         postRequest(apiRecruiter.UPDATE_COMPANY + "/" + recuirterFounder, AuthorizationMode.PUBLIC, data)
            .then(res => {
               console.log(res);
            })
            .catch(data => {
               console.log(data);
            })
      }

      const taxNum = this.taxNumRq.value?.toString();
      console.log(taxNum);



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
