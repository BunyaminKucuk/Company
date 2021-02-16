import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CollectionAllListComponent } from './collection-all-list.component';

describe('CollectionAllListComponent', () => {
  let component: CollectionAllListComponent;
  let fixture: ComponentFixture<CollectionAllListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CollectionAllListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CollectionAllListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
