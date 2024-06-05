import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeclinedClaimComponent } from './declined-claim.component';

describe('DeclinedClaimComponent', () => {
  let component: DeclinedClaimComponent;
  let fixture: ComponentFixture<DeclinedClaimComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeclinedClaimComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DeclinedClaimComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
