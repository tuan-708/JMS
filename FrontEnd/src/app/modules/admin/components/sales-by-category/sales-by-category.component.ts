import { Component } from '@angular/core';
import { Chart } from 'angular-highcharts';

@Component({
  selector: 'app-sales-by-category',
  templateUrl: './sales-by-category.component.html',
  styleUrls: ['./sales-by-category.component.css']
})
export class SalesByCategoryComponent {
  chart = new Chart({
    chart: {
      type: 'pie',
      height: 325
    },
    title: {
      text: 'Ngành Tuyển Dụng'
    },
    xAxis: {
      categories: [
        'IT - Phần Mềm',
        'Truyền Thông - Marketing',
        'Kế Toán - Kiểm Toán',
        'Kinh Doanh - Bán Hàng',
        'Giáo Dục',
      ]
    },
    yAxis: {
      title: {
        text: 'Revenue in %'
      }
    },
    series: [
     {
      type: 'pie',
      data: [
        {
          name: 'IT - Phần Mềm',
          y: 41.0,
          color: '#044342',
        },
        {
          name: 'Truyền Thông - Marketing',
          y: 33.8,
          color: '#7e0505',
        },
        {
          name: 'Kế Toán - Kiểm Toán',
          y: 6.5,
          color: '#ed9e20',
        },
        {
          name: 'Kinh Doanh - Bán Hàng',
          y: 15.2,
          color: '#6920fb',
        },
        {
          name: 'Khác',
          y: 3.5,
          color: '#121212',
        },
      ]
     }
    ],
    credits: {
      enabled: false
    }
  })
}
