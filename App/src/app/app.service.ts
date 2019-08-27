import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AppService {

  constructor() { }

  previewData = [
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
  
  getCapture():any {
    return this.previewData;
    } 
}
