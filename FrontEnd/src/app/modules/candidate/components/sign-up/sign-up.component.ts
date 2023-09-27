import { Component } from '@angular/core';
import {Title} from "@angular/platform-browser";

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class CandidateSignUpComponent {
  constructor(private titleService:Title) {
    this.titleService.setTitle("Ứng viên - Đăng xuất");
  }
}
