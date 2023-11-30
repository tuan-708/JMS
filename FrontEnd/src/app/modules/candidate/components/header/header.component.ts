import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { getProfile, getToken, isLogin, saveItem, signOut } from 'src/app/service/localstorage';
import { environment } from 'src/environments/environment';

@Component({
   selector: 'candidate-header',
   templateUrl: './header.component.html',
   styleUrls: ['./header.component.css']
})
export class HeaderComponent {
   backgroundSelectedLink = `${environment.Url}/assets/background-gradients/gradients-backgrounds-sexy-blue1.png`

   isLog: boolean = true;
   profile: any;
   headerTitle = [{ title: 'jobs', router: '/candidate', value: false },
   { title: 'cv', router: '/candidate/your-cvs', value: false },
   { title: 'company', router: '/candidate/list-companies', value: false },
   { title: 'yourWork', router: '/candidate/your-apply-job', value: false }];
   currentRouter: any;


   loadProfile() {
      this.profile = getProfile();
   }

   constructor(private router: Router) {

      this.loadProfile()

      this.changeHeader();
   }

   signOut() {
      signOut();
      this.router.navigate(['/candidate/sign-in']);
   }

   changeHeader() {
      this.currentRouter = this.router.url;
      for (let i = 0; i < this.headerTitle.length; i++) {
         if (this.currentRouter == this.headerTitle[i].router) {
            this.headerTitle[i].value = true
         } else {
            this.headerTitle[i].value = false
         }
      }
   }
}
