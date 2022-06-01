import { Component } from '@angular/core';
import { ChartData, ChartDataset, ChartOptions, ChartType, } from 'chart.js';

@Component({
  selector: 'app-my-line-chart',
  templateUrl: './my-line-chart.component.html',
  styleUrls: ['./my-line-chart.component.scss']
})
export class MyLineChartComponent {
  public pieChartOptions: ChartOptions = {
    responsive: true,
  };
  public pieChartLabels = ['Download Sales', 'In-Store Sales', 'Mail Sales'];



  public pieChartType: ChartType = 'pie';
  public pieChartLegend = true;
  public pieChartPlugins = [];

  constructor() { }
}
