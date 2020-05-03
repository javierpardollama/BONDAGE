import { ViewLink } from './../viewmodels/views/viewlink';

import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root',
})

export class NavigationService {

    public GetHomeNavigationLinks(): ViewLink[] {
        return [
            {
                Label: 'Effort',
                Link: './effort',
                Index: 0,
                Class: 'home-menu-option-image home-menu-effort-image'
            }, {
                Label: 'Absence',
                Link: './absence',
                Index: 1,
                Class: 'home-menu-option-image home-menu-absence-image'
            },
            , {
                Label: 'Security',
                Link: './security',
                Index: 1,
                Class: 'home-menu-option-image home-menu-security-image'
            }
        ];
    }
}
