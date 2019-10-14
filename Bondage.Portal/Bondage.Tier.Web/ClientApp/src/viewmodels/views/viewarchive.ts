import { ViewBase } from './viewbase';
import { ViewKey } from './viewkey';
import { ViewApplicationUser } from './viewapplicationuser';

export interface ViewArchive extends ViewKey, ViewBase {
    By: ViewApplicationUser;
    Data: ArrayBuffer;
    Name: string;
}
