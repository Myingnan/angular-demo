import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';

import { IonicModule } from '@ionic/angular';

import { SafetyinspectorPage } from './safetyinspector.page';
import { MockWebApiModule } from 'src/mockData/mock-web-api.module';
import { HttpClientModule } from '@angular/common/http';
import { InspectorService } from './safetyinspector.service';

const routes: Routes = [
  {
    path: '',
    component: SafetyinspectorPage
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
  declarations: [SafetyinspectorPage],
  providers: [InspectorService]
})
export class SafetyinspectorPageModule {}
