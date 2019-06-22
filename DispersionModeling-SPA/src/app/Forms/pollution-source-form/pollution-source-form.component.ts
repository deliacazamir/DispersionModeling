import { AuthService } from './../../_services/auth.service';
import { PollutionSourceService } from './../../_services/pollution-source.service';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-pollution-source-form',
  templateUrl: './pollution-source-form.component.html',
  styleUrls: ['./pollution-source-form.component.scss']
})
export class PollutionSourceFormComponent implements OnInit {

  // loggedUserInfo = this.service.getUserInfo(this.authService.decodedToken.nameid);

  constructor(public service: PollutionSourceService, private toastr: ToastrService,
    public authService: AuthService) { }

  ngOnInit() {
    this.resetForm();
    this.service.getUserInfo(this.authService.decodedToken.nameid);
    console.log(this.authService.decodedToken.nameid);
    this.service.formData.UserID = this.authService.decodedToken.nameid;
  }

  resetForm(form?: NgForm) {
    if(form != null) {
      form.resetForm();
    }
    this.service.formData = {
      Id: 0,
      Name: '',
      Description: '',
      Longitude: null,
      Latitude: null,
      Altitude: null,
      ChimneyHeight: null,
      ChimneyDiameter: null,
      TerrainType: '',
      UserID: null
    }
    
  }

  onSubmit(form: NgForm) {
    this.service.postForm(form.value).subscribe(
      res => {
        this.resetForm(form);
        this.toastr.success('Submitted Successfully', 'Power Plant Info');
      },
      err => {
        console.log(err);
        this.toastr.error('Submission Failed');
      }
    );
  }

}
