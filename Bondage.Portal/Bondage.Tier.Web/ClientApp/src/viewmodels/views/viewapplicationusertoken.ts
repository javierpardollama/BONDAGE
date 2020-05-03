import { ViewBase } from './viewbase';
import { ViewApplicationUser } from './viewapplicationuser';

export interface ViewApplicationUserToken extends ViewBase {
    Name: string;
    LoginProvider: string;
    Value: string;
    ApplicationUser: ViewApplicationUser;
}
