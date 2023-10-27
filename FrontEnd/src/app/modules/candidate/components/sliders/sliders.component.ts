import { Component } from '@angular/core';
import { environment } from 'src/environments/environment';
declare var $: any; // Declare $ as a global variable

@Component({
  selector: 'candidate-sliders',
  templateUrl: './sliders.component.html',
  styleUrls: ['./sliders.component.css']
})
export class SlidersComponent {
  apiURL = environment.apiUrl;

  ngAfterViewInit() {

    $(document).ready(function () {
      $('#myCarousel').carousel({
        interval: 3000 // Change the value (in milliseconds) to adjust the time interval
      });
    });

    $('#prev').on('click', function () {
      $('#cards').animate({
        scrollLeft: '-=250'
      }, 500, 'swing');
    });

    $('#next').on('click', function () {
      $('#cards').animate({
        scrollLeft: '+=250'
      }, 500, 'swing');
    });

  }

}
