import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ListCandidateComponent } from '../list-candidate/list-candidate.component';
import { getRequest, postRequest } from 'src/app/service/api-requests';
import { AuthorizationMode, apiRecruiter } from 'src/app/service/constant';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-jd-detail',
  templateUrl: './jd-detail.component.html',
  styleUrls: ['./jd-detail.component.css']
})
export class JdDetailComponent {
  jdDetail: any
  id: any
  listCandidate: any


  constructor(public dialog: MatDialog, private route: ActivatedRoute) {
    this.route.params.subscribe(params => {
      this.id = params['id'];
    });

    getRequest(apiRecruiter.GET_JD_BY_ID, AuthorizationMode.PUBLIC, { jdId: this.id })
      .then(res => {
        this.jdDetail = res.data
        console.log(res);
      })
      .catch(data => {
        console.warn(apiRecruiter.GET_ALL_EMPLOYMENT_TYPE, data);
      })

      //fake data get applicant
    this.listCandidate = [{ id: 1, name: 'Nguyen Van An', dob: '01/10/1990', sex: 'Nam', avatar: 'https://png.pngtree.com/png-vector/20191101/ourmid/pngtree-cartoon-color-simple-male-avatar-png-image_1934459.jpg', email: 'abc@gmail.com' },
    { id: 2, name: 'Nguyen Van Binh', dob: '01/10/1990', sex: 'Nam', avatar: 'https://png.pngtree.com/png-vector/20191101/ourmid/pngtree-cartoon-color-simple-male-avatar-png-image_1934459.jpg', email: 'abc@gmail.com' },
    { id: 3, name: 'Nguyen Van Manh', dob: '01/10/1990', sex: 'Nam', avatar: 'https://png.pngtree.com/png-vector/20191101/ourmid/pngtree-cartoon-color-simple-male-avatar-png-image_1934459.jpg', email: 'abc@gmail.com' }]
  }

  openCandidateDialog(): void {
    this.dialog.open(ListCandidateComponent, {
      width: '60%',
      data: { type: 1, content: this.listCandidate }
    });
  }

  openApplicantDialog(): void {
    this.dialog.open(ListCandidateComponent, {
      width: '60%',
      data: { type: 2, content: this.listCandidate }
    });
  }

}
