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

import { AddFichero } from './../../../../../viewmodels/additions/addfichero';

import { ViewApplicationUser } from './../../../../../viewmodels/views/viewapplicationuser';

import { FicheroService } from './../../../../../services/fichero.service';

import { TextAppVariants } from './../../../../../variants/text.app.variants';

import { TimeAppVariants } from './../../../../../variants/time.app.variants';

@Component({
  selector: 'app-fichero-add-modal',
  templateUrl: './fichero-add-modal.component.html',
  styleUrls: ['./fichero-add-modal.component.css']
})
export class FicheroAddModalComponent implements OnInit {

  public formGroup: FormGroup;

  public User: ViewApplicationUser;

  // Constructor
  constructor(
    private ficheroService: FicheroService,
    private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<FicheroAddModalComponent>,
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
  onSubmit(viewModel: AddFichero) {
    this.ficheroService.AddFichero(viewModel).subscribe(bandera => {

      if (bandera !== undefined) {
        this.matSnackBar.open(
          TextAppVariants.AppOperationSuccessCoreText,
          TextAppVariants.AppOkButtonText,
          { duration: TimeAppVariants.AppToastSecondTicks * TimeAppVariants.AppTimeSecondTicks });
      }

      this.dialogRef.close();
    });
  }

  // Get User from Storage
  public GetLocalUser() {
    this.User = JSON.parse(localStorage.getItem('User'));
  }
}
