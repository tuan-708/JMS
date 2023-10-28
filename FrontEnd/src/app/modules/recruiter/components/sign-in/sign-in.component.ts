import { Component, ViewEncapsulation } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
   selector: 'app-sign-in',
   templateUrl: './sign-in.component.html',
   styleUrls: ['./sign-in.component.css'],
   encapsulation: ViewEncapsulation.None
})
export class RecruiterSignInComponent {
   backgroudSelectedLink = `${environment.apiUrl}/assets/images/imageRecruiterRegister.png`
}
