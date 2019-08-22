import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    loadChildren: () => import('./tabs/tabs.module').then(m => m.TabsPageModule)
  },
  { path: 'talk', loadChildren: './talk/talk.module#TalkPageModule' },
  { path: 'login', loadChildren: './login/login.module#LoginPageModule' },
  { path: 'capture', loadChildren: './capture/capture.module#CapturePageModule' },  { path: 'sign-up', loadChildren: './sign-up/sign-up.module#SignUpPageModule' }


];
@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule {}
