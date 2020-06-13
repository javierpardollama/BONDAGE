import { ViewKey } from './viewkey';
import { ViewBase } from './viewbase';
import { ViewApplicationUser } from './viewapplicationuser';
import { ViewKind } from './viewkind';

export interface ViewEffort extends ViewKey, ViewBase {
    ApplicationUser: ViewApplicationUser;
    Start: Date;
    Finish: Date;
    Kind: ViewKind;
    Active: boolean;
}
