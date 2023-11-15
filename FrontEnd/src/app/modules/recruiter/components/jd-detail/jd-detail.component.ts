import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ListCandidateComponent } from '../list-candidate/list-candidate.component';
import { getRequest, postRequest } from 'src/app/service/api-requests';
import { AuthorizationMode, apiRecruiter } from 'src/app/service/constant';
import { ActivatedRoute } from '@angular/router';
import { OptionMatchModalComponent } from '../option-match-modal/option-match-modal.component';

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
  educationRequirementJd:any
  candidateBenefitJd:any
  isMatching: boolean = false;

  constructor(public dialog: MatDialog, private route: ActivatedRoute) {
    this.route.params.subscribe(params => {
      this.id = params['id'];
    });

    //get jd detail
    getRequest(apiRecruiter.GET_JD_BY_ID, AuthorizationMode.PUBLIC, { jdId: this.id })
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
        // call matching api
        postRequest(apiRecruiter.MATCHING_JOB, AuthorizationMode.PUBLIC, { recruiterId: this.jdDetail.recuirterId, jobDescriptionId: this.jdDetail.jobId, numberRequirement: this.matchOption.quantity })
          .then(res => {
            console.log(res);
          })
          .catch(data => {
            console.log(data);
          })
      }
    });
  }

  openCandidateDialog(type: any): void {
    // type 0: matched list 
    // type 1: applied list 
    // type 2: seelected list
    const typeCandidate = type == 0 ? apiRecruiter.GET_CV_MATCHED : type == 1 ? apiRecruiter.GET_CV_APPLIED : apiRecruiter.GET_CV_SELECTED
    getRequest(typeCandidate, AuthorizationMode.PUBLIC, { recruiterId: this.jdDetail.recuirterId, jobDescriptionId: this.jdDetail.jobId, pageIndex: 1 })
      .then(res => {
        this.listCandidate = res.data
        console.log(res.data);

        this.dialog.open(ListCandidateComponent, {
          width: '60%',
          data: { type: 1, content: this.listCandidate }
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
  }

  handleText(text: string) {
    const lines: string[] = text.trim().split('\n');
    const linesWithHyphen: string[] = lines.map((line: string) => (line.startsWith('-') ? line : `${line}`));
    const newText: string = linesWithHyphen.join('\n');
    return newText
  }
}
