import { AddFichero } from './../viewmodels/additions/addfichero';

import { UpdateFichero } from './../viewmodels/updates/updatefichero';

import { ViewFichero } from './../viewmodels/views/viewfichero';

import { HttpClient } from '@angular/common/http';

import { MatSnackBar } from '@angular/material';

import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';

import { catchError } from 'rxjs/operators';

import { BaseService } from './base.service';

@Injectable({
    providedIn: 'root',
})

export class FicheroService extends BaseService {

    public constructor(
        protected httpClient: HttpClient,
        protected matSnackBar: MatSnackBar) {
        super(httpClient, matSnackBar);
    }

    public UpdateFichero(viewModel: UpdateFichero): Observable<ViewFichero> {
        return this.httpClient.put<ViewFichero>('api/fichero/updatefichero', viewModel)
            .pipe(catchError(this.HandleError<ViewFichero>('UpdateFichero', undefined)));
    }

    public FindAllFichero(): Observable<ViewFichero[]> {
        return this.httpClient.get<ViewFichero[]>('api/fichero/findallfichero')
            .pipe(catchError(this.HandleError<ViewFichero[]>('FindAllFichero', [])));
    }

    public FindAllFicheroByApplicationUserId(id: number): Observable<ViewFichero[]> {
        return this.httpClient.get<ViewFichero[]>('api/fichero/findallficherobyapplicationuserid/' + id)
            .pipe(catchError(this.HandleError<ViewFichero[]>('FindAllFicheroByApplicationUserId', [])));
    }

    public AddFichero(viewModel: AddFichero): Observable<ViewFichero> {
        return this.httpClient.post<ViewFichero>('api/fichero/addfichero', viewModel)
            .pipe(catchError(this.HandleError<ViewFichero>('AddFichero', undefined)));
    }

    public RemoveFicheroById(id: number) {
        return this.httpClient.delete<any>('api/fichero/removeficherobyid/' + id)
            .pipe(catchError(this.HandleError<any>('RemoveFicheroById', undefined)));
    }
}
