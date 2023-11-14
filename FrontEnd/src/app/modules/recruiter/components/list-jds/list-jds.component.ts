import { Component, ViewEncapsulation } from '@angular/core';
import { getRequest, postRequest, postFileRequest } from 'src/app/service/api-requests';
import { AuthorizationMode, apiRecruiter } from 'src/app/service/constant';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmDialogComponent } from 'src/app/components/confirm-dialog/confirm-dialog.component';
import { getToken, saveItem, signOut, getProfile } from 'src/app/service/localstorage';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-list-jds',
  templateUrl: './list-jds.component.html',
  styleUrls: ['./list-jds.component.css'],
  encapsulation: ViewEncapsulation.None
})

export class ListJdsComponent {

  listJds: any;

  page = 0;
  passenger: any;
  itemsPerPage = 8;
  totalItems = 0;
  isDivHidden: boolean = false;

  getListPage(totalPage: number) {
    let list = []
    for (let i = 0; i < totalPage; i++) {
      let a = i + 1
      list.push(a)
    }
    return list
  }

  constructor(private router: Router, public dialog: MatDialog, private toastr: ToastrService) {
    getRequest(apiRecruiter.GET_COMPANY_JDS_PAGING + "/2/" + this.page, AuthorizationMode.PUBLIC)
      .then(res => {
        console.log(res?.data);
        this.listJds = res?.data
        this.totalItems = res?.objectLength

        for (let i = 0; i < this.listJds.length; i++) {
          this.listJds[i]['isShow'] = true;
        }
      })
      .catch(data => {
        console.log('fail:' + data)
        console.warn(apiRecruiter.GET_COMPANY_JDS_PAGING + "/1/1", data);
      })
  }

  pageChanged(page: any) {
    this.page = page
    getRequest(apiRecruiter.GET_COMPANY_JDS_PAGING + "/1/" + this.page, AuthorizationMode.PUBLIC)
      .then(res => {
        this.listJds = res?.data
        this.totalItems = res?.objectLength
      })
      .catch(data => {
        console.warn(apiRecruiter.GET_COMPANY_JDS_PAGING + "/1/" + this.page, data);
      })
  }

  onClickView(jd: any) {
    this.router.navigate(['/recruiter/view-jd-detail', jd?.jobId]);
  }

  onClickUpdate(jd: any) {
    this.router.navigate(['/recruiter/jd-detail', jd?.jobId]);
  }

  onClickDelete(jd: any) {
    jd.isShow = false;
    //API handle delete JD
    postRequest(apiRecruiter.DELETE_JD_BY_ID + "2/" + jd?.jobId, AuthorizationMode.PUBLIC, {})
      .then(res => {
         console.log(res);
      })
      .catch(data => {
         console.log(data);
      })
  }

  openDialog(jd: any): void {
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      width: '350px',
      data: { title: 'Xác nhận', content: 'Bạn có xác nhận xóa bài viết không?' }
    });

    dialogRef.afterClosed().subscribe((result: boolean) => {
      if (result === true) {
        this.onClickDelete(jd);
        console.log('User clicked Yes');
      } else if (result === false) {
        console.log('User clicked No');
      } else {
        console.log('Dialog closed without a choice');
      }
    });
  }
}