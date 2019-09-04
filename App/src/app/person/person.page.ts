import { Component, OnInit } from '@angular/core';
import { Person } from 'src/entity/person';
import { PersonService } from './person.service';

@Component({
  selector: 'app-person',
  templateUrl: './person.page.html',
  styleUrls: ['./person.page.scss'],
})
export class PersonPage implements OnInit {

  person: Person[] = [];

  constructor(private personservice: PersonService) {
    this.personservice.getAll().subscribe(value => {
      this.person = value;
    });
  }

  ngOnInit() {
  }

}
