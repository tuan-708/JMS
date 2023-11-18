import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { getRequest } from 'src/app/service/api-requests';
import { AuthorizationMode, apiCandidate } from 'src/app/service/constant';
import { getProfile } from 'src/app/service/localstorage';
import { ViewCvComponent } from '../view-cv/view-cv.component';

@Component({
  selector: 'app-my-apply-job',
  templateUrl: './my-apply-job.component.html',
  styleUrls: ['./my-apply-job.component.css']
})
export class MyApplyJobComponent {
  listJds: any;
  profile: any;
  passenger: any;
  page = 1;
  itemsPerPage = 9;
  totalItems = 0;

  constructor(private router: Router,public dialog: MatDialog) {
    this.profile = getProfile();

    getRequest(`${apiCandidate.GET_ALL_CV_APPLIED}`, AuthorizationMode.PUBLIC, { candidateId: this.profile.id, pageIndex: 1 })
      .then(res => {
        this.listJds = res?.data

        this.totalItems = res?.objectLength

        for (let index = 0; index < this.listJds.length; index++) {
          this.listJds[index].award = JSON.parse(this.listJds[index].award)
          this.listJds[index].certificate = JSON.parse(this.listJds[index].certificate)
          this.listJds[index].education = JSON.parse(this.listJds[index].education)
          this.listJds[index].jobExperience = JSON.parse(this.listJds[index].jobExperience)
          this.listJds[index].jsonMatching = JSON.parse(this.listJds[index].jsonMatching)
          this.listJds[index].project = JSON.parse(this.listJds[index].project)
          this.listJds[index].skill = JSON.parse(this.listJds[index].skill)
          console.log(this.listJds);

        }
      })
      .catch(data => {
        console.warn(apiCandidate.GET_ALL_CV_APPLIED, data);
      })
  }

  pageChanged(page: any) {
    this.page = page
    getRequest(`${apiCandidate.GET_ALL_CV_APPLIED}`, AuthorizationMode.PUBLIC, { candidateId: this.profile.id, page: this.page })
      .then(res => {
        this.listJds = res?.data

      })
      .catch(data => {
        console.warn(`${apiCandidate.GET_ALL_CV_APPLIED}`);
      })
  }

  onClickViewJD(jd: any) {
    this.router.navigate([`/candidate/jd-detail/${jd?.jobDescriptionId}`]);
  }

  openViewCVDialog(jd:any){

      console.log("Tuan", jd);
      
      this.dialog.open(ViewCvComponent, {
        width: '55%',
        height: '100%',
        data: {jd}
      });
  }
}
