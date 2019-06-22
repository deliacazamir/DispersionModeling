import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};

  constructor(private authService: AuthService, private router: Router, private toastr: ToastrService) { }

  ngOnInit() {
  }

  login() {
    this.authService.login(this.model).subscribe(next => {
      console.log('Logged in successfully');
      this.toastr.success('Logged in successfully', 'Login Info');
    }, error => {
      console.log('Failed to login');
      this.toastr.error('Failed to login', 'Login info');
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
