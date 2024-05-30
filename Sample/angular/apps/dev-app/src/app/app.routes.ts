import { Route } from '@angular/router';
import { NxWelcomeComponent } from './nx-welcome.component';
import { YinchangComponent } from './yinchang/yinchang.component';
import { ActivityComponent } from './activity/activity.component';

export const appRoutes: Route[] = [
    {
        path: '',
        pathMatch: 'full',
        redirectTo: 'activity',
    },
    {
        path: 'welcome',
        component: NxWelcomeComponent,
    },{
        path: 'activity',
        component: ActivityComponent,
    },
];
