import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Inspector } from 'src/entity/inspector';


@Injectable()
export class InspectorService {
    private headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    constructor(private http: HttpClient) {
    }

    getInspector(): Observable<Inspector[]> {
        return this.http.get<Inspector[]>("api/inspector", { headers: this.headers });
    }
}