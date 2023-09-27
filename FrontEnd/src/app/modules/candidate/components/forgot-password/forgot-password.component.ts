import { Component } from '@angular/core';
import {Title} from "@angular/platform-browser";


@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.css']
})
export class CandidateForgotPasswordComponent {
  constructor(private titleService:Title) {
    this.titleService.setTitle("Ứng viên - Quên mật khẩu");
  }
}
