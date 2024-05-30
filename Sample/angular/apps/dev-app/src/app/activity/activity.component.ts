import { Component, OnInit, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivityService } from './activity.service';
import { Activity } from './activity.types';

@Component({
  selector: 'app-activity',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './activity.component.html',
  styleUrl: './activity.component.css',
})
export class ActivityComponent implements OnInit {
  service = inject(ActivityService);

  activities = signal<Activity[]>([]);

  async ngOnInit(): Promise<void> {
    
    const datas = await this.service.getActivities();

    this.activities.set(datas);
  }
}
