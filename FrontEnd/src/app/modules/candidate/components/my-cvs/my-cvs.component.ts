import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { getRequest, postRequest } from 'src/app/service/api-requests';
import { AuthorizationMode, apiCandidate } from 'src/app/service/constant';
import { getProfile, isLogin, signOut } from 'src/app/service/localstorage';
import { environment } from 'src/environments/environment';
import { ViewCvComponent } from '../view-cv/view-cv.component';
import { Router } from '@angular/router';
import { ConfirmDialogComponent } from 'src/app/components/confirm-dialog/confirm-dialog.component';
import { ToastrService } from 'ngx-toastr';
declare var $: any;

@Component({
   selector: 'app-my-cvs',
   templateUrl: './my-cvs.component.html',
   styleUrls: ['./my-cvs.component.css']
})

export class CandidateMyCvsComponent {
   Url = environment.Url;
   list = [1, 2, 3, 4, 5, 6, 7, 8, 9]
   listCVs: any;
   profile: any
   listJds: any

   ngAfterViewInit() {
      $('#prev').on('click', function () {
         $('#cards').animate({
            scrollLeft: '-=250'
         }, 300, 'swing');
      });

      $('#next').on('click', function () {
         $('#cards').animate({
            scrollLeft: '+=250'
         }, 300, 'swing');
      });
   }

   constructor(public dialog: MatDialog, private router: Router, private toastr: ToastrService) {

      this.profile = getProfile();

      getRequest(`${apiCandidate.GET_ALL_CV_BY_ID}/${this.profile.id}`, AuthorizationMode.BEARER_TOKEN, {})
         .then(res => {
            this.listCVs = res?.data

            this.listCVs.map((item:any) => console.log(item.lastUpdateDateDisplay))

            console.log(this.listCVs[0].lastUpdateDateDisplay);
         })
         .catch(data => {
         })


      getRequest(apiCandidate.GET_ALL_JDS_PAGING + "/" + 1, AuthorizationMode.BEARER_TOKEN)
         .then(res => {
            if (res?.statusCode == 200) {
               this.listJds = res?.data
            }
         })
         .catch(data => {
            this.router.navigate(['/candidate/sign-in']);
            this.showTokenExpiration()
            signOut()
         })
   }

   onClickJD(jd: any) {
      this.router.navigate(['/candidate/jd-detail/', jd?.jobId]);
   }

   gotoEditCV(id: number) {
      this.router.navigate([`/candidate/update-cv/`]);
   }

   showSuccess() {
      this.toastr.success('Xoá hồ sơ thành công', 'Thành công', {
         progressBar: true,
         timeOut: 3000,
      });
   }

   showError() {
      this.toastr.error('Xoá hồ sơ thất bại', 'Thất bại', {
         progressBar: true,
         timeOut: 3000,
      });
   }

   showTokenExpiration() {
      this.toastr.info('Phiên đăng nhập hết hạn', 'Thông báo', {
         progressBar: true,
         timeOut: 3000,
      });
   }


   onClickDelete(id: number) {
      postRequest(`${apiCandidate.DELETE_CV_BY_ID}?candidateId=${this.profile.id}&cvId=${id}`, AuthorizationMode.BEARER_TOKEN, {})
         .then(res => {
            if (res?.statusCode) {
               this.showSuccess()

               getRequest(`${apiCandidate.GET_ALL_CV_BY_ID}/${this.profile.id}`, AuthorizationMode.BEARER_TOKEN, {})
                  .then(res => {
                     this.listCVs = res?.data
                  })
                  .catch(data => {
                     console.warn(apiCandidate.GET_ALL_CV_BY_ID, data);
                  })
            }
         })
         .catch(data => {
            this.router.navigate(['/candidate/sign-in']);
            this.showTokenExpiration()
            signOut()
         })

   }

   gotoDeleteCV(id: number) {

      const dialogRef = this.dialog.open(ConfirmDialogComponent, {
         width: '350px',
         data: { title: 'Xác nhận', content: 'Bạn có xác nhận xóa hồ sơ không?' }
      });

      dialogRef.afterClosed().subscribe((result: boolean) => {
         if (result === true) {
            this.onClickDelete(id);
         } else if (result === false) {
         } else {
         }
      });
   }

   gotoUpdateCurrentCv(id: number) {

      postRequest(`${apiCandidate.CHANGE_FINDING_JOB_STATUS}?candidateId=${this.profile.id}&cvId=${id}`, AuthorizationMode.BEARER_TOKEN, {})
         .then(res => {
            if (res?.statusCode == 200) {
               getRequest(`${apiCandidate.GET_ALL_CV_BY_ID}/${this.profile.id}`, AuthorizationMode.BEARER_TOKEN, {})
                  .then(res => {
                     this.listCVs = res?.data
                     console.log(this.listCVs);
                  })
                  .catch(data => {
                     this.router.navigate(['/candidate/sign-in']);
                     this.showTokenExpiration()
                     signOut()
                  })

            } else {
               this.showError()
            }
         })
         .catch(data => {
            this.showError()
            console.error(apiCandidate.LOGIN_CANDIDATE);
         })

   }
}
