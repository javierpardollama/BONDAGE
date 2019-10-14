import {
  Component,
  OnInit,
  Inject
} from '@angular/core';

import {
  MatDialogRef,
  MAT_DIALOG_DATA,
  MatSnackBar
} from '@angular/material';

import {
  FormBuilder,
  FormGroup,
  Validators
} from '@angular/forms';

import { CryptoUpdateArchive } from './../../../../../viewmodels/crypto/cryptoupdatearchive';

import { CryptoViewArchive } from './../../../../../viewmodels/crypto/cryptoviewarchive';

import { ViewArchive } from './../../../../../viewmodels/views/viewarchive';

import { ViewApplicationUser } from '../../../../../viewmodels/views/viewapplicationuser';

import { ArchiveService } from './../../../../../services/archive.service';

import { CryptoService } from './../../../../../services/crypto.service';

import { TextAppVariants } from './../../../../../variants/text.app.variants';

import { TimeAppVariants } from './../../../../../variants/time.app.variants';

@Component({
  selector: 'app-archive-update-modal',
  templateUrl: './archive-update-modal.component.html',
  styleUrls: ['./archive-update-modal.component.css']
})
export class ArchiveUpdateModalComponent implements OnInit {

  public formGroup: FormGroup;

  public User: ViewApplicationUser;

  public DecodedArchive: CryptoViewArchive;

  // Constructor
  constructor(
    private cryptoService: CryptoService,
    private archiveService: ArchiveService,
    private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<ArchiveUpdateModalComponent>,
    private matSnackBar: MatSnackBar,
    @Inject(MAT_DIALOG_DATA) public data: ViewArchive) { }


  // Life Cicle
  ngOnInit() {
    this.GetLocalUser();
    this.DecodeInjectedata();
    this.CreateForm();
  }

  // Form
  CreateForm() {
    this.formGroup = this.formBuilder.group({
      Id: [this.DecodedArchive.Id, [Validators.required]],
      Name: [this.DecodedArchive.Name,
      [Validators.required]],
      Data: [this.DecodedArchive.Data,
      [Validators.required]],
      By: [this.User, [Validators.required]]
    });
  }

  // Form Actions
  onSubmit(viewModel: CryptoUpdateArchive) {
    this.cryptoService.EncodeUpdateArchive(viewModel).subscribe(updateArchive => {
      this.archiveService.UpdateArchive(updateArchive).subscribe(viewArchive => {

        if (viewArchive !== undefined) {
          this.matSnackBar.open(
            TextAppVariants.AppOperationSuccessCoreText,
            TextAppVariants.AppOkButtonText,
            { duration: TimeAppVariants.AppToastSecondTicks * TimeAppVariants.AppTimeSecondTicks });
        }

        this.dialogRef.close();
      });
    })
  }

  // Get User from Storage
  public GetLocalUser() {
    this.User = JSON.parse(localStorage.getItem('User'));
  }

  public DecodeInjectedata() {
    this.cryptoService.DecodeViewArchive(this.data).subscribe(cryptoViewArchive => {
      this.DecodedArchive = cryptoViewArchive;
    });
  }
}
