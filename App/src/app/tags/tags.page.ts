import { Component, OnInit } from '@angular/core';
import { AppService } from '../app.service';

@Component({
  selector: 'app-tags',
  templateUrl: './tags.page.html',
  styleUrls: ['./tags.page.scss'],
  providers: [AppService],
})
export class TagsPage implements OnInit {
  tagsPageData: any;

  constructor(public service: AppService) { }

  ngOnInit() {
    this.tagsPageData = this.service.getTagsPageData();
  }
}
