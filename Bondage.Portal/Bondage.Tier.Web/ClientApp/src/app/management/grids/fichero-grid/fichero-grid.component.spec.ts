import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FicheroGridComponent } from './fichero-grid.component';

describe('FicheroGridComponent', () => {
  let component: FicheroGridComponent;
  let fixture: ComponentFixture<FicheroGridComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FicheroGridComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FicheroGridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
