import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FicheroAddModalComponent } from './fichero-add-modal.component';

describe('FicheroAddModalComponent', () => {
  let component: FicheroAddModalComponent;
  let fixture: ComponentFixture<FicheroAddModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FicheroAddModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FicheroAddModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
