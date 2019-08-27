import { Component, OnInit } from '@angular/core';
import { AppService } from '../app.service';

@Component({
  selector: 'app-overview',
  templateUrl: './overview.page.html',
  styleUrls: ['./overview.page.scss'],
})
export class OverviewPage implements OnInit {
  overviewData: any;

  constructor(public service: AppService) { }

  ngOnInit() {
    this.overviewData = this.service.getOverview();
  }
}
