import {
  Component,
  OnInit
} from '@angular/core';

import {
  MatDialogRef,
  MatSnackBar
} from '@angular/material';

import {
  FormBuilder,
  FormGroup,
  Validators
} from '@angular/forms';

import { CryptoAddArchive } from './../../../../../viewmodels/crypto/cryptoaddarchive';

import { ViewApplicationUser } from '../../../../../viewmodels/views/viewapplicationuser';

import { ArchiveService } from './../../../../../services/archive.service';

import { CryptoService } from './../../../../../services/crypto.service';

import { TextAppVariants } from '../../../../../variants/text.app.variants';

import { TimeAppVariants } from './../../../../../variants/time.app.variants';

@Component({
  selector: 'app-archive-add-modal',
  templateUrl: './archive-add-modal.component.html',
  styleUrls: ['./archive-add-modal.component.css']
})
export class ArchiveAddModalComponent implements OnInit {

  public formGroup: FormGroup;

  public User: ViewApplicationUser;

  // Constructor
  constructor(
    private cryptoService: CryptoService,
    private archiveService: ArchiveService,
    private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<ArchiveAddModalComponent>,
    private matSnackBar: MatSnackBar) { }


  // Life Cicle
  ngOnInit() {
    this.GetLocalUser();
    this.CreateForm();
  }

  // Form
  CreateForm() {
    this.formGroup = this.formBuilder.group({
      Name: [TextAppVariants.AppEmptyCoreText,
      [Validators.required]],
      Data: [TextAppVariants.AppEmptyCoreText,
      [Validators.required]],
      By: [this.User, [Validators.required]]
    });
  }

  // Form Actions
  onSubmit(viewModel: CryptoAddArchive) {

    this.cryptoService.EncodeAddArchive(viewModel).subscribe(addArchive => {
      this.archiveService.AddArchive(addArchive).subscribe(viewArchive => {

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
}
