import { Component, OnInit, ViewChild} from '@angular/core';
import { IonSlides } from '@ionic/angular';

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

  displayData = [
    {
      picUrl: '/assets/racket1.PNG',
    },
    {
      picUrl: '/assets/racket2.PNG',
    },
    {
      picUrl: '/assets/racket3.PNG',
    },
    {
      picUrl: '/assets/racket4.PNG',
    },
  ];
  constructor() { }

  ngOnInit() {
  }
}
