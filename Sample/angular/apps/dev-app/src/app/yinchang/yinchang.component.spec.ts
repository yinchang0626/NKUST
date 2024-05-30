import { ComponentFixture, TestBed } from '@angular/core/testing';
import { YinchangComponent } from './yinchang.component';

describe('YinchangComponent', () => {
  let component: YinchangComponent;
  let fixture: ComponentFixture<YinchangComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [YinchangComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(YinchangComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
