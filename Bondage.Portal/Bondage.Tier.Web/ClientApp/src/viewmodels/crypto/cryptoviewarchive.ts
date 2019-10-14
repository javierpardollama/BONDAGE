import { ViewApplicationUser } from './../views/viewapplicationuser';

export interface CryptoViewArchive {
    Id: number;
    By: ViewApplicationUser;
    Data: File;
    Name: string;
    LastModified: Date;
}
