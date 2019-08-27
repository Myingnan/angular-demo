import { Component, OnInit } from '@angular/core';
import { NavController } from '@ionic/angular';
import { TalkService } from './talk.service';

@Component({
  selector: 'app-talk',
  templateUrl: './talk.page.html',
  styleUrls: ['./talk.page.scss'],
  providers: [TalkService]
})
export class TalkPage implements OnInit {
  talks: any;
  constructor(public nav: NavController, private service: TalkService) { }

  canGoBack() {
    this.nav.back();
  }

  ngOnInit() {
    this.talks = this.service.getAll();
  }

}
