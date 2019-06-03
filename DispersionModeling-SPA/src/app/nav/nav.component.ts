import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};

  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit() {
  }

  login() {
    this.authService.login(this.model).subscribe(next => {
      console.log('Logged in successfully');
    }, error => {
      console.log('Failed to login');
    }, () => {
      this.router.navigate(['/create-map']);
    });
  }

  loggedIn(){
    return this.authService.loggedIn();
  }

  loggedOut() {
    localStorage.removeItem('token');
    console.log('logged out');
    this.router.navigate(['/home']);
  }

}
