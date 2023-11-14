import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AVATAR_DEFAULT_URL } from 'src/app/service/constant';
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
}
