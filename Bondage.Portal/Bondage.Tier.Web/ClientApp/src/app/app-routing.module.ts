import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SignInGuard } from 'src/guards/signin.guard';
import { JoinInAuthComponent } from './auth/joinin-auth/joinin-auth.component';
import { SignInAuthComponent } from './auth/signin-auth/signin-auth.component';
import { HomeComponent } from './home/home.component';
import { EffortListComponent } from './management/lists/effort-list/effort-list.component';
import { ChangeEmailSecurityComponent } from './security/changeemail-security/changeemail-security.component';
import { ChangePasswordSecurityComponent } from './security/changepassword-security/changepassword-security.component';
import { ResetPasswordSecurityComponent } from './security/resetpassword-security/resetpassword-security.component';
import { SecurityComponent } from './security/security.component';

@NgModule({
  imports: [RouterModule.forRoot([
    {
      path: '',
      component: HomeComponent,
      pathMatch: 'full',
      canActivate: [SignInGuard]
    },
    // App-Auth
    {
      path: 'auth/joinin',
      component: JoinInAuthComponent,
      pathMatch: 'full'
    },
    {
      path: 'auth/signin',
      component: SignInAuthComponent,
      pathMatch: 'full'
    },
    // App-List
    {
      path: 'effort',
      component: EffortListComponent,
      pathMatch: 'full',
      canActivate: [SignInGuard]
    },

    // App-Security
    {
      path: 'security',
      component: SecurityComponent,
      pathMatch: 'full',
      canActivate: [SignInGuard]
    },
    {
      path: 'security/changeemail',
      component: ChangeEmailSecurityComponent,
      pathMatch: 'full',
      canActivate: [SignInGuard]
    },
    {
      path: 'security/changepassword',
      component: ChangePasswordSecurityComponent,
      pathMatch: 'full',
      canActivate: [SignInGuard]
    },
    {
      path: 'security/resetpassword',
      component: ResetPasswordSecurityComponent,
      pathMatch: 'full'
    },
  ])
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
