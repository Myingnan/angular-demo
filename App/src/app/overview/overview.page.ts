import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-overview',
  templateUrl: './overview.page.html',
  styleUrls: ['./overview.page.scss'],
})
export class OverviewPage implements OnInit {
  overviewData = [
    {
      number: '1',
      pic: '/assets/Capture1.PNG',
      title: '1 Tip For Gaining Mass Fast using Natura',
    },
    {
      number: '2',
      pic: '/assets/Capture2.PNG',
      title: '2 Tips For Gaining Mass Fast using Natura',
    },
    {
      number: '3',
      pic: '/assets/Capture3.PNG',
      title: '3 Tips For Gaining Mass Fast using Natura',
    },
    {
      number: '4',
      pic: '/assets/Capture4.PNG',
      title: '4 Tips For Gaining Mass Fast using Natura',
    },
    {
      number: '5',
      pic: '/assets/Capture5.PNG',
      title: '5 Tips For Gaining Mass Fast using Natura',
    },
    {
      number: '6',
      pic: '/assets/Capture6.PNG',
      title: '6 Tips For Gaining Mass Fast using Natura',
    },
  ];

  constructor() {}

  ngOnInit() {
  }

}
