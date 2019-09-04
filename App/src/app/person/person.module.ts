import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';

import { IonicModule } from '@ionic/angular';

import { PersonPage } from './person.page';
import { MockWebApiModule } from 'src/mockData/mock-web-api.module';
import { HttpClientModule } from '@angular/common/http';
import { PersonService } from './person.service';

const routes: Routes = [
  {
    path: '',
    component: PersonPage
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
  declarations: [PersonPage],
  providers: [PersonService]
})
export class PersonPageModule {}
