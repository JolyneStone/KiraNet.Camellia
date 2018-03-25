import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './guards/auth.guard';
import { LoginCallbackComponent } from './components/login-callback/login-callback.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { HomeComponent } from './components/home/home.component';

const routes: Routes = [{
    path: '',
    redirectTo: 'home',
    pathMatch: 'full',
},
{
    path: 'home',
    component: HomeComponent,
    canActivate: [AuthGuard],
},
{
    path: 'login-callback',
    component: LoginCallbackComponent
},
{ path: '**', component: NotFoundComponent }];

@NgModule({
    imports: [
        RouterModule.forRoot(routes)
    ],
    exports: [
        RouterModule
    ],
    providers: [
    ],
    declarations: []
})
export class AppRoutingModule { }