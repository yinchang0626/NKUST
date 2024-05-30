
import { Injectable } from '@angular/core';
import { Activity } from './activity.types';
@Injectable({
  providedIn: 'root',
})
export class ActivityService {
  url = 'https://localhost:7196/api/activities-api/list';
  async getActivities(): Promise<Activity[]> {
    const data = await fetch(this.url);
    return (await data.json()) ?? [];
  }
}
