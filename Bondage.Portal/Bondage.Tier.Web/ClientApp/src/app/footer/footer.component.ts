import {
  Component,
  OnInit
} from '@angular/core';

import { ViewApplicationUser } from './../../viewmodels/views/viewapplicationuser';
import { EffortService } from './../../services/effort.service';
import { ViewEffort } from 'src/viewmodels/views/vieweffort';
import { AddBreak } from 'src/viewmodels/additions/addbreak';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {

  public isVisible = false;

  public User: ViewApplicationUser;

  public Effort: ViewEffort;

  // Constructor
  constructor(private effortService: EffortService) {

  }

  // Life Cicle
  ngOnInit() {

  }

  display() {
    this.GetLocalUser();

    if (this.User !== null) {
      this.isVisible = true;
    }

    return this.isVisible;
  }

  // Get User from Storage
  public GetLocalUser() {
    this.User = JSON.parse(localStorage.getItem('User'));
  }

  public async Start() {
    const model: AddBreak =
    {
      ApplicationUserId: this.User.Id
    };

    await this.effortService.Start(model);
  }

  public async Stop() {
    const model: AddBreak =
    {
      ApplicationUserId: this.User.Id
    };

    await this.effortService.Stop(model);
  }

  public async Pause() {
    const model: AddBreak =
    {
      ApplicationUserId: this.User.Id
    };

    await this.effortService.Pause(model);
  }

  public async Resume() {
    const model: AddBreak =
    {
      ApplicationUserId: this.User.Id
    };

    await this.effortService.Resume(model);
  }
}
