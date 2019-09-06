import { Component, OnInit } from '@angular/core';
import { AppService } from '../app.service';
import { OverviewPageData } from 'src/entity/overviewPageData';
import { NavController } from '@ionic/angular';
import { Person } from 'src/entity/person';

@Component({
  selector: 'app-overview',
  templateUrl: './overview.page.html',
  styleUrls: ['./overview.page.scss'],
  providers: [AppService],
})
export class OverviewPage implements OnInit {

  overviewPageData: OverviewPageData[] = [];
  isAsc: boolean = false;
  isFilter: boolean = false;

  constructor(public nav: NavController, private appService: AppService) {
    this.appService.getOverviewPageData().subscribe(value => {
      this.overviewPageData = value;
    });
  }

  sortClick() {
    let sortFun = undefined;
    if (!this.isAsc) {
      sortFun = (a, b) => { return a['date'] < b['date'] ? 1 : -1 };
      this.isAsc = true;
    } else {
      sortFun = (a, b) => { return a['date'] > b['date'] ? 1 : -1 };
      this.isAsc = false;
    }
    this.overviewPageData.sort(sortFun);
  }

  filterClick() {
    if (!this.isFilter) {
      this.overviewPageData = this.overviewPageData.filter((value) => value.content2.indexOf("person") != -1)
      this.isFilter = true;
    } else {
      this.appService.getOverviewPageData().subscribe(value => {
        this.overviewPageData = value;
        this.isFilter = false;
      });
    }
  }

  ngOnInit() { }
}
