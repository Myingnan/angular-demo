import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-talk',
  templateUrl: './talk.page.html',
  styleUrls: ['./talk.page.scss'],
})
export class TalkPage implements OnInit {

  constructor() { }

  displayData = [
    {
      id:1,
      picUrl: '../../assets/t1.PNG',
      date: '2019/8/22 15:10',
      name: 'Han',
      content: '10 Tips For Gaining Mass Fast using Natural Food'
    },
    {
      id:1,
      picUrl: '../../assets/t1.PNG',
      date: '2019-8-22 15:10',
      name: 'Han',
      content: '10 Tips For Gaining Mass Fast using Natural Food'
    },
    {
      id:1,
      picUrl: '../../assets/t1.PNG',
      date: '2019-8-22 15:10',
      name: 'Han',
      content: '10 Tips For Gaining Mass Fast using Natural Food'
    },
    {
      id:2,
      picUrl: '../../assets/t2.PNG',
      date: '2019-8-22 15:10',
      name: 'Han',
      content: '10 Tips For Gaining Mass Fast using Natural Food'
    },
    {
      id:2,
      picUrl: '../../assets/t2.PNG',
      date: '2019-8-22 15:10',
      name: 'Han',
      content: 'no'
    },
    {
      id:2,
      picUrl: '../../assets/t2.PNG',
      date: '2019-8-22 15:10',
      name: 'Han',
      content: 'yes'
    }
  ];

  ngOnInit() {
  }

}
