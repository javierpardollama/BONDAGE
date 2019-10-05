import { ViewApplicationUser } from './../views/viewapplicationuser';
import { UpdateBase } from './updatebase'

export interface UpdateFichero extends UpdateBase {
    By: ViewApplicationUser;
    Data: ArrayBuffer;
    Name: string;
}
