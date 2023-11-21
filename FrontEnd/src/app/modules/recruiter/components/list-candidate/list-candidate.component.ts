import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';
import { PageEvent } from '@angular/material/paginator';
import { ViewCvComponent } from 'src/app/modules/candidate/components/view-cv/view-cv.component';
import { getRequest, postRequest } from 'src/app/service/api-requests';
import { AVATAR_DEFAULT_URL, AuthorizationMode, apiRecruiter } from 'src/app/service/constant';
@Component({
  selector: 'app-list-candidate',
  templateUrl: './list-candidate.component.html',
  styleUrls: ['./list-candidate.component.css'],
})
export class ListCandidateComponent {
  avatar: any = AVATAR_DEFAULT_URL
  pageIndex: any = 0
  pageSize: any = 5
  listDisplay: any
  isShowLeftMatched: boolean = false

  constructor(
    public dialogRef: MatDialogRef<ListCandidateComponent>,
    public dialog: MatDialog,
    @Inject(MAT_DIALOG_DATA) public data: any) {
      this.getPageRange()
  }

  onClickSelect(item: any) {
    //call api update cv selected status
    postRequest(apiRecruiter.UPDATE_CV_SELECTED_STATUS + "?recruiterId=" + this.data.recruiterId + "&jobDescriptionId=" + item.jobDescriptionId + "&CVMatchingId=" + item.id, AuthorizationMode.PUBLIC, {})
      .then(res => {
        if (res.statusCode == 200) {
          item.isSelected = item.isSelected == 0 ? 1 : 0
        }
        console.log(res);
      })
      .catch(data => {
        console.log(data);
      })
  }

  openListCandidateLeft(): void {
    if(this.isShowLeftMatched == true) return;
    getRequest(apiRecruiter.GET_CV_MATCHED_LEFT, AuthorizationMode.PUBLIC, { recruiterId: this.data.recruiterId, jobDescriptionId: this.data.jdId, pageIndex: this.pageIndex+1 })
      .then(res => {
        if (res.data != null) {
          this.data.content = this.data.content.concat(res.data)
          this.getPageRange()
          this.isShowLeftMatched = true
        }
      })
      .catch(data => {
        console.warn(data);
      })
  }

  openViewCVModal(jd: any) {
    this.dialogRef.close();

    jd.award = JSON.parse(jd.award)
    jd.certificate = JSON.parse(jd.certificate)
    jd.education = JSON.parse(jd.education)
    jd.jobExperience = JSON.parse(jd.jobExperience)
    jd.jsonMatching = JSON.parse(jd.jsonMatching)
    jd.project = JSON.parse(jd.project)
    jd.skill = JSON.parse(jd.skill)
    this.dialog.open(ViewCvComponent, {
      width: '55%',
      height: '85%',
      data: { jd }
    });
  }

  handlePage(e: PageEvent) {
    this.pageSize = e.pageSize;
    this.pageIndex = e.pageIndex;
    this.getPageRange();
  }

  getPageRange() {
    const start = this.pageIndex * this.pageSize;
    const end = Math.min((this.pageIndex + 1) * this.pageSize, this.data.content.length);
    this.listDisplay = this.data.content.slice(start, end)
  }
}
