import { Component } from '@angular/core';
import {Title} from "@angular/platform-browser";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class CandidateRegisterComponent {
  constructor(private titleService:Title) {
    this.titleService.setTitle("Ứng viên - Đăng ký tài khoản");
  }
}
