import { Component } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import ClassicEditor from '@ckeditor/ckeditor5-build-classic';
import { getRequest, postRequest, putRequest, deleteRequest } from 'src/app/service/api-requests';
import { AuthorizationMode, apiRecruiter } from 'src/app/service/constant';
import { jd } from 'src/app/service/interfaces';

@Component({
   selector: 'app-jd-register',
   templateUrl: './jd-register.component.html',
   styleUrls: ['./jd-register.component.css']
})
export class JdRegisterComponent {
   public Editor = ClassicEditor;
   datas: any[] = [];
   categories: any;
   positions: any;
   employmentTypes: any;
   sexData = ['Nam', 'Nữ', 'Không yêu cầu']


   constructor() {
      getRequest(apiRecruiter.GET_ALL_CATEGORY, AuthorizationMode.PUBLIC, { page: 10 })
         .then(res => {
            this.categories = res.data
         })
         .catch(data => {
            console.warn(apiRecruiter.GET_ALL_CATEGORY, data);
         })

      getRequest(apiRecruiter.GET_ALL_POSITION_TITLE, AuthorizationMode.PUBLIC, { page: 10 })
         .then(res => {
            this.positions = res.data
         })
         .catch(data => {
            console.warn(apiRecruiter.GET_ALL_POSITION_TITLE, data);
         })

      getRequest(apiRecruiter.GET_ALL_EMPLOYMENT_TYPE, AuthorizationMode.PUBLIC, { page: 10 })
         .then(res => {
            this.employmentTypes = res.data
         })
         .catch(data => {
            console.warn(apiRecruiter.GET_ALL_EMPLOYMENT_TYPE, data);
         })
   }

   public configDescription = {
      toolbar: {
         items: [
            'undo',
            'redo',
            '|',
            'bulletedList', // Add 'bulletedList' here
         ],
      },
      placeholder: 'Nhập mô tả công việc'
   }

   public configExperienceRequirement = { ...this.configDescription, placeholder: 'Nhập yêu cầu kinh nghiệm' }
   public configSkillRequirement = { ...this.configDescription, placeholder: 'Nhập yêu kỹ năng' }
   public configCertificateRequirement = { ...this.configDescription, placeholder: 'Nhập yêu chứng chỉ' }
   public configProjectRequirement = { ...this.configDescription, placeholder: 'Nhập yêu cầu dự án' }
   public configBenefitRequirement = { ...this.configDescription, placeholder: 'Nhập yêu cầu quyền lợi' }
   public configOtherRequirement = { ...this.configDescription, placeholder: 'Nhập yêu cầu khác' }


   titleRq = new FormControl('', [Validators.required]);
   numberRequiredRq = new FormControl('', [Validators.required]);
   emailRq = new FormControl('');
   positionRq = new FormControl('', [Validators.required]);
   levelRq = new FormControl('0', [Validators.required, Validators.min(1)]);
   ageRequiredRq = new FormControl('',);
   genderRq = new FormControl('0', [Validators.required, Validators.min(1)]);
   typeRq = new FormControl('0', [Validators.required, Validators.min(1)]);
   categoryRq = new FormControl('0', [Validators.required, Validators.min(1)]);
   expiredDateRq = new FormControl('', [Validators.required]);
   addressRq = new FormControl('', [Validators.required]);
   salaryMinRq = new FormControl('', [Validators.required, Validators.min(0)]);
   salaryMaxRq = new FormControl('', [Validators.required, Validators.min(0)]);
   descriptionRq = new FormControl('', [Validators.required]);
   experienceRq = new FormControl('', [Validators.required]);
   skillRq = new FormControl('', [Validators.required]);
   certificateRq = new FormControl('', [Validators.required]);
   projectRq = new FormControl('', [Validators.required]);
   benefitRq = new FormControl('', [Validators.required]);
   otherRequired = new FormControl('', [Validators.required]);

   getErrorMessageTitle() {
      if (this.titleRq.hasError('required')) {
         return 'Tiêu đề không được để trống!'
      }
      return
   }

   getErrorMessageNumberRequired() {
      if (this.numberRequiredRq.hasError('required')) {
         return 'Số lượng tuyển dụng không được để trống!'
      }
      return
   }

   getErrorMessagePosition() {
      if (this.positionRq.hasError('required')) {
         return 'Chức danh công việc không được để trống!'
      }
      return
   }

   getErrorMessageLevel() {
      if (this.levelRq.hasError('required')) {
         return 'Cấp bậc không được để trống!'
      }
      if (this.levelRq.hasError('min')) {
         return 'Cấp bậc không được để trống!'
      }
      return
   }


