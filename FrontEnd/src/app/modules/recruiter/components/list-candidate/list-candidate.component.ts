import { Component, Inject } from '@angular/core';
import {MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
@Component({
  selector: 'app-list-candidate',
  templateUrl: './list-candidate.component.html',
  styleUrls: ['./list-candidate.component.css'],
})
export class ListCandidateComponent {
  constructor(
    public dialogRef: MatDialogRef<ListCandidateComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) {}

    onClickView(candidate: any){
      alert('hehe')
    }
}
