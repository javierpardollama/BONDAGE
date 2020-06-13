import {
  Component,
  OnInit
} from '@angular/core';

import { ViewApplicationUser } from './../../viewmodels/views/viewapplicationuser';
import { EffortService } from './../../services/effort.service';
import { ViewEffort } from 'src/viewmodels/views/vieweffort';
import { AddEffort } from 'src/viewmodels/additions/addeffort';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {

  public isVisible = false;

  public isLoaded = false;

  public User: ViewApplicationUser;

  Effort: ViewEffort;

  // Constructor
  constructor(private effortService: EffortService) {

  }

  // Life Cicle
  ngOnInit() {

  }

  display() {

    if (!this.User && !this.isLoaded) {
      this.Load();
    }

    return this.isVisible;
  }

  public Load() {
    this.GetLocalUser();
    this.GetCurrentStatus();
    this.isLoaded = true;
    this.isVisible = true;
  }

  // Get User from Storage
  public GetLocalUser() {
    this.User = JSON.parse(localStorage.getItem('User'));
  }

  public async GetCurrentStatus() {
    this.Effort = await this.effortService.FindLastActiveEffortByApplicationUserId(this.User.Id);
  }

  public async Start() {
    const model: AddEffort =
    {
      ApplicationUserId: this.User.Id
    };

    this.Effort = await this.effortService.Start(model);
  }

  public async Stop() {
    const model: AddEffort =
    {
      ApplicationUserId: this.User.Id
    };

    this.Effort = await this.effortService.Stop(model);
  }

  public async Pause() {
    const model: AddEffort =
    {
      ApplicationUserId: this.User.Id
    };

    this.Effort = await this.effortService.Pause(model);
  }

  public async Resume() {
    const model: AddEffort =
    {
      ApplicationUserId: this.User.Id
    };

    this.Effort = await this.effortService.Resume(model);
  }
}
