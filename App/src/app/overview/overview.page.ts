import { Component, OnInit } from '@angular/core';
import { AppService } from '../app.service';

@Component({
  selector: 'app-overview',
  templateUrl: './overview.page.html',
  styleUrls: ['./overview.page.scss'],
  providers: [AppService],  
})
export class OverviewPage implements OnInit {
  overviewPageData: any;

  constructor(public service: AppService) { }

  ngOnInit() {
    this.overviewPageData = this.service.getOverviewPageData();
  }
}
