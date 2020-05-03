import { ViewKey } from './viewkey';
import { ViewBase } from './viewbase';
import { ViewKind } from './viewkind';
import { ViewEffort } from './vieweffort';

export interface ViewBreak extends ViewKey, ViewBase {
    Start: Date;
    Finish: Date;
    Effort: ViewEffort;
    Kind: ViewKind;
    Active: boolean;
}
