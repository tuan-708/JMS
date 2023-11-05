import { Component } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
   selector: 'candidate-sliders',
   templateUrl: './sliders.component.html',
   styleUrls: ['./sliders.component.css']
})
export class SlidersComponent {
   Url = environment.Url;

   ngAfterViewInit() {


   }

}
