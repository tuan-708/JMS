import { Component } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import ClassicEditor from '@ckeditor/ckeditor5-build-classic';

@Component({
   selector: 'app-jd-register',
   templateUrl: './jd-register.component.html',
   styleUrls: ['./jd-register.component.css']
})
export class JdRegisterComponent {
   public Editor = ClassicEditor;
   public editorData = '';
   public isBulletedListActive = true;

   constructor() {

   }

   public configDescription = {
      toolbar: {
         items: [
            'undo',
            'redo',
            '|',
            'heading',
            '|',
            'bold',
            'italic',
            'link',
            'bulletedList', // Add 'bulletedList' here
            'numberedList',
         ],
      },
      placeholder:'Nhập yêu cầu công việc'
   };

   public configRequirement = {...this.configDescription,placeholder:'Nhập yêu cầu kỹ năng'}
   public configCertificate = {...this.configDescription,placeholder:'Nhập yêu cầu chứng chỉ'}
   public configProject = {...this.configDescription,placeholder:'Nhập yêu cầu dự án'}
   public configBenefit = {...this.configDescription,placeholder:'Nhập yêu cầu quyền lợi'}
   public configrequirementAthor = {...this.configDescription,placeholder:'Nhập yêu cầu khác'}

   levelData = ['Thực tập sinh/ Sinh viên', 'Mới tốt nghiệp', 'Nhân viên', 'Trưởng phòng', 'Giám đốc và cấp cao hơn'];
   typeData = ['Toàn thời gian', 'Bán thời gian', 'Thực tập', 'Việc làm online', 'Nghề tự do', 'Hợp đồng thời vụ', 'Khác'];
   industryData = ['Giáo dục', 'Thời trang', 'Tài chính', 'Bảo hiểm', 'CNTT Phần mềm', 'Truyền thông', 'Khác']
   sexData = ['Nam', 'Nữ', 'Không yêu cầu']

   titleRq = new FormControl('', [Validators.required]);
   positionRq = new FormControl('', [Validators.required]);
   levelRq = new FormControl('0', [Validators.required, Validators.min(1)]);
   typeRq = new FormControl('0', [Validators.required, Validators.min(1)]);
   sexRq = new FormControl('0', [Validators.required, Validators.min(1)]);
   industryRq = new FormControl('0', [Validators.required, Validators.min(1)]);
   addressRq = new FormControl('', [Validators.required]);
   salaryMinRq = new FormControl('', [Validators.required, Validators.min(0)]);
   salaryMaxRq = new FormControl('', [Validators.required, Validators.min(0)]);
   descriptionRq = new FormControl('', [Validators.required]);
   requirementRq = new FormControl('', [Validators.required]);
   certificateRq = new FormControl('', [Validators.required]);
   projectRq = new FormControl('', [Validators.required]);
   requirementAthorRq = new FormControl('', [Validators.required]);
   benefitRq = new FormControl('', [Validators.required]);

   getErrorMessageTitle() {
      if (this.titleRq.hasError('required')) {
         return 'Tiêu đề không được để trống!'
      }
      return
   }
   getErrorMessagePosition() {
      if (this.positionRq.hasError('required')) {
         return 'Vị trí công việc không được để trống!'
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

   getErrorMessageSex() {
      if (this.levelRq.hasError('required')) {
         return 'Giới tính không được để trống!'
      }
      if (this.levelRq.hasError('min')) {
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
   getErrorMessageIndustry() {
      if (this.industryRq.hasError('required')) {
         return 'Lĩnh vực không được để trống!'
      }
      if (this.industryRq.hasError('min')) {
         return 'Lĩnh vực không được để trống!'
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
   getErrorMessageRequirement() {
      if (this.requirementRq.hasError('required')) {
         return 'Yêu cầu công việc không được để trống!'
      }
      return
   }

   getErrorMessageCertificate(){
      if (this.certificateRq.hasError('required')) {
         return 'Yêu cầu chứng chỉ không được để trống!'
      }
      return
   }

   getErrorMessageBenefit() {
      if (this.benefitRq.hasError('required')) {
         return 'Phúc lợi công việc không được để trống!'
      }
      return
   }

   checkReq: any = false;
   checkDes: any = false;
   checkBen: any = false;

   submitButtonClicked() {
      if (this.descriptionRq.valid && this.requirementRq.valid && this.benefitRq.valid) {
         return
      }

      this.checkReq = true;
      this.checkDes = true;
      this.checkBen = true;
      this.titleRq.markAllAsTouched()
      this.positionRq.markAllAsTouched()
      this.levelRq.markAllAsTouched()
      this.industryRq.markAllAsTouched()
      this.typeRq.markAllAsTouched()
      this.industryRq.markAllAsTouched()
      this.addressRq.markAllAsTouched()
      this.salaryMinRq.markAllAsTouched()
      this.salaryMaxRq.markAllAsTouched()
      this.descriptionRq.markAllAsTouched()
      this.requirementRq.markAllAsTouched()
      this.benefitRq.markAllAsTouched()

      console.log('submit button clicked')
      return
   }
}
