/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { CoComponent } from './co.component';

describe('CoComponent', () => {
  let component: CoComponent;
  let fixture: ComponentFixture<CoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
