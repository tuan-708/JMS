import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { getRequest, postRequest } from 'src/app/service/api-requests';
import { AVATAR_DEFAULT_URL, AuthorizationMode, apiRecruiter } from 'src/app/service/constant';
@Component({
  selector: 'app-list-candidate',
  templateUrl: './list-candidate.component.html',
  styleUrls: ['./list-candidate.component.css'],
})
export class ListCandidateComponent {
  avatar: any = AVATAR_DEFAULT_URL

  constructor(
    public dialogRef: MatDialogRef<ListCandidateComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) { }

  onClickView(candidate: any) {
    alert('hehe')
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
    getRequest(apiRecruiter.GET_CV_MATCHED_LEFT, AuthorizationMode.PUBLIC, { recruiterId: this.data.recruiterId, jobDescriptionId: this.data.jdId, pageIndex: 1 })
      .then(res => {
        this.data.content += res.data
        console.log(res.data);
      })
      .catch(data => {
        console.warn(data);
      })
  }
}
