import { Component } from '@angular/core';
import ClassicEditor from '@ckeditor/ckeditor5-build-classic';
import { FormControl, Validators } from '@angular/forms';
import { getRequest, postRequest, postFileRequest} from 'src/app/service/api-requests';
import { AuthorizationMode, apiRecruiter } from 'src/app/service/constant';
import { getProfile } from 'src/app/service/localstorage';
import { ToastrService } from 'ngx-toastr';

@Component({
   selector: 'app-company-update',
   templateUrl: './company-update.component.html',
   styleUrls: ['./company-update.component.css']
})
export class CompanyUpdateComponent {
   //upload img
   displayImageAvatar = "none"
   displayImageBackground = "none"
   imageAvatarSrc: any;
   imageBackgroundSrc: any;
   fileSrc:any;
   public Editor = ClassicEditor;
   categories: any;
   sizes = ["1 - 100 người","101 - 500 người","Trên 500 người"]
   company: any;
   companyName: any
   profile: any

   constructor(private toastr: ToastrService) {
      this.profile = getProfile();

      getRequest(apiRecruiter.GET_ALL_CATEGORY, AuthorizationMode.PUBLIC, { page: 10 })
         .then(res => {
            this.categories = res?.data
         })
         .catch(data => {
            console.warn(apiRecruiter.GET_ALL_CATEGORY, data);
         })

      getRequest(`${apiRecruiter.GET_COMPANY_BY_ID}/${this.profile.id}`, AuthorizationMode.PUBLIC, { page: 10 })
         .then(res => {
            this.company = res?.data
            console.log(this.company);
            
            this.nameRq.setValue(this.company?.companyName)
            this.emailRq.setValue(this.company?.email)
            this.taxNumRq.setValue(this.company?.tax)
            this.taxNumRq.setValue(this.company?.tax)
            this.websiteRq.setValue(this.company?.webURL)
            const selectCategoty =  this.categories.find((cate:any) => cate?.categoryName === this.company?.categoryName)
            this.categoryRq.setValue(selectCategoty?.id.toString())
            const selectSize =  this.sizes.find((e:any) => e == this.company?.size)
            this.sizeRq.setValue(selectSize?selectSize:"")
            this.yearOfEstablishmentRq.setValue(this.company?.yearOfEstablishment)
            this.phoneRq.setValue(this.company?.phone)
            this.addressRq.setValue(this.company?.address)
            this.descriptionRq.setValue(this.company?.description)

   

            this.imageAvatarSrc = this.company?.avatarURL
            this.imageBackgroundSrc = this.company?.backGroundURL
            this.displayImageAvatar = "block"
            this.displayImageBackground = "block"

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

   
   showUpdateCompanySuccess() {
      this.toastr.info('Thông báo!', 'Cập nhật thành công công ty!', {
         progressBar: true,
         timeOut: 3000,
      });
   }

   showUpdateCompanyFail() {
      this.toastr.error('Thông báo!', 'Cập nhật công ty thất bại!', {
         progressBar: true,
         timeOut: 3000,
      });
   }


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
         const recuirterFounder = this.profile.id;
         const yearOfEstablishment = this.yearOfEstablishmentRq.value;

         const data = {
            companyId: 1,
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
               this.showUpdateCompanySuccess()
               console.log(res);
            })
            .catch(data => {
               this.showUpdateCompanyFail()
               console.log(data);
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

   showChangeAvatarSuccess() {
      this.toastr.info('Thông báo!', 'Cập nhật logo thành công!', {
         progressBar: true,
         timeOut: 3000,
      });
   }

   showChangeAvatarCompanyFail() {
      this.toastr.error('Thông báo!', 'Cập nhật logo thất bại!', {
         progressBar: true,
         timeOut: 3000,
      });
   }

   loadAvatar(event: any) {
      if (event.target.files && event.target.files[0]) {
         let fileList: FileList = event.target.files;
         let formData: FormData = new FormData();
         if (fileList.length > 0) {
            let file: File = fileList[0];
            formData.append('file', file, file.name);
         }
         postFileRequest(`${apiRecruiter.UPDATE_IMAGE_COMPANY_AVATAR}/${this.profile.id}/${this.profile.companyId}`, AuthorizationMode.PUBLIC, formData)
            .then(res => {
               console.log(res);
            })
            .catch(data => {
               console.log(data);
            })
         

         this.displayImageAvatar = "block"

         var reader = new FileReader();

         reader.readAsDataURL(event.target.files[0]);

         reader.onload = (event) => {
            this.imageAvatarSrc = event.target?.result;
         }
      }
   }

   
   showChangeBackgroundSuccess() {
      this.toastr.info('Thông báo!', 'Cập nhật ảnh nền thành công!', {
         progressBar: true,
         timeOut: 3000,
      });
   }

   showChangeBackgroundCompanyFail() {
      this.toastr.error('Thông báo!', 'Cập nhật ảnh nền thất bại!', {
         progressBar: true,
         timeOut: 3000,
      });
   }


   loadBackGround(event: any) {
      if (event.target.files && event.target.files[0]) {

         let fileList: FileList = event.target.files;
         let formData: FormData = new FormData();
         if (fileList.length > 0) {
            let file: File = fileList[0];
            formData.append('file', file, file.name);
         }
         postFileRequest(`${apiRecruiter.UPDATE_IMAGE_COMPANY_BACKGROUND}/${this.profile.id}/${this.profile.companyId}`, AuthorizationMode.PUBLIC, formData)
            .then(res => {
               this.showChangeBackgroundSuccess()
               console.log(res);
            })
            .catch(data => {
               this.showChangeBackgroundCompanyFail()
               console.log(data);
            })


         this.displayImageBackground = "block"

         var reader = new FileReader();

         reader.readAsDataURL(event.target.files[0]);

         reader.onload = (event) => {
            this.imageBackgroundSrc = event.target?.result;
         }
      }
   }
}
