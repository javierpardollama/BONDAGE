import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ViewTab } from './../viewmodels/views/viewtab';
import { NavigationService } from './../services/navigation.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  NavTabs: ViewTab[];

  ActiveTabIndex = 0;

  // Constructor
  constructor(
    private router: Router,
    private navigationService: NavigationService) {
    this.NavTabs = this.navigationService.GetArchiveManagementNavigationTabs();
  }

  // Life Cicle
  ngOnInit() {
    this.router.events.subscribe((res) => {
      this.ActiveTabIndex = this.NavTabs.indexOf(this.NavTabs.find(tab => tab.Link === '.' + this.router.url));
    });
  }
}