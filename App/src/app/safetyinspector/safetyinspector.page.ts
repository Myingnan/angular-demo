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

  constructor(private inspectorservice: InspectorService) {
    this.inspectorservice.getAll().subscribe(value => {
      this.inspector = value;
    });
  }

  ngOnInit() {
  }

}
