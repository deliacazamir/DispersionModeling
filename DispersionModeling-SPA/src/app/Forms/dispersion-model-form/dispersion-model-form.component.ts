import { PollutionSourceService } from './../../_services/pollution-source.service';
import { AuthService } from './../../_services/auth.service';
import { StationTypeService } from './../../_services/station-type.service';
import { ToastrService } from 'ngx-toastr';
import { DispersionService } from './../../_services/dispersion.service';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { formatDate } from '@angular/common';
import { isNull } from 'util';

@Component({
  selector: 'app-dispersion-model-form',
  templateUrl: './dispersion-model-form.component.html',
  styleUrls: ['./dispersion-model-form.component.scss']
})
export class DispersionModelFormComponent implements OnInit {

  currentPollutantSource :any;
  currentDispersionModel : any;
  currentPollutant : any;
  myelement:any; 

  constructor(public service: StationTypeService, public pollutionSource: PollutionSourceService 
    ,  private authService: AuthService) { }

  ngOnInit() 
  {
    this.service.getDispersionListForUser(this.authService.decodedToken.nameid);
    this.pollutionSource.getUserInfo(this.authService.decodedToken.nameid);  
    this.service.getPollutantList();
  }

  calculateDispersion()
  {
    //Se iau datele introduse si se apeleaza API-ul care 
    console.log("AM apasat");
    this.currentPollutantSource  = this.pollutionSource.pollutionSource;
    this.currentPollutantSource.forEach(element => {
      
      console.log(element.Altitude);
      console.log(element.ChimneyDiameter);
      console.log(element.ChimneyHeight);
      console.log(element.Longitude);
      console.log(element.Latitude);
      console.log(element.TerrainType);
    });

    this.currentDispersionModel  = this.service.dispersionList;
    
    this.myelement = this.currentDispersionModel.pop();
    
      console.log(this.myelement.AirTemperature);
     // console.log(this.myelement.AtmosphericConditions);
      console.log(this.myelement.CloudCoverage);
      console.log(this.myelement.EmissionOfPollutantsConcentration);
      console.log(this.myelement.ExitTemperature);
      //console.log(this.myelement.MaxDistance);
      //console.log(this.myelement.PollutantID);
      console.log(this.myelement.SmokeExitSpeed);
      console.log(this.myelement.SolarRadiations);
      //console.log(this.myelement.WindDirection);
      console.log(this.myelement.WindSpeedAtTenMetters); 

      this.currentPollutant = this.service.pollutantList;

      this.currentPollutant.forEach(element => {
         if(element.Id == this.myelement.PollutantID) {
          console.log(element.Name);
          console.log(element.StateOfAggregation);
          console.log(element.SedimentationSpeed);
         }
      });

     // this.service.inputsForAlgorithmList = this.myelement;
      //this.service.inputsForAlgorithmList.push(this.currentPollutant);
     // this.service.inputsForAlgorithmList.push.apply(this.service.inputsForAlgorithmList,this.currentPollutantSource);

     console.log("AICI e o lista goala momentan: " + this.service.inputsForAlgorithmList);

  }

}
