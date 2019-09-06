import { Component, OnInit } from '@angular/core';
import { NavController } from '@ionic/angular';
import { TalkService } from './talk.service';
import { Talks } from 'src/entity/talks';

@Component({
  selector: 'app-talk',
  templateUrl: './talk.page.html',
  styleUrls: ['./talk.page.scss'],
  providers: [TalkService]
})
export class TalkPage {
  talks: Talks[] = [];

  constructor(public nav: NavController, private talkservice: TalkService) {
    this.talkservice.getTalks().subscribe(value => {
      this.talks = value;
    });
  }

  canGoBack() {
    this.nav.back();
  }
}