   getErrorMessageGender() {
      if (this.genderRq.hasError('required')) {
         return 'Giới tính không được để trống!'
      }
      if (this.genderRq.hasError('min')) {
         return 'Giới tính không được để trống!'
      }
      return
   }

   getErrorMessageType() {
      if (this.typeRq.hasError('required')) {
         return 'Loại việc làm không được để trống!'
      }
      if (this.typeRq.hasError('min')) {
         return 'Loại việc làm không được để trống!'
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

   getErrorMessageExpiredDateRq() {
      if (this.expiredDateRq.hasError('required')) {
         return 'Ngày hết hạn không được để trống!'
      }
      return
   }

   getErrorMessageAddress() {
      if (this.addressRq.hasError('required')) {
         return 'Địa chỉ không được để trống!'
      }
      return
   }

   getErrorMessageMinSalary() {
      if (this.salaryMinRq.hasError('required')) {
         return 'Mức lương không được để trống!'
      }
      if (this.salaryMinRq.hasError('min')) {
         return 'Mức lương phải lớn hơn 0!'
      }
      return
   }

   getErrorMessageMaxSalary() {
      if (this.salaryMaxRq.hasError('required')) {
         return 'Mức lương không được để trống!'
      }
      if (this.salaryMaxRq.hasError('min')) {
         return 'Mức lương phải lớn hơn 0!'
      }
      return
   }

   getErrorMessageDescription() {
      if (this.descriptionRq.hasError('required')) {
         return 'Mô tả công việc không được để trống!'
      }
      return
   }

   getErrorMessageExperienceRequirement() {
      if (this.experienceRq.hasError('required')) {
         return 'Yêu cầu kinh nghiệm không được để trống!'
      }
      return
   }

   getErrorMessageSkillRequirement() {
      if (this.skillRq.hasError('required')) {
         return 'Yêu cầu kỹ năng không được để trống!'
      }
      return
   }

   getErrorMessageBenefitRequirement() {
      if (this.benefitRq.hasError('required')) {
         return 'Yêu cầu quyền lợi không được để trống!'
      }
      return
   }

   checkReq: any = false;
   checkDes: any = false;
   checkBen: any = false;

   submitButtonClicked() {
      if (this.titleRq.value && this.numberRequiredRq.value &&
         this.positionRq.value && this.levelRq.value &&
         this.genderRq.value && this.typeRq.value &&
         this.categoryRq.value && this.expiredDateRq.value &&
         this.addressRq.value && this.salaryMinRq.value &&
         this.salaryMaxRq.value && this.descriptionRq.valid && this.experienceRq.valid && this.benefitRq.valid) {

         const title = this.titleRq.value;
         const numberRequirement = this.numberRequiredRq.value;
         const email = this.emailRq.value;
         const position = this.positionRq.value;
         const level = this.levelRq.value;
         const age = this.ageRequiredRq.value;
         const gender = this.genderRq.value;
         const type = this.typeRq.value;
         const category = this.categoryRq.value;
         const expiredDate = this.expiredDateRq.value;
         const address = this.addressRq.value;
         const salaryMin = this.salaryMinRq.value;
         const salaryMax = this.salaryMaxRq.value;
         const description = this.descriptionRq.value;
         const experience = this.experienceRq.value;
         const skill = this.skillRq.value;
         const certificate = this.certificateRq.value;
         const project = this.projectRq.value;
         const benefit = this.benefitRq.value;
         const requirementOthor = this.otherRequired.value;


         console.log(title);
         console.log(numberRequirement);
         console.log(email);
         console.log(position);
         console.log(level);
         console.log(age);
         console.log(gender);
         console.log(type);
         console.log(category);
         console.log(expiredDate);
         console.log(address);
         console.log(salaryMin);
         console.log(salaryMax);
         console.log(description);
         console.log(experience);
         console.log(skill);
         console.log(certificate);
         console.log(project);
         console.log(benefit);
         console.log(requirementOthor);

         return
      }

      this.checkReq = true;
      this.checkDes = true;
      this.checkBen = true;
      this.titleRq.markAllAsTouched();
      this.numberRequiredRq.markAllAsTouched();
      this.positionRq.markAllAsTouched();
      this.levelRq.markAllAsTouched();
      this.genderRq.markAllAsTouched();
      this.typeRq.markAllAsTouched();
      this.categoryRq.markAllAsTouched();
      this.expiredDateRq.markAllAsTouched();
      this.addressRq.markAllAsTouched();
      this.salaryMinRq.markAllAsTouched();
      this.salaryMaxRq.markAllAsTouched();
      this.descriptionRq.markAllAsTouched();
      this.experienceRq.markAllAsTouched();
      this.skillRq.markAllAsTouched();
      this.benefitRq.markAllAsTouched();

      return
   }
}
