import { Component, ViewEncapsulation } from '@angular/core';
import { getRequest, postRequest } from 'src/app/service/api-requests';
import { AuthorizationMode, apiCandidate } from 'src/app/service/constant';
import { ActivatedRoute } from '@angular/router';
import { environment } from 'src/environments/environment';
import { ToastrService } from 'ngx-toastr';
import { getProfile } from 'src/app/service/localstorage';
@Component({
  selector: 'app-jd-detail',
  templateUrl: './jd-detail.component.html',
  styleUrls: ['./jd-detail.component.css'],
  encapsulation: ViewEncapsulation.None
})

export class JdDetailComponent {

  jd: any;
  listCvs: any;
  jobDetail = "";
  educationRequirement = "";
  experienceRequirement = "";
  skillRequirement = "";
  certificateRequirement = "";
  projectRequirement = "";
  candidateBenefit = "";
  otherInformation = "";
  descriptionCompany = "";
  listJds: any;
  isExpiredDate = false
  JDId: any;
  profile: any
  selectedCV = "0"

  converTringDateInput(str: string) {
    const dateStr: string = str;
    const item = dateStr.split("/")
    const newDateString = item[1] + "-" + item[0] + "-" + item[2]
    const originalDate: Date = new Date(newDateString);
    return originalDate
  }

  constructor(private route: ActivatedRoute, private toastr: ToastrService) {
    this.profile = getProfile();

    let id: any;
    this.route.params.subscribe(params => {
      id = params['id'];
    });

    getRequest(apiCandidate.GET_JD_BY_ID, AuthorizationMode.PUBLIC, { jdId: id })
      .then(res => {
        this.jd = res?.data;
        this.JDId = this.jd.jobId
        this.jobDetail = this.jd?.jobDetail
        this.educationRequirement = this.jd?.educationRequirement
        this.experienceRequirement = this.jd?.experienceRequirement
        this.skillRequirement = this.jd?.skillRequirement
        this.certificateRequirement = this.jd?.certificateRequirement
        this.projectRequirement = this.jd?.projectRequirement
        this.candidateBenefit = this.jd?.candidateBenefit
        this.otherInformation = this.jd?.otherInformation
        this.descriptionCompany = this.jd?.companyDTO?.description

        const currenDate = new Date()
        const expiredDate = this.converTringDateInput(this.jd?.expiredDate)
        if (expiredDate < currenDate) {
          this.isExpiredDate = true
        }
      })
      .catch(data => {
        console.warn(apiCandidate.GET_JD_BY_ID, AuthorizationMode.PUBLIC, data);
      })

    getRequest(`${apiCandidate.GET_ALL_CV_BY_RECRUITER_ID}/${this.profile.id}`, AuthorizationMode.PUBLIC, {})
      .then(res => {

        this.listCvs = res?.data;
        console.log(this.listCvs);

      })
      .catch(data => {
        console.warn(apiCandidate.GET_JD_BY_ID, AuthorizationMode.PUBLIC, data);
      })
  }


  showSuccess() {
    this.toastr.success('Thông báo!', 'Ứng tuyển thành công! Xin lòng chờ đợi cho tới khi trạng thái ứng tuyển hoàn thành.', {
      progressBar: true,
      timeOut: 3000,
    });
  }

  showError() {
    this.toastr.error('Thông báo!', 'Ứng tuyển thất bại vui lòng thứ lại sau.', {
      progressBar: true,
      timeOut: 3000,
    });
  }

  showErrorChooseCv() {
    this.toastr.error('Thông báo!', 'Vui lòng chọn hồ sơ ứng tuyển.', {
      progressBar: true,
      timeOut: 3000,
    });
  }

  validateSubmitCv() {
    if (this.selectedCV == "0") {
      this.showErrorChooseCv()
      return false
    }
    return true
  }


  submitCv(event: any) {
    if (this.validateSubmitCv()) {
      postRequest(`${apiCandidate.CANDIDATE_APPLYJOB}?candidateId=${this.profile.id}&CVid=${this.selectedCV}&jobDescriptionId=${this.JDId}`, AuthorizationMode.PUBLIC, {})
        .then(res => {
          if (res?.statusCode == 200) {
            this.showSuccess()
            console.log(res);
          } else {
            this.showError()
            console.log(res);
          }
        })
        .catch(data => {
          this.showError()
          console.log(data);
        })
    }
  }
}
