import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LoanFooterComponent } from './loan-footer.component';

describe('LoanFooterComponent', () => {
  let component: LoanFooterComponent;
  let fixture: ComponentFixture<LoanFooterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LoanFooterComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LoanFooterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
