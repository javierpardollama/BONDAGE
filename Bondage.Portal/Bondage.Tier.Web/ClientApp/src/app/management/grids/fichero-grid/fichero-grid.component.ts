import {
  Component,
  OnInit,
  ViewChild
} from '@angular/core';

import {
  MatTableDataSource,
  MatPaginator,
  MatSort,
  MatDialog
} from '@angular/material';

import { ViewFichero } from './../../../../viewmodels/views/viewfichero';

import { ViewApplicationUser } from './../../../../viewmodels/views/viewapplicationuser';

import { FicheroService } from './../../../../services/fichero.service';

import {
  FicheroUpdateModalComponent
} from './../../modals/updates/fichero-update-modal/fichero-update-modal.component';

import {
  FicheroAddModalComponent
} from './../../modals/additions/fichero-add-modal/fichero-add-modal.component';

@Component({
  selector: 'app-fichero-grid',
  templateUrl: './fichero-grid.component.html',
  styleUrls: ['./fichero-grid.component.css']
})
export class FicheroGridComponent implements OnInit {

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  public ELEMENT_DATA: ViewFichero[];

  public displayedColumns: string[] = ['Id', 'Name', 'LastModified'];

  public dataSource: MatTableDataSource<ViewFichero>;

  public User: ViewApplicationUser;

  // Constructor
  constructor(
    private ficheroService: FicheroService,
    public matDialog: MatDialog) {

  }

  // Life Cicle
  ngOnInit() {
    this.GetLocalUser();
    this.FindAllFicheroByApplicationUserId();
  }

  // Get User from Storage
  public GetLocalUser() {
    this.User = JSON.parse(localStorage.getItem('User'));
  }

  // Get Data from Service
  public FindAllFicheroByApplicationUserId() {
    this.ficheroService.FindAllFicheroByApplicationUserId(this.User.Id).subscribe(poblaciones => {
      this.ELEMENT_DATA = poblaciones;

      this.SetupMyTableSettings();
    });
  }

  // Setup Table Settings
  public SetupMyTableSettings() {
    this.dataSource = new MatTableDataSource(this.ELEMENT_DATA);

    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  // Filter Data
  public ApplyMyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  // Get Record from Table
  public GetRecord(row: ViewFichero) {
    const dialogRef = this.matDialog.open(FicheroUpdateModalComponent, {
      width: '450px',
      data: row
    });

    dialogRef.afterClosed().subscribe(result => {
      this.FindAllFicheroByApplicationUserId();
    });
  }

  public AddRecord() {
    const dialogRef = this.matDialog.open(FicheroAddModalComponent, {
      width: '450px',
    });

    dialogRef.afterClosed().subscribe(result => {
      this.FindAllFicheroByApplicationUserId();
    });
  }
}
