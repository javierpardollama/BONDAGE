import { AddArchive } from './../viewmodels/additions/addarchive';

import { UpdateArchive } from './../viewmodels/updates/updatearchive';

import { ViewArchive } from './../viewmodels/views/viewarchive';

import { CryptoViewArchive } from './../viewmodels/crypto/cryptoviewarchive';

import { CryptoAddArchive } from './../viewmodels/crypto/cryptoaddarchive';

import { CryptoUpdateArchive } from './../viewmodels/crypto/cryptoupdatearchive';

import { HttpClient } from '@angular/common/http';

import { MatSnackBar } from '@angular/material';

import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';

import { BaseService } from './base.service';

@Injectable({
    providedIn: 'root',
})

export class CryptoService extends BaseService {

    public constructor(
        protected httpClient: HttpClient,
        protected matSnackBar: MatSnackBar) {
        super(httpClient, matSnackBar);
    }

    public EncodeAddArchive(viewModel: CryptoAddArchive): Observable<AddArchive> {
        return null;
    }

    public EncodeUpdateArchive(viewModel: CryptoUpdateArchive): Observable<UpdateArchive> {
        return null;
    }

    public DecodeViewArchive(viewModel: ViewArchive): Observable<CryptoViewArchive> {
        return null;
    }
}
