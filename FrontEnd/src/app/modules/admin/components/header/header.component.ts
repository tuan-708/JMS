import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ADMIN_PROFILE, ADMIN_TOKEN } from 'src/app/service/constant';
import { getItem, removeItem, saveItem } from 'src/app/service/localstorage';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {
  profile: any

  constructor(private router: Router){
    this.profile = getItem(ADMIN_PROFILE)
  }

  signOut(){
    removeItem(ADMIN_TOKEN);
    removeItem(ADMIN_PROFILE);
    this.router.navigate(['/admin/sign-in'])
  }
}
