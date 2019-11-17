import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  navLinks: any[];
  
  activeLinkIndex = 0;

  // Constructor
  constructor(private router: Router) {
    this.navLinks = [
      {
        label: 'Archives',
        link: './management/archives',
        index: 0
      }, {
        label: 'Shared Archives',
        link: './management/sharedarchives',
        index: 1
      }
    ];
  }
  // Life Cicle
  ngOnInit() {
    this.router.events.subscribe((res) => {
      this.activeLinkIndex = this.navLinks.indexOf(this.navLinks.find(tab => tab.link === '.' + this.router.url));
    });
  }
}