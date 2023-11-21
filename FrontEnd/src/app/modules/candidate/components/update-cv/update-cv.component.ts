import { Component } from '@angular/core';
import { themeList } from './constant';
import { environment } from 'src/environments/environment';
import { ActivatedRoute } from '@angular/router';
import { getRequest, postFileRequest, postRequest } from 'src/app/service/api-requests';
import { AuthorizationMode, apiCandidate, apiRecruiter } from 'src/app/service/constant';
import { ToastrService } from 'ngx-toastr';
import { getProfile, isLogin } from 'src/app/service/localstorage';

declare var $: any;

@Component({
  selector: 'app-update-cv',
  templateUrl: './update-cv.component.html',
  styleUrls: ['./update-cv.component.css']
})
export class UpdateCvComponent {

}
