import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ViewTab } from '../viewmodels/views/viewtab';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  NavTabs: ViewTab[];

  ActiveTabIndex = 0;

  // Constructor
  constructor(private router: Router) {
    this.NavTabs = [
      {
        Label: 'Archives',
        Link: './management/archives',
        Index: 0
      }, {
        Label: 'Shared Archives',
        Link: './management/sharedarchives',
        Index: 1
      }
    ];
  }

  // Life Cicle
  ngOnInit() {
    this.router.events.subscribe((res) => {
      this.ActiveTabIndex = this.NavTabs.indexOf(this.NavTabs.find(tab => tab.Link === '.' + this.router.url));
    });
  }
}