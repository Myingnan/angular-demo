import { Component, OnInit } from '@angular/core';
import { Inspector } from 'src/entity/inspector';
import { InspectorService } from './safetyinspector.service';

@Component({
  selector: 'app-safetyinspector',
  templateUrl: './safetyinspector.page.html',
  styleUrls: ['./safetyinspector.page.scss'],
})
export class SafetyinspectorPage implements OnInit {

  inspector: Inspector[] = [];
  isAsc: boolean = false;
  isFilter: boolean = false;

  constructor(private inspectorservice: InspectorService) {
    this.inspectorservice.getInspector().subscribe(value => {
      this.inspector = value;
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
    this.inspector.sort(sortFun);
  }

  filterClick() {
    if (!this.isFilter) {
      this.inspector = this.inspector.filter(row => row.detected);
      this.isFilter = true;
    } else {
      this.inspectorservice.getInspector().subscribe(value => {
        this.inspector = value;
        this.isFilter = false;
      });
    }
  }

  ngOnInit() {
  }

}
