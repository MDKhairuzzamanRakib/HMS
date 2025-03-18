import { Routes } from '@angular/router';
import { AppLayout } from './app/layout/component/app.layout';
import { Dashboard } from './app/pages/dashboard/dashboard';
import { Documentation } from './app/pages/documentation/documentation';
import { Landing } from './app/pages/landing/landing';
import { Notfound } from './app/pages/notfound/notfound';
import { LoginComponent } from './app/pages/backend/authentication/login/login.component';
import { AuthGuard } from './app/core/guard/auth.guard';
import { HomePageComponent } from './app/pages/frontend/home-page/home-page.component';
import { HomeLayout } from './app/layout/component/home.layout';

export const appRoutes: Routes = [
    {
        path: '',
        // component: HomeLayout,
        children: [
            { path: '',  loadChildren: () => import('./app/pages/frontend/frontend.routes') },
        ]
    },
    {
        path: '',
        component: AppLayout,
        canActivate: [AuthGuard],
        children: [
            { path: 'dashboard',  component: Dashboard },
            { path: 'uikit', canActivate: [AuthGuard], loadChildren: () => import('./app/pages/uikit/uikit.routes') },
            { path: 'documentation', canActivate: [AuthGuard], component: Documentation },
            { path: 'pages', canActivate: [AuthGuard], loadChildren: () => import('./app/pages/pages.routes') }
        ]
    },
    { path: 'landing', component: Landing },
    { path: 'notfound', component: Notfound },
    { path: 'login', component: LoginComponent },
    { path: 'auth', loadChildren: () => import('./app/pages/auth/auth.routes') },
    { path: '**', redirectTo: '/notfound' }
];
