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
   backgroudSelectedLink = `${environment.Url}/assets/background-gradients/gradients-backgrounds-sexy-blue1.png`

   isLog:boolean = true;
   profile:any

   constructor(private router: Router){
      this.profile = getProfile();
   }

   signOut(){
      signOut();
      this.router.navigate(['/candidate/sign-in']);
   }
}
