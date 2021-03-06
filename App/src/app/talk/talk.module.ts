import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';

import { IonicModule } from '@ionic/angular';

import { TalkPage } from './talk.page';
import { TalkService } from './talk.service';
import { HttpClientModule } from '@angular/common/http';
import { MockWebApiModule } from 'src/mockData/mock-web-api.module';

const routes: Routes = [
  {
    path: '',
    component: TalkPage
  }
];

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    RouterModule.forChild(routes),
    HttpClientModule,
    MockWebApiModule
  ],
  declarations: [TalkPage],
  providers: [TalkService]
})
export class TalkPageModule {}
