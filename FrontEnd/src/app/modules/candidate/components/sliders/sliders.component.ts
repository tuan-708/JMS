import { Component } from '@angular/core';
import { environment } from 'src/environments/environment';
import { getRequest, postRequest } from 'src/app/service/api-requests';
import { AuthorizationMode, apiRecruiter } from 'src/app/service/constant';


declare var $: any; // Declare $ as a global variable

@Component({
   selector: 'candidate-sliders',
   templateUrl: './sliders.component.html',
   styleUrls: ['./sliders.component.css']
})
export class SlidersComponent {
   Url = environment.Url;

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

   companies: any;
   
   constructor(){
      getRequest(apiRecruiter.GET_COMPANY_PAGING, AuthorizationMode.PUBLIC, { page: 10})
      .then(res => {
         this.companies = res?.data
         console.log(this.companies);
      })
      .catch(data => {
         console.warn(apiRecruiter.GET_ALL_CATEGORY, data);
      })
   }

}
