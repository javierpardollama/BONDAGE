import { ViewEffort } from './../viewmodels/views/vieweffort';

import { AddBreak } from './../viewmodels/additions/addbreak';

import { HttpClient } from '@angular/common/http';

import { MatSnackBar } from '@angular/material/snack-bar';

import { Injectable } from '@angular/core';

import { catchError } from 'rxjs/operators';

import { BaseService } from './base.service';

@Injectable({
    providedIn: 'root',
})

export class EffortService extends BaseService {

    public constructor(
        protected httpClient: HttpClient,
        protected matSnackBar: MatSnackBar) {
        super(httpClient, matSnackBar);
    }

    public FindAllEffort(): Promise<ViewEffort[]> {
        return this.httpClient.get<ViewEffort[]>('api/effort/findalleffort')
            .pipe(catchError(this.HandleError<ViewEffort[]>('FindAllEffort', []))).toPromise();
    }

    public FindAllEffortByApplicationUserById(id: number): Promise<ViewEffort[]> {
        return this.httpClient.get<ViewEffort[]>('api/effort/findalleffortbyapplicationuserbyid/' + id)
            .pipe(catchError(this.HandleError<ViewEffort[]>('FindAllEffortByApplicationUserById', []))).toPromise();
    }

    public Start(viewModel: AddBreak): Promise<ViewEffort> {
        return this.httpClient.post<ViewEffort>('api/effort/start', viewModel)
            .pipe(catchError(this.HandleError<ViewEffort>('Start', undefined))).toPromise();
    }

    public Pause(viewModel: AddBreak): Promise<ViewEffort> {
        return this.httpClient.post<ViewEffort>('api/effort/pause', viewModel)
            .pipe(catchError(this.HandleError<ViewEffort>('Pause', undefined))).toPromise();
    }

    public Resume(viewModel: AddBreak): Promise<ViewEffort> {
        return this.httpClient.post<ViewEffort>('api/effort/resume', viewModel)
            .pipe(catchError(this.HandleError<ViewEffort>('Resume', undefined))).toPromise();
    }

    public Stop(viewModel: AddBreak): Promise<ViewEffort> {
        return this.httpClient.post<ViewEffort>('api/effort/stop', viewModel)
            .pipe(catchError(this.HandleError<ViewEffort>('Stop', undefined))).toPromise();
    }

    public RemoveEffortById(id: number) {
        return this.httpClient.delete<any>('api/effort/removeeffortbyid/' + id)
            .pipe(catchError(this.HandleError<any>('RemoveEffortById', undefined)));
    }
}
