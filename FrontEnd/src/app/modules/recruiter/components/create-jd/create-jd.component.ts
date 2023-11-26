import { Component } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import ClassicEditor from '@ckeditor/ckeditor5-build-classic';
import { ToastrService } from 'ngx-toastr';
import { getRequest, postRequest } from 'src/app/service/api-requests';
import { AuthorizationMode, apiRecruiter } from 'src/app/service/constant';
import { getProfile } from 'src/app/service/localstorage';

@Component({
   selector: 'app-create-jd',
   templateUrl: './create-jd.component.html',
   styleUrls: ['./create-jd.component.css']
})

export class CreateJdComponent {
   public Editor = ClassicEditor;
   datas: any[] = [];
   categories: any;
   levels: any;
   employmentTypes: any;
   genders: any;
   profile: any;

   constructor(private toastr: ToastrService) {
      this.profile = getProfile();

      getRequest(apiRecruiter.GET_ALL_CATEGORY, AuthorizationMode.PUBLIC, { page: 10 })
         .then(res => {
            this.categories = res.data
         })
         .catch(data => {
            console.warn(apiRecruiter.GET_ALL_CATEGORY, data);
         })

      getRequest(apiRecruiter.GET_ALL_GENDER, AuthorizationMode.PUBLIC, { page: 10 })
         .then(res => {
            this.genders = res.data
         })
         .catch(data => {
            console.warn(apiRecruiter.GET_ALL_GENDER, data);
         })

      getRequest(apiRecruiter.GET_ALL_LEVEL_TITLE, AuthorizationMode.PUBLIC, { page: 10 })
         .then(res => {
            this.levels = res.data
         })
         .catch(data => {
            console.warn(apiRecruiter.GET_ALL_LEVEL_TITLE, data);
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
   public configEducationRequirement = { ...this.configDescription, placeholder: 'Nhập yêu cầu học vấn' }
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
   salaryRq = new FormControl('', [Validators.required, Validators.min(0)]);
   descriptionRq = new FormControl('', [Validators.required]);
   educationRq = new FormControl('', [Validators.required]);
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
      if (this.salaryRq.hasError('required')) {
         return 'Mức lương không được để trống!'
      }
      if (this.salaryRq.hasError('min')) {
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

      
   showCreateJDSuccess() {
      this.toastr.success('Tạo bài viết thành công', 'Thành công',  {
         progressBar: true,
         timeOut: 3000,
      });
   }

   showCreateJDFail() {
      this.toastr.error('Tạo bài viết thất bại', 'Thất bại', {
         progressBar: true,
         timeOut: 3000,
      });
   }


   submitButtonClicked() {
      if (this.titleRq.valid && this.numberRequiredRq.valid &&
         this.positionRq.valid && this.levelRq.valid &&
         this.genderRq.valid && this.typeRq.valid &&
         this.categoryRq.valid && this.expiredDateRq.valid &&
         this.addressRq.valid && this.salaryRq.valid && this.descriptionRq.valid && this.experienceRq.valid && this.benefitRq.valid) {

         const title = this.titleRq.value;
         const numberRequirement = this.numberRequiredRq.value;
         const contactEmail = this.emailRq.value;
         const positionTitle = this.positionRq.value;
         const levelTitle = this.levelRq.value;
         const ageRequirement = this.ageRequiredRq.value;
         const genderRequirement = this.genderRq.value;
         const employmentTypeName = this.typeRq.value;
         const categoryName = this.categoryRq.value;
         const expiredDate = this.expiredDateRq.value;
         const address = this.addressRq.value;
         const salary = this.salaryRq.value;
         const jobDetail = this.descriptionRq.value;
         const educationRequirement = this.educationRq.value;
         const experienceRequirement = this.experienceRq.value;
         const skillRequirement = this.skillRq.value;
         const certificateRequirement = this.certificateRq.value;
         const projectRequirement = this.projectRq.value;
         const candidateBenefit = this.benefitRq.value;
         const otherInformation = this.otherRequired.value;

         const data = {
            title: title,
            employmentTypeName: employmentTypeName,
            genderRequirement: genderRequirement,
            ageRequirement: ageRequirement,
            educationRequirement: educationRequirement,
            jobDetail: jobDetail,
            experienceRequirement: experienceRequirement,
            projectRequirement: projectRequirement,
            skillRequirement: skillRequirement,
            certificateRequirement: certificateRequirement,
            otherInformation: otherInformation,
            candidateBenefit: candidateBenefit,
            salary: salary,
            contactEmail: contactEmail,
            address: address,
            numberRequirement: numberRequirement,
            companyName: this.profile.companyId.toString(),
            categoryName: categoryName,
            expiredDate: expiredDate,
            levelTitle: levelTitle,
            positionTitle: positionTitle,
            companyDTO: {
               "companyId": this.profile.companyId,
               "companyName": "string",
               "email": "string",
               "phone": "string"
            },
         }

         postRequest(`${apiRecruiter.POST_CREATE_JD}/${this.profile.id}`, AuthorizationMode.PUBLIC, data)
            .then(res => {
               this.showCreateJDSuccess()
               console.log(res);
            })
            .catch(data => {
               this.showCreateJDFail()
               console.log(data);
            })


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
      this.salaryRq.markAllAsTouched();
      this.descriptionRq.markAllAsTouched();
      this.experienceRq.markAllAsTouched();
      this.skillRq.markAllAsTouched();
      this.benefitRq.markAllAsTouched();

      return
   }
}
