import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FicheroUpdateModalComponent } from './fichero-update-modal.component';

describe('FicheroUpdateModalComponent', () => {
  let component: FicheroUpdateModalComponent;
  let fixture: ComponentFixture<FicheroUpdateModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FicheroUpdateModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FicheroUpdateModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
