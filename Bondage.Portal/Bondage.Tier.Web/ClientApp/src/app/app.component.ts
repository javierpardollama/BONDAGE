import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {


  ActiveTabIndex = 0;

  // Constructor
  constructor(
    private router: Router) {
  }

  // Life Cicle
  ngOnInit() {
  }
}