import { Component, ViewEncapsulation } from '@angular/core';
import { getRequest, postRequest } from 'src/app/service/api-requests';
import { AuthorizationMode, apiCandidate } from 'src/app/service/constant';
import { ActivatedRoute, Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { ToastrService } from 'ngx-toastr';
import { getProfile, signOut } from 'src/app/service/localstorage';
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
   isLogin = false
   pending = false

   convertStringDateInput(str: string) {
      const dateStr: string = str;
      const item = dateStr.split("/")
      const newDateString = item[1] + "-" + item[0] + "-" + item[2]
      const originalDate: Date = new Date(newDateString);
      return originalDate
   }


   showTokenExpiration() {
      this.toastr.info('Phiên đăng nhập hết hạn', 'Thông báo', {
         progressBar: true,
         timeOut: 3000,
      });
   }


   constructor(private route: ActivatedRoute, private toastr: ToastrService, private router: Router) {
      this.profile = getProfile();
      this.isLogin = this.profile !== null
      let id: any;
      this.route.params.subscribe(params => {
         id = params['id'];
      });

      getRequest(apiCandidate.GET_JD_BY_ID, AuthorizationMode.BEARER_TOKEN, { jdId: id })
         .then(res => {
            this.jd = res?.data;
            console.log(this.jd);

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

            const currentDate = new Date()
            const expiredDate = this.convertStringDateInput(this.jd?.expiredDate)
            if (expiredDate < currentDate) {
               this.isExpiredDate = true
            }
         })
         .catch(error => {
         })

         if(this.isLogin){
            getRequest(`${apiCandidate.GET_ALL_CV_BY_ID}/${this.profile.id}`, AuthorizationMode.BEARER_TOKEN, {})
            .then(res => {
   
               this.listCvs = res?.data;
               console.log(this.listCvs);
   
            })
            .catch(data => {
            })
         }
   }


   showSuccess() {
      this.toastr.success('Nhà tuyển dụng sẽ duyệt hồ sơ của bạn', 'Thành công', {
         progressBar: true,
         timeOut: 5000,
         enableHtml: true
      });
   }

   showError() {
      this.toastr.error('Ứng tuyển thất bại vui lòng thứ lại sau', 'Thất bại', {
         progressBar: true,
         timeOut: 5000,
      });
   }

   showErrorDuplicate() {
      this.toastr.error('Hồ sơ của bạn đã ứng tuyển', 'Thất bại', {
         progressBar: true,
         timeOut: 5000,
      });
   }

   showInfoChooseCv() {
      this.toastr.info('Vui lòng chọn hồ sơ ứng tuyển', 'Thông báo', {
         progressBar: true,
         timeOut: 5000,
      });
   }

   validateSubmitCv() {
      if (this.selectedCV == "0") {
         this.showInfoChooseCv()
         return false
      }
      return true
   }


   submitCv(event: any) {
      if (this.validateSubmitCv()) {
         this.pending = true
         postRequest(`${apiCandidate.CANDIDATE_APPLYJOB}?candidateId=${this.profile.id}&CVid=${this.selectedCV}&jobDescriptionId=${this.JDId}`, AuthorizationMode.BEARER_TOKEN, {})
            .then(res => {
               if (res?.statusCode == 200) {
                  this.showSuccess()
                  console.log(res);
                  this.pending = false
               }
               if (res?.statusCode == 204) {
                  this.showErrorDuplicate()
                  console.log(res);
                  this.pending = false
               }
               if (res?.statusCode == 400) {
                  this.showError()
                  console.log(res);
                  this.pending = false
               }
            })
            .catch(data => {
               this.showError()
               console.log(data);
               this.pending = false
            })
      }
   }
}
