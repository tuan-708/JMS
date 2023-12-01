import { Component } from '@angular/core';
import { environment } from 'src/environments/environment';
@Component({
   selector: 'app-home',
   templateUrl: './home.component.html',
   styleUrls: ['./home.component.css']
})

export class CandidateHomeComponent {
   backgroudSelectedLink = `${environment.apiUrl}/assets/background-gradients/gradient-green.jpg`;

}
