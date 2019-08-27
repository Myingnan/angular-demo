import { Component, OnInit, ViewChild } from '@angular/core';
import { IonSlides } from '@ionic/angular';
import { AppService } from '../app.service';

@Component({
  selector: 'app-capture',
  templateUrl: './capture.page.html',
  styleUrls: ['./capture.page.scss'],
})
export class CapturePage implements OnInit {

  slideOpts = {
    loop: true,
    effect: 'coverflow',
    centerSlides: true,
    slidesPerView: 1.6,
  };

  previewData: [];
  service:AppService ;

  ngOnInit() {
    this.previewData = this.service.getCapture();
  }

  constructor() { }
}
