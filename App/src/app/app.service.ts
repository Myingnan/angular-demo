import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { OverviewPageData } from 'src/entity/overviewPageData';
import { Observable } from 'rxjs';
import { CapturePageData } from 'src/entity/capturePageData';
import { TagsPageData } from 'src/entity/tagsPageData';

@Injectable({
  providedIn: 'root'
})
export class AppService {
  private headers = new HttpHeaders({ 'Content-Type': 'application/json' });
  constructor(private http: HttpClient) {
  }

  getOverviewPageData(): Observable<OverviewPageData[]> {
    return this.http.get<OverviewPageData[]>("api/overviewPageData", { headers: this.headers });
  }
  getCapturePageData(): Observable<CapturePageData[]> {
    return this.http.get<CapturePageData[]>("api/capturePageData", { headers: this.headers });
  }
  getTagsPageData(): Observable<TagsPageData[]> {
    return this.http.get<TagsPageData[]>("api/tagsPageData", { headers: this.headers });
  }
}