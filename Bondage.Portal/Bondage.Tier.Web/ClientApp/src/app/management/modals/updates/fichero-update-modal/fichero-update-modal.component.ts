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

import { ViewFichero } from './../../../../../viewmodels/views/viewfichero';

import { ViewApplicationUser } from './../../../../../viewmodels/views/viewapplicationuser';

import { FicheroService } from './../../../../../services/fichero.service';

import { TextAppVariants } from './../../../../../variants/text.app.variants';

import { TimeAppVariants } from './../../../../../variants/time.app.variants';
import { UpdateFichero } from 'src/viewmodels/updates/updatefichero';

@Component({
  selector: 'app-fichero-update-modal',
  templateUrl: './fichero-update-modal.component.html',
  styleUrls: ['./fichero-update-modal.component.css']
})
export class FicheroUpdateModalComponent implements OnInit {

  public formGroup: FormGroup;

  public User: ViewApplicationUser;

  // Constructor
  constructor(
    private ficheroService: FicheroService,
    private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<FicheroUpdateModalComponent>,
    private matSnackBar: MatSnackBar,
    @Inject(MAT_DIALOG_DATA) public data: ViewFichero) { }


  // Life Cicle
  ngOnInit() {
    this.GetLocalUser();
    this.CreateForm();
  }

  // Form
  CreateForm() {
    this.formGroup = this.formBuilder.group({
      Id: [this.data.Id, [Validators.required]],
      Name: [this.data.Name,
      [Validators.required]],
      Data: [this.data.Data,
      [Validators.required]],
      By: [this.User, [Validators.required]]
    });
  }

  // Form Actions
  onSubmit(viewModel: UpdateFichero) {
    this.ficheroService.UpdateFichero(viewModel).subscribe(bandera => {

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
