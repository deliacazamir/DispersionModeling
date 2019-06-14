import { PollutantListService } from './../../_services/pollutant-list.service';
import { StationTypeService } from './../../_services/station-type.service';
import { Component, OnInit } from '@angular/core';
import { isSyntheticPropertyOrListener } from '@angular/compiler/src/render3/util';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-user-data-form',
  templateUrl: './user-data-form.component.html',
  styleUrls: ['./user-data-form.component.scss']
})

export class UserDataFormComponent implements OnInit {

  constructor(public service: StationTypeService, private toastr: ToastrService) { }

  shifter: boolean = false;
  id: number;
  idPollutant: number;
  
  ngOnInit() {
    this.service.refreshList();
    this.resetForm();
  }

  selected(){
    console.log(this.id);
    console.log(this.idPollutant);
    this.shifter = true;
    this.service.refreshListStp(this.id);
  }

  resetForm(form?: NgForm) {
    if(form != null) {
      form.resetForm();
    }
    this.service.formDispersionData = {
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
      MaxDistance: null,
      PollutantID: this.idPollutant
    }
  }

  onSubmit(form: NgForm) {
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
