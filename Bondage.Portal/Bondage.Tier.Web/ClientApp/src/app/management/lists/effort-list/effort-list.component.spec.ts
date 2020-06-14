import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EffortListComponent } from './effort-list.component';

describe('EffortListComponent', () => {
  let component: EffortListComponent;
  let fixture: ComponentFixture<EffortListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EffortListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EffortListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
