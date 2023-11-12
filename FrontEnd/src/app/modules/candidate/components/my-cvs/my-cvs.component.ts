import { Component } from '@angular/core';
import { environment } from 'src/environments/environment';
declare var $: any; 

@Component({
   selector: 'app-my-cvs',
   templateUrl: './my-cvs.component.html',
   styleUrls: ['./my-cvs.component.css']
})
export class CandidateMyCvsComponent {
   Url = environment.Url;
   list = [1,2,3,4,5,6,7,8,9]

   ngAfterViewInit() {
      $('#prev').on('click', function () {
         $('#cards').animate({
            scrollLeft: '-=250'
         }, 300, 'swing');
      });

      $('#next').on('click', function () {
         $('#cards').animate({
            scrollLeft: '+=250'
         }, 300, 'swing');
      });

   }
}
