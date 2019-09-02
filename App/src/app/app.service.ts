import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AppService {

  constructor() { }

  public overviewPageData = [
    {
      number: '1',
      pic: '/assets/Capture1.PNG',
      title: '1 Tip For Gaining Mass Fast using Natura',
    },
    {
      number: '2',
      pic: '/assets/Capture2.PNG',
      title: '2 Tip For Gaining Mass Fast using Natura',
    },
    {
      number: '3',
      pic: '/assets/Capture3.PNG',
      title: '3 Tip For Gaining Mass Fast using Natura',
    },
    {
      number: '4',
      pic: '/assets/Capture4.PNG',
      title: '4 Tip For Gaining Mass Fast using Natura',
    },
    {
      number: '5',
      pic: '/assets/Capture5.PNG',
      title: '5 Tip For Gaining Mass Fast using Natura',
    },
    {
      number: '6',
      pic: '/assets/Capture6.PNG',
      title: '6 Tip For Gaining Mass Fast using Natura',
    },
  ];

  public capturePageData = [
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

  public tagsPageData = [
    {
      val: 'smoke', isChecked: true
    },
    {
      val: 'fire', isChecked: false
    },
    {
      val: 'car', isChecked: false
    },
    {
      val: 'person', isChecked: false
    },
    {
      val: 'lootoo', isChecked: false
    },
    {
      val: 'tree', isChecked: false
    },
    {
      val: 'phone', isChecked: false
    },
    {
      val: 'cup', isChecked: false
    },
  ];

  getOverviewPageData(): any {
    return this.overviewPageData;
  }

  getCapturePageData(): any {
    return this.capturePageData;
  }

  getTagsPageData(): any {
    return this.tagsPageData;
  }
}
