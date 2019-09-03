import { Component, OnInit } from '@angular/core';
import { AppService } from '../app.service';
import { OverviewPageData } from 'src/entity/overviewPageData';
import { NavController } from '@ionic/angular';

@Component({
  selector: 'app-overview',
  templateUrl: './overview.page.html',
  styleUrls: ['./overview.page.scss'],
  providers: [AppService],
})
export class OverviewPage implements OnInit {
  ngOnInit() {
  }

  overviewPageData: OverviewPageData[] = [];
  
  constructor(public nav: NavController, private appService: AppService) {
    this.appService.getOverviewPageData().subscribe(value => {
      this.overviewPageData = value;
    });
  }
}
