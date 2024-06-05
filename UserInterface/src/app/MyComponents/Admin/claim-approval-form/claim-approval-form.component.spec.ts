import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClaimApprovalFormComponent } from './claim-approval-form.component';

describe('ClaimApprovalFormComponent', () => {
  let component: ClaimApprovalFormComponent;
  let fixture: ComponentFixture<ClaimApprovalFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ClaimApprovalFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ClaimApprovalFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
