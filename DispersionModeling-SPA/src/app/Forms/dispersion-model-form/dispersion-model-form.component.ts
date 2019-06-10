import { DispersionService } from './../../_services/dispersion.service';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { formatDate } from '@angular/common';

@Component({
  selector: 'app-dispersion-model-form',
  templateUrl: './dispersion-model-form.component.html',
  styleUrls: ['./dispersion-model-form.component.scss']
})
export class DispersionModelFormComponent implements OnInit {

  constructor(public service: DispersionService) { }

  ngOnInit() {
    this.resetForm();
  }

  resetForm(form?: NgForm) {
    if(form != null) {
      form.resetForm();
    }
    this.service.formData = {
      Id: 0,
      SmokeExitSpeed: null,
      ExitTemperature: null,
      EmissionOfPollutantsConcentration: null,
      CurrentDate: new Date(),
      CloudCoverage: null,
      AtmosphericConditions: null,
      AirTemperature: null,
      SolarRadiations: null,
      WindDirection: '',
      WindSpeedAtTenMetters: null,
      MaxDistance: null
    }
  }

  onSubmit(form: NgForm) {
    this.service.postForm(form.value).subscribe(
      res => {
        this.resetForm(form);
      },
      err => {
        console.log(err);
      }
    );
  }

}
