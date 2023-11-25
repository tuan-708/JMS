import { Component } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import ClassicEditor from '@ckeditor/ckeditor5-build-classic';
import { ToastrService } from 'ngx-toastr';
import { getRequest, postRequest } from 'src/app/service/api-requests';
import { AuthorizationMode, apiRecruiter } from 'src/app/service/constant';
import { getProfile } from 'src/app/service/localstorage';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-jd-update',
  templateUrl: './jd-update.component.html',
  styleUrls: ['./jd-update.component.css']
})
export class JdUpdateComponent {
  public Editor = ClassicEditor;
  categories: any;
  levels: any;
  employmentTypes: any;
  genders: any;
  jdDetail: any;
  id: any;
  profile: any;
  startDate: any
  endDate: any

  constructor(private route: ActivatedRoute, private toastr: ToastrService, public datePipe: DatePipe) {
    this.profile = getProfile();

    getRequest(apiRecruiter.GET_ALL_CATEGORY, AuthorizationMode.PUBLIC, { page: 10 })
      .then(res => {
        this.categories = res?.data
      })
      .catch(data => {
        console.warn(apiRecruiter.GET_ALL_CATEGORY, data);
      })

    getRequest(apiRecruiter.GET_ALL_GENDER, AuthorizationMode.PUBLIC, { page: 10 })
      .then(res => {
        this.genders = res?.data
      })
      .catch(data => {
        console.warn(apiRecruiter.GET_ALL_GENDER, data);
      })

    getRequest(apiRecruiter.GET_ALL_LEVEL_TITLE, AuthorizationMode.PUBLIC, { page: 10 })
      .then(res => {
        this.levels = res?.data
      })
      .catch(data => {
        console.warn(apiRecruiter.GET_ALL_LEVEL_TITLE, data);
      })

    getRequest(apiRecruiter.GET_ALL_EMPLOYMENT_TYPE, AuthorizationMode.PUBLIC, { page: 10 })
      .then(res => {
        this.employmentTypes = res?.data
      })
      .catch(data => {
        console.warn(apiRecruiter.GET_ALL_EMPLOYMENT_TYPE, data);
      })


    this.route.params.subscribe(params => {
      this.id = params['id'];
    });

    getRequest(apiRecruiter.GET_JD_BY_ID, AuthorizationMode.PUBLIC, { jdId: this.id })
      .then(res => {
        this.jdDetail = res.data
        console.log(res);
        this.formatDate();
        this.setValueInput()
      })
      .catch(data => {
        console.warn(apiRecruiter.GET_ALL_EMPLOYMENT_TYPE, data);
      })
  }

  setValueInput() {
    this.titleRq.setValue(this.jdDetail?.title)
    this.numberRequiredRq.setValue(this.jdDetail?.numberRequirement)
    this.emailRq.setValue(this.jdDetail?.contactEmail)
    this.positionRq.setValue(this.jdDetail?.positionTitle)


    const selectlevel = this.levels.find((level: any) => level?.title === this.jdDetail?.levelTitle)
    this.levelRq.setValue(selectlevel?.id.toString() ? selectlevel?.id.toString() : "0");

    const selectGender = this.genders.find((gender: any) => gender?.title === this.jdDetail?.genderRequirement)
    this.genderRq.setValue(selectGender?.genderId.toString() ? selectGender?.genderId.toString() : "0")

    const selectCategoty = this.categories.find((cate: any) => cate?.categoryName === this.jdDetail?.categoryName)
    this.categoryRq.setValue(selectCategoty?.id.toString())

    const selectEmlementType = this.employmentTypes.find((elm: any) => elm?.title === this.jdDetail?.employmentTypeName)
    this.typeRq.setValue(selectEmlementType?.id.toString())

    // const createAt = this.converTringDateInput(this.jdDetail?.createdAt)
    // this.CreateAtRq.setValue(createAt)

    // const expiredDate = this.converTringDateInput(this.jdDetail?.expiredDate)
    this.expiredDateRq.setValue(this.endDate)

    this.addressRq.setValue(this.jdDetail?.address)
    console.log(this.addressRq.value)
    this.salaryRq.setValue(this.jdDetail?.salary)
    this.descriptionRq.setValue(this.jdDetail?.jobDetail)
    this.educationRq.setValue(this.jdDetail?.educationRequirement)
    this.skillRq.setValue(this.jdDetail?.skillRequirement)
    this.experienceRq.setValue(this.jdDetail?.experienceRequirement)
    this.certificateRq.setValue(this.jdDetail?.certificateRequirement)
    this.projectRq.setValue(this.jdDetail?.projectRequirement)
    this.benefitRq.setValue(this.jdDetail?.candidateBenefit)
    this.otherRequired.setValue(this.jdDetail?.otherInformation)

  }


  converTringDateInput(str: string) {
    const dateStr: string = str;
    const originalDate: Date = new Date(dateStr);
    const formattedDate: string = originalDate.toISOString().split('T')[0];
    return formattedDate
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
  CreateAtRq = new FormControl('');
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

  showUpdateJDSuccess() {
    this.toastr.info('Thông báo!', 'Cập nhật bài viết thành công!', {
       progressBar: true,
       timeOut: 3000,
    });
 }

 showUpdateJDFail() {
    this.toastr.error('Thông báo!', 'Cập nhật bài viết thất bại!', {
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
      const createdAt = this.CreateAtRq.value;
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
        jobId: this.jdDetail?.jobId,
        title: title,
        createdAt: createdAt,
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
        companyName: this.profile.companyId,
        categoryName: categoryName,
        expiredDate: expiredDate,
        levelTitle: levelTitle,
        positionTitle: positionTitle
      }

      postRequest(`${apiRecruiter.UPDATE_JD_BY_RECRUITER}/${this.profile.id}`, AuthorizationMode.PUBLIC, data)
        .then(res => {
          this.showUpdateJDSuccess()
          console.log(res);
        })
        .catch(data => {
          this.showUpdateJDFail()
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

  formatDate(): void {
    // Parse start date the string into a Date object
    const dateParts = this.jdDetail.createdAt.split('/');
    const year = +dateParts[2];
    const month = +dateParts[1] - 1;
    const day = +dateParts[0];

    const date = new Date(year, month, day);

    // Parse end date the string into a Date object
    const dateParts2 = this.jdDetail.expiredDate.split('/');
    const year2 = +dateParts2[2];
    const month2 = +dateParts2[1] - 1;
    const day2 = +dateParts2[0];

    const date2 = new Date(year2, month2, day2);

    // Format the date using DatePipe
    this.startDate = this.datePipe.transform(date, 'yyyy-MM-dd');
    this.endDate = this.datePipe.transform(date2, 'yyyy-MM-dd');
  }
}
