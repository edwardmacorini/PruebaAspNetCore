import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ChartOptions, ChartType, ChartDataset } from 'chart.js';

@Component({
  selector: 'app-consumo-servicio',
  templateUrl: './consumo-servicio.component.html',
  styleUrls: ['./consumo-servicio.component.scss']
})
export class ConsumoServicioComponent implements OnInit {
  public barChartOptions: ChartOptions = {
    responsive: true,
  };
  public barChartLabels: string[] = [];
  public barChartType: ChartType = 'bar';
  public barChartLegend = true;
  public barChartPlugins = [];

  public barChartData: ChartDataset[] = [];

  public isLoading = true;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.barChartLabels.push(new Date().toLocaleString('en-US'));
    this.barChartData = [
      { data: [0], label: 'United States Dollar' },
      { data: [0], label: 'British Pound Sterling' },
      { data: [0], label: 'Euro' }
    ];
    setInterval(() => {
      this.isLoading = true;
      this.http.get('https://api.coindesk.com/v1/bpi/currentprice.json')
        .subscribe((response: any) => {
          let data = response.bpi;
          this.barChartLabels.push(new Date().toLocaleString('en-US'));
          this.barChartData[0].data.push(data.USD.rate_float);
          this.barChartData[1].data.push(data.GBP.rate_float);
          this.barChartData[2].data.push(data.EUR.rate_float);
          console.log(this.barChartData);
          this.isLoading = false;
        });
    }, 10000);
  }

}
