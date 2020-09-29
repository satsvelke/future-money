import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SpentComponent } from './spent.component';

describe('SpentComponent', () => {
  let component: SpentComponent;
  let fixture: ComponentFixture<SpentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SpentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SpentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
