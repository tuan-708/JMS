import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { getProfile, getToken, isLogin, saveItem, signOut } from 'src/app/service/localstorage';
import { environment } from 'src/environments/environment';

@Component({
   selector: 'candidate-change-password',
   templateUrl: './change-password.component.html',
   styleUrls: ['./change-password.component.css']
})
export class ChangePasswordComponent {

  constructor(){

  }

  SubmitForm(){
   
  }

}
