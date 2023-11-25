import { Component } from '@angular/core';
import { Chart } from 'angular-highcharts';

@Component({
  selector: 'app-top-three-products',
  templateUrl: './top-three-products.component.html',
  styleUrls: ['./top-three-products.component.css']
})
export class TopThreeProductsComponent {
  chart = new Chart({
    chart: {
      type: 'bar',
      height: 225
    },
    title: {
      text: 'Top Nhà Tuyển Dụng'
    },
    xAxis: {
      categories: [
        'FPT EDUCATION',
        'VIETTEL GROUP',
        'VINAMILK',
      ]
    },
    yAxis: {
      title: {
        text: '(Bài Tuyển Dụng)'
      }
    },
    series: [
     {
      type: 'bar',
      showInLegend: false,
      data: [
        {
          name: 'FPT EDUCATION',
          y: 395,
          color: '#044342',
        },
        {
          name: 'VIETTEL GROUP',
          y: 385,
          color: '#7e0505',
        },
        {
          name: 'VINAMILK',
          y: 275,
          color: '#ed9e20',
        },
      ]
     }
    ],
    credits: {
      enabled: false
    }
  })
}
