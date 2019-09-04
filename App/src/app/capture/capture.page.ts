import { Component, OnInit } from '@angular/core';
import { AppService } from '../app.service';
import { CapturePageData } from 'src/entity/capturePageData';
import { NavController } from '@ionic/angular';

@Component({
  selector: 'app-capture',
  templateUrl: './capture.page.html',
  styleUrls: ['./capture.page.scss'],
  providers: [AppService],
})
export class CapturePage implements OnInit {

  slideOpts = {
    loop: true,
    effect: 'coverflow',
    centerSlides: true,
    slidesPerView: 1.6,
  };

  capturePageData: CapturePageData[] = [];
  constructor(public nav: NavController, private appService: AppService) {
    this.appService.getCapturePageData().subscribe(value => {
      this.capturePageData = value;
    });
  }

  canGoBack() {
    this.nav.back();
  }

  ngOnInit() { }
}
