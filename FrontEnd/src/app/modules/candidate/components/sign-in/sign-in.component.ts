import { Component } from '@angular/core';
import {Title} from "@angular/platform-browser";

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class CandidateSignInComponent {

  constructor(private titleService:Title) {
    this.titleService.setTitle("Ứng viên - Đăng nhập");
  }
}
