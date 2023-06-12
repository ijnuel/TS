import { Component, OnDestroy, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/services/identity-server';

@Component({
  selector: '<body[root]>',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.scss'],
  providers: [AuthenticationService]
})
export class AuthComponent implements OnInit, OnDestroy {
  today: Date = new Date();

  constructor() {}

  ngOnInit(): void {
    document.body.classList.add('bg-white');
  }

  ngOnDestroy() {
    document.body.classList.remove('bg-white');
  }
}
