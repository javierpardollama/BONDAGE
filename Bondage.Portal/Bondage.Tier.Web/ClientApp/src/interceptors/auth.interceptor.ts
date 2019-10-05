import {
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest
} from '@angular/common/http';

import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';

import { ViewApplicationUser } from './../viewmodels/views/viewapplicationuser';

@Injectable({
  providedIn: 'root'
})

export class AuthInterceptor implements HttpInterceptor {

  private User: ViewApplicationUser;

  constructor() { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    this.User = JSON.parse(localStorage.getItem('User'));

    if (this.User !== null) {
      req = req.clone({
        setHeaders: {
          'Content-Type': 'application/json; charset=utf-8',
          Accept: 'application/json',
          Authorization: `Bearer ${this.User.ApplicationUserToken.Value}`,
        },
      });
    }

    return next.handle(req);
  }
}
