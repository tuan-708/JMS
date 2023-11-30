import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ListCandidateComponent } from '../list-candidate/list-candidate.component';
import { getRequest, postRequest } from 'src/app/service/api-requests';
import { AuthorizationMode, apiRecruiter } from 'src/app/service/constant';
import { ActivatedRoute } from '@angular/router';
import { OptionMatchModalComponent } from '../option-match-modal/option-match-modal.component';
import { ToastrService } from 'ngx-toastr';
import { environment } from 'src/environments/environment';
import { ViewportScroller } from '@angular/common';

@Component({
  selector: 'app-jd-detail',
  templateUrl: './jd-detail.component.html',
  styleUrls: ['./jd-detail.component.css']
})
export class JdDetailComponent {
  jdDetail: any
  id: any
  listCandidate: any
  jobDescription: any
  jobBenefit: any
  jobRequirement: any
  matchOption: any
  descriptionJd: any
  jobRequirementJd: any
  skillRequirementJd: any
  experienceRequirementJd: any
  educationRequirementJd: any
  candidateBenefitJd: any
  isMatching: boolean = false;
  Url = environment.Url;

  showTokenExpiration() {
    this.toastr.info('Phiên đăng nhập hết hạn', 'Thông báo', {
       progressBar: true,
       timeOut: 3000,
    });
 }

  constructor(public dialog: MatDialog, private route: ActivatedRoute, private toastr: ToastrService, private viewportScroller: ViewportScroller) {
    this.route.params.subscribe(params => {
      this.id = params['id'];
    });

    this.viewportScroller.scrollToPosition([0, 0]);

    //get jd detail
    getRequest(apiRecruiter.GET_JD_BY_ID, AuthorizationMode.BEARER_TOKEN, { jdId: this.id })
      .then(res => {
        this.jdDetail = res.data
        console.log(res);
        this.handleData();
      })
      .catch(data => {
        console.warn(apiRecruiter.GET_ALL_EMPLOYMENT_TYPE, data);
      })
  }

  openMatchingDialog(): void {
    const dialogRef = this.dialog.open(OptionMatchModalComponent, {
      width: '40%'
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result !== undefined) {
        this.matchOption = result;
        console.log(this.matchOption);
        this.isMatching = true;
        this.showSuccess();
        // call matching api
        postRequest(apiRecruiter.MATCHING_JOB + "?recruiterId=" + this.jdDetail.recuirterId + "&jobDescriptionId=" + this.jdDetail.jobId + "&numberRequirement=" + this.matchOption.quantity, AuthorizationMode.BEARER_TOKEN, {})
          .then(res => {
            if (res.statusCode == 200) {
              this.isMatching = false;
              this.showInfo();
            }else{
              this.showError();
            }
            console.log(res);
          })
          .catch(data => {
            this.showError();
            console.log(data);
          })
      }
    });
  }

  openCandidateDialog(type: any): void {
    // type 0: matched list 
    // type 1: matched list left
    // type 2: selected list
    const typeCandidate = type == 0 ? apiRecruiter.GET_CV_MATCHED : type == 1 ? apiRecruiter.GET_CV_MATCHED_LEFT : apiRecruiter.GET_CV_SELECTED
    getRequest(typeCandidate, AuthorizationMode.BEARER_TOKEN, { recruiterId: this.jdDetail.recuirterId, jobDescriptionId: this.jdDetail.jobId, pageIndex: 1 })
      .then(res => {
        this.listCandidate = res.data
        console.log(res.data);

        this.dialog.open(ListCandidateComponent, {
          width: '60%',
          data: {listType: type, recruiterId: this.jdDetail.recuirterId, jdId:this.jdDetail.jobId, content: this.listCandidate }
        });
      })
      .catch(data => {
        console.warn(data);
      })
  }

  handleData() {
    this.descriptionJd = this.handleText(this.jdDetail.jobDetail);
    this.candidateBenefitJd = this.handleText(this.jdDetail.candidateBenefit);
    this.skillRequirementJd = this.handleText(this.jdDetail.skillRequirement);
    this.experienceRequirementJd = this.handleText(this.jdDetail.experienceRequirement);
    this.educationRequirementJd = this.handleText(this.jdDetail.educationRequirement);
    // this.jobRequirementJd = this.handleText(skillRq) + '\n' + this.handleText(expRq) + '\n' + this.handleText(eduRq)
  }

  handleText(text: string) {
    const lines: string[] = text.trim().split('\n');
    const linesWithHyphen: string[] = lines.map((line: string) => (line.startsWith('-') ? line : `${line}`));
    const newText: string = linesWithHyphen.join('\n');
    return newText
  }

  showSuccess() {
    this.toastr.success('Xác nhận thành công <br/> Hệ thống đang tìm ứng viên phù hợp', 'Thành công' ,{
       progressBar: true,
       timeOut: 3000,
       enableHtml: true
    });
  }

  showInfo() {
    this.toastr.success('Đề xuất thành công <br/> Vui lòng xem chi tiết tại danh sách đề xuất', 'Thành công',{
       progressBar: true,
       timeOut: 3000,
       enableHtml: true
    });
  }

  showError() {
    this.toastr.error('Đề xuất thất bại <br/> Vui lòng thử lại sau', 'Thất bại',{
       progressBar: true,
       timeOut: 3000,
       enableHtml: true
    });
  }
}
