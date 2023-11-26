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
  profile:any;

  getListPage(totalPage: number) {
    let list = []
    for (let i = 0; i < totalPage; i++) {
      let a = i + 1
      list.push(a)
    }
    return list
  }

  constructor(private router: Router, public dialog: MatDialog, private toastr: ToastrService) {
    this.profile = getProfile()
    console.log(this.profile);
    

    getRequest(`${apiRecruiter.GET_COMPANY_JDS_PAGING}/${this.profile.companyId}/${this.page}`, AuthorizationMode.PUBLIC)
      .then(res => {
        console.log(res?.data);
        this.listJds = res?.data
        this.totalItems = res?.objectLength

        for (let i = 0; i < this.listJds.length; i++) {
          this.listJds[i]['isShow'] = true;
        }
      })
      .catch(data => {
        console.warn('Lỗi',`${apiRecruiter.GET_COMPANY_JDS_PAGING}/${this.profile.companyId}/${this.page}`, data);
      })
  }

  pageChanged(page: any) {
    this.page = page
    getRequest(`${apiRecruiter.GET_COMPANY_JDS_PAGING}/${this.profile.companyId}/${this.page}`, AuthorizationMode.PUBLIC)
      .then(res => {
        this.listJds = res?.data
        this.totalItems = res?.objectLength
      })
      .catch(data => {
        console.warn('Lỗi',`${apiRecruiter.GET_COMPANY_JDS_PAGING}/${this.profile.companyId}/${this.page}`, data);
      })
  }

  onClickView(jd: any) {
    this.router.navigate(['/recruiter/view-jd-detail', jd?.jobId]);
  }

  onClickUpdate(jd: any) {
    this.router.navigate(['/recruiter/jd-detail', jd?.jobId]);
  }

  showSuccess() {
    this.toastr.success('Xoá công việc thành công', 'Thành công',  {
       progressBar: true,
       timeOut: 3000,
    });
 }

 showFail() {
    this.toastr.error('Xoá công việc thất bại <br/> Vui lòng thử lại sau', 'Thất bại', {
       progressBar: true,
       timeOut: 3000,
       enableHtml: true
    });
 }

  onClickDelete(jd: any) {
    //API handle delete JD
    postRequest(`${apiRecruiter.DELETE_JD_BY_ID}/${this.profile.id}/${jd?.jobId}`, AuthorizationMode.PUBLIC, {})
      .then(res => {
        if(res.statusCode == 200){
          this.showSuccess()
          jd.isShow = false;
        }
      })
      .catch(data => {
         this.showFail()
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
      } else if (result === false) {
      } else {
      }
    });
  }
}