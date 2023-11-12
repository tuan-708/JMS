import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JdDetailComponent } from './jd-detail.component';

describe('JdDetailComponent', () => {
  let component: JdDetailComponent;
  let fixture: ComponentFixture<JdDetailComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [JdDetailComponent]
    });
    fixture = TestBed.createComponent(JdDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
