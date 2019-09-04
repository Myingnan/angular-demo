import { Component, OnInit } from '@angular/core';
import { AppService } from '../app.service';
import { TagsPageData } from 'src/entity/tagsPageData';
import { NavController } from '@ionic/angular';

@Component({
  selector: 'app-tags',
  templateUrl: './tags.page.html',
  styleUrls: ['./tags.page.scss'],
  providers: [AppService],
})
export class TagsPage implements OnInit {

  tagsPageData: TagsPageData[] = [];

  constructor(public nav: NavController, private appService: AppService) {
    this.appService.getTagsPageData().subscribe(value => {
      this.tagsPageData = value;
    });
  }

  canGoBack() {
    this.nav.back();
  }

  ngOnInit() { }
}