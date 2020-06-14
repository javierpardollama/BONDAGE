import { Component, OnInit } from '@angular/core';
import { EffortService } from './../../../../services/effort.service';
import { ViewEffort } from './../../../../viewmodels/views/vieweffort';
import { ViewApplicationUser } from './../../../../viewmodels/views/viewapplicationuser';
import { MatSnackBar } from '@angular/material/snack-bar';
import { TextAppVariants } from './../../../../variants/text.app.variants';
import { TimeAppVariants } from './../../../../variants/time.app.variants';

@Component({
  selector: 'app-effort-list',
  templateUrl: './effort-list.component.html',
  styleUrls: ['./effort-list.component.css']
})
export class EffortListComponent implements OnInit {

  public Efforts: ViewEffort[];

  public User: ViewApplicationUser;

  constructor(
    private effortService: EffortService,
    private matSnackBar: MatSnackBar) { }

  ngOnInit() {
    this.FindAllEffortByApplicationUserId();
  }

  // Get Data from Service
  public async FindAllEffortByApplicationUserId() {
    this.Efforts = await this.effortService.FindAllEffortByApplicationUserId(this.User.Id);
  }

  onDelete(id: number) {
    this.effortService.RemoveEffortById(id).subscribe(effort => {

      this.matSnackBar.open(
        TextAppVariants.AppOperationSuccessCoreText,
        TextAppVariants.AppOkButtonText,
        { duration: TimeAppVariants.AppToastSecondTicks * TimeAppVariants.AppTimeSecondTicks });

      this.FindAllEffortByApplicationUserId();
    });
  }

  // Get User from Storage
  public GetLocalUser() {
    this.User = JSON.parse(localStorage.getItem('User'));
  }
}
