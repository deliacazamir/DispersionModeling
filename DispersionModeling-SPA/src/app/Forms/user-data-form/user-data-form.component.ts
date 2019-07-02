import { formatDate } from '@angular/common';
import { AuthService } from './../../_services/auth.service';
import { StationTypeService } from './../../_services/station-type.service';
import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { NgForm, FormControl } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-user-data-form',
  templateUrl: './user-data-form.component.html',
  styleUrls: ['./user-data-form.component.scss'],
  providers: [DatePipe]
})

export class UserDataFormComponent implements OnInit {

  constructor(public service: StationTypeService, private toastr: ToastrService, public authService: AuthService,private datePipe: DatePipe) { 
  }
  
  shifter: boolean = false;
  id: number;
  idPollutant: number;
  formatDate : string = 'dd-MM-yyyy HH:mm:ss';
  dateNow : Date = new Date();


  cloudCoverageList = ['LOW','HIGH']
  idCloudCoverage: string;

  solarRadiationsList = ['STRONG','MODERATE', 'SLIGHT']
  idSolarRadiations: string;
  

  ngOnInit() {
    this.service.refreshList();
    this.resetForm(); 
    console.log(this.authService.decodedToken.nameid);   
  }

  selectSolarRadiation()
  {
    console.log("Solar Radiation:",this.idSolarRadiations);
    if (this.idSolarRadiations == 'STRONG')  this.service.formDispersionData.SolarRadiations = 1;
    if (this.idSolarRadiations == 'MODERATE')  this.service.formDispersionData.SolarRadiations = 2;
    else this.service.formDispersionData.SolarRadiations = 3;
  }

  selectCloudCoverage() 
  {
    console.log("Cloud coverage:",this.idCloudCoverage);
    if (this.idCloudCoverage == 'LOW')  this.service.formDispersionData.CloudCoverage = 1;
    else this.service.formDispersionData.CloudCoverage = 2;
  }

  selected() {
    this.shifter = true;
    this.service.refreshListStp(this.id);
    this.service.formDispersionData.PollutantID = this.idPollutant;
    this.service.udmData.UserID = this.authService.decodedToken.nameid;

    if (this.idCloudCoverage == 'LOW')  this.service.formDispersionData.CloudCoverage = 1;
    else this.service.formDispersionData.CloudCoverage = 2;

    if (this.idSolarRadiations == 'STRONG')  this.service.formDispersionData.SolarRadiations = 1;
    if (this.idSolarRadiations == 'MODERATE')  this.service.formDispersionData.SolarRadiations = 2;
    else this.service.formDispersionData.SolarRadiations = 3;
  }

  resetForm(form?: NgForm) {
    
    if(form != null) {
      form.resetForm();
    }
    this.service.formDispersionData = {
      Id: 0,
      SmokeExitSpeed: 0.0,
      ExitTemperature: 0.0,
      EmissionOfPollutantsConcentration: 0.0,
      CurrentDate: this.datePipe.transform(this.dateNow, this.formatDate),
      CloudCoverage: 0.0,
      AtmosphericConditions: 0.0,
      AirTemperature: 0.0,
      SolarRadiations: 0.0,
      WindDirection: 0.0,
      WindSpeedAtTenMetters: 0.0,
      MaxDistance: 0.0,
      PollutantID: 0
    }
    this.service.udmData = {
      UserID: 0,
      DispersionModelID: 0
    }
  }

  onSubmit(form: NgForm) {
  
    console.log("Submit Cloud Cov:",this.service.formDispersionData.CloudCoverage);
    console.log("Submit Solar Rad:",this.service.formDispersionData.SolarRadiations);
    this.service.postDispersionForm(form.value).subscribe(
      res => {
        this.resetForm(form);
        this.toastr.success('Submitted Successfully', 'Dispersion Model');
      },
      err => {
        console.log(err);
      }
    );
  }

}
