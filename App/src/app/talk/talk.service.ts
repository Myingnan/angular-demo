import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Talks } from 'src/entity/talks';


@Injectable()
export class TalkService {
    private headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    constructor(private http: HttpClient) {
    }

    getTalks(): Observable<Talks[]> {
        return this.http.get<Talks[]>("api/talks", { headers: this.headers });
    }
}