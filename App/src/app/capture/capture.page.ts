import { Component, OnInit} from '@angular/core';
import { AppService } from '../app.service';

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

  previewData: any;

  constructor(public service: AppService) { }

  ngOnInit() {
    this.previewData = this.service.getCapture();
  }


}
