import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Person } from 'src/entity/person';


@Injectable()
export class PersonService {
    private headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    constructor(private http: HttpClient) {
    }

    getAll(): Observable<Person[]> {
        return this.http.get<Person[]>("api/person", { headers: this.headers });
    }
}