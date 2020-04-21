import { ViewKey } from './viewkey';
import { ViewBase } from './viewbase';
import { ViewApplicationUser } from './viewapplicationuser';
import { ViewBreak } from './viewbreak';

export interface ViewEffort extends ViewKey, ViewBase {
    ApplicationUser: ViewApplicationUser;
    Start: Date;
    Stop: Date;
    Breaks: ViewBreak[];
}
