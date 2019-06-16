import { PollutantListService } from './../../_services/pollutant-list.service';
import { StationTypeService } from './../../_services/station-type.service';
import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { isSyntheticPropertyOrListener } from '@angular/compiler/src/render3/util';
import { NgForm, FormControl } from '@angular/forms';
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
    this.shifter = true;
    this.service.refreshListStp(this.id);
    this.service.formDispersionData.PollutantID = this.idPollutant;
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
      CurrentDate: new Date(),
      CloudCoverage: 0.0,
      AtmosphericConditions: 0.0,
      AirTemperature: 0.0,
      SolarRadiations: 0.0,
      WindDirection: '',
      WindSpeedAtTenMetters: 0.0,
      MaxDistance: 0.0,
      PollutantID: 0
    }
  }

  onSubmit(form: NgForm) {
  
    this.service.postDispersionForm(form.value).subscribe(
      res => {
        this.resetForm(form);
        console.log("ID Pollutant:",this.service.formDispersionData.PollutantID);
        console.log("ID Pollutant Form:"+this.idPollutant);
        this.toastr.success('Submitted Successfully', 'Dispersion Model');
      },
      err => {
        console.log(err);
      }
    );
  }

}
