import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { getRequest, postRequest } from 'src/app/service/api-requests';
import { showError, showSuccess } from 'src/app/service/common';
import { ADMIN_PROFILE, ADMIN_TOKEN, AuthorizationMode, apiAdmin } from 'src/app/service/constant';
import { saveItem } from 'src/app/service/localstorage';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class AdminSignInComponent {
  constructor(private toarst: ToastrService, private router: Router) { }

  login(username: HTMLInputElement, password: HTMLInputElement) {
    const data = { username: username.value, password: password.value }

    postRequest(apiAdmin.LOGIN_ADMIN, AuthorizationMode.PUBLIC, data)
      .then(res => {
        if (res?.statusCode == 200) {
          saveItem(ADMIN_TOKEN, res.data)
          // this.getAdminProfile(res.data.)
          showSuccess(this.toarst, "Đăng nhập thành công!")
          this.router.navigate(['/admin/'])
        } else {
          showError(this.toarst, "Sai tài khoản hoặc mật khẩu")
        }
      })
      .catch(data => {
        showError(this.toarst, "Sai tài khoản hoặc mật khẩu")
        console.error(data);
      })
  }

  getAdminProfile(id: any) {
    getRequest(apiAdmin.GET_ADMIN_PROFILE + id, AuthorizationMode.PUBLIC)
      .then(res => {
        if (res?.statusCode == 200) {
          saveItem(ADMIN_PROFILE, res.data)
        }
      })
      .catch(data => {
        console.error("Get api 'getAdminProfile' fail:" + data);
      })
  }
}
