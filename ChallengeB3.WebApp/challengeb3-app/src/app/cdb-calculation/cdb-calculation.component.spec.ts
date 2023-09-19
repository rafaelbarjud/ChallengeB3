import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CdbCalculationComponent } from './cdb-calculation.component';

describe('CdbCalculationComponent', () => {
  let component: CdbCalculationComponent;
  let fixture: ComponentFixture<CdbCalculationComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CdbCalculationComponent]
    });
    fixture = TestBed.createComponent(CdbCalculationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
