import { BrowserModule } from '@angular/platform-browser';

import { NgModule } from '@angular/core';

import {
  FormsModule,
  ReactiveFormsModule
} from '@angular/forms';

import {
  HttpClientModule,
  HTTP_INTERCEPTORS
} from '@angular/common/http';

import { RouterModule } from '@angular/router';

// Angular Material
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import {
  MatDialogModule,
  MatChipsModule,
  MatSortModule,
  MatPaginatorModule,
  MatTableModule,
  MatCardModule,
  MatDividerModule,
  MatInputModule,
  MatFormFieldModule,
  MatButtonModule,
  MatSnackBarModule,
  MatAutocompleteModule,
  MatSelectModule
} from '@angular/material';

// Guards
import { SignInGuard } from './../guards/signin.guard';

// Interceptors
import { AuthInterceptor } from './../interceptors/auth.interceptor';

// App
import { AppComponent } from './app.component';

import { NavMenuComponent } from './nav-menu/nav-menu.component';

import { HomeComponent } from './home/home.component';

// App-Auth
import {
  JoinInAuthComponent
} from './auth/joinin-auth/joinin-auth.component';

import { SignInAuthComponent } from './auth/signin-auth/signin-auth.component';

// App-Security
import {
  ChangePasswordSecurityComponent
} from './security/changepassword-security/changepassword-security.component';

import {
  ResetPasswordSecurityComponent
} from './security/resetpassword-security/resetpassword-security.component';

import {
  ChangeEmailSecurityComponent
} from './security/changeemail-security/changeemail-security.component';

// App-Grid
import {
  FicheroGridComponent
} from './management/grids/fichero-grid/fichero-grid.component';

// App-Modal-Adition
import {
  FicheroAddModalComponent
} from './management/modals/additions/fichero-add-modal/fichero-add-modal.component';

// App-Modal-Update
import {
  FicheroUpdateModalComponent
} from './management/modals/updates/fichero-update-modal/fichero-update-modal.component';

@NgModule({
  declarations: [
    // App
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    // App-Auth
    JoinInAuthComponent,
    SignInAuthComponent,
    // App-Security
    ChangePasswordSecurityComponent,
    ResetPasswordSecurityComponent,
    ChangeEmailSecurityComponent,
    // App-Grid
    FicheroGridComponent,
    // App-Modal-Adition
    FicheroAddModalComponent,
    // App-Modal-Update
    FicheroUpdateModalComponent],
  imports: [
    // Angular Material
    BrowserAnimationsModule,
    MatDividerModule,
    MatSelectModule,
    MatInputModule,
    MatDialogModule,
    MatPaginatorModule,
    MatButtonModule,
    MatSnackBarModule,
    MatChipsModule,
    MatAutocompleteModule,
    MatCardModule,
    MatTableModule,
    MatSortModule,
    MatFormFieldModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
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
      // App-Security
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
      {
        path: 'management/ficheros',
        component: FicheroGridComponent,
        pathMatch: 'full',
        canActivate: [SignInGuard]
      },
    ])
  ],
  entryComponents: [
    FicheroAddModalComponent,
    FicheroUpdateModalComponent
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true,
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
