import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LastFewTransactionComponent } from './last-few-transaction.component';

describe('LastFewTransactionComponent', () => {
  let component: LastFewTransactionComponent;
  let fixture: ComponentFixture<LastFewTransactionComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [LastFewTransactionComponent]
    });
    fixture = TestBed.createComponent(LastFewTransactionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
