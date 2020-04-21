import { ViewKey } from './viewkey';
import { ViewBase } from './viewbase';

export interface ViewKind extends ViewKey, ViewBase {
    Name: string;
}
