import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { AppRouteGuard } from '@shared/auth/auth-route-guard';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { UsersComponent } from './users/users.component';
import { TenantsComponent } from './tenants/tenants.component';
import { RolesComponent } from "app/roles/roles.component";
import { EventsComponent } from "app/events/events.component";
import { EventDetailComponent } from "app/events/event-detail/event-detail.component";
import { PostsComponent } from '@app/posts/posts.component'; 
import { PostDetailComponent } from '@app/posts/post-detail/post-detail.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                component: AppComponent,
                children: [
                    { path: 'home', component: HomeComponent,  canActivate: [AppRouteGuard] },
                    { path: 'users', component: UsersComponent, data: { permission: 'Pages.Users' }, canActivate: [AppRouteGuard] },
                    { path: 'roles', component: RolesComponent, data: { permission: 'Pages.Roles' }, canActivate: [AppRouteGuard] },
                    { path: 'tenants', component: TenantsComponent, data: { permission: 'Pages.Tenants' }, canActivate: [AppRouteGuard] },
                    { path: 'events', component: EventsComponent, data: { permission: 'Pages.Events' }, canActivate: [AppRouteGuard] },
                    { path: 'posts', component: PostsComponent, data: { permission: 'Pages.Posts' }, canActivate: [AppRouteGuard] },
                    { path: 'events/:eventId', component: EventDetailComponent },
                    { path: 'posts/:postId', component: PostDetailComponent },
                    { path: 'about', component: AboutComponent }
                ]
            }
        ])
    ],
    exports: [RouterModule]
})
export class AppRoutingModule { }