import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OptionMatchModalComponent } from './option-match-modal.component';

describe('OptionMatchModalComponent', () => {
  let component: OptionMatchModalComponent;
  let fixture: ComponentFixture<OptionMatchModalComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [OptionMatchModalComponent]
    });
    fixture = TestBed.createComponent(OptionMatchModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
