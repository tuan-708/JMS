import { Component, Input  } from '@angular/core';
import { getRequest, postRequest, postFileRequest } from 'src/app/service/api-requests';
import { AuthorizationMode, apiRecruiter } from 'src/app/service/constant';
import { Router } from '@angular/router';

@Component({
  selector: 'app-list-jds',
  templateUrl: './list-jds.component.html',
  styleUrls: ['./list-jds.component.css']
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

  constructor(private router: Router) {
    // getRequest(apiRecruiter.GET_COMPANY_JDS_PAGING + "/1/" + this.page, AuthorizationMode.PUBLIC)
    //   .then(res => {
    //     this.listJds = res?.data
    //     this.totalItems = res?.objectLength
    //   })
    //   .catch(data => {
    //     console.warn(apiRecruiter.GET_COMPANY_JDS_PAGING + "/1/1", data);
    //   })

    this.listJds = [{jobId: 1,title: 'TITLE', numberRequirement: '999', positionTitle: 'POSITION TITLE', levelTitle: 'LELVEL TITLE', salary: '999.999'}, {title: 'TITLE', numberRequirement: '999', positionTitle: 'POSITION TITLE', levelTitle: 'LELVEL TITLE', salary: '999.999'}, {title: 'TITLE', numberRequirement: '999', positionTitle: 'POSITION TITLE', levelTitle: 'LELVEL TITLE', salary: '999.999'}]
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

  onClick(jd: any){

    this.router.navigate(['/recruiter/jd-detail', jd?.jobId]);
  }

  onClickUpdate(jd: any){

    this.router.navigate(['/recruiter/jd-detail', jd?.jobId]);
  }

  onClickDelete(jd: any){
    this.isDivHidden = true;
    //API handle delete JD here
  }
}
