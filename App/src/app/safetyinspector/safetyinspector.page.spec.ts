import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SafetyinspectorPage } from './safetyinspector.page';

describe('SafetyinspectorPage', () => {
  let component: SafetyinspectorPage;
  let fixture: ComponentFixture<SafetyinspectorPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SafetyinspectorPage ],
      schemas: [CUSTOM_ELEMENTS_SCHEMA],
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SafetyinspectorPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
