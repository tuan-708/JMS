import { Component } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
   selector: 'candidate-header',
   templateUrl: './header.component.html',
   styleUrls: ['./header.component.css']
})
export class HeaderComponent {
   backgroudSelectedLink = `${environment.Url}/assets/background-gradients/gradients-backgrounds-sexy-blue1.png`
}
