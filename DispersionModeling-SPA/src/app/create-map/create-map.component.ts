import { Component, OnInit } from '@angular/core';
import { CreateMapService } from '../_services/create-map.service';
import { NgForm } from '@angular/forms';
import { PollutantListService } from '../_services/pollutant-list.service';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-create-map',
  templateUrl: './create-map.component.html',
  styleUrls: ['./create-map.component.scss']
})

export class CreateMapComponent implements OnInit {
  var1 = true;
  var2 = false;
  var3 = false;

  var21 = 'warning';
  var22 = 'completed';
  var23 = 'completed';

  nextForm1() {
    this.var1 = true;
    this.var2 = false;
    this.var3 = false;

    this.var21 = 'warning';
    this.var22 = 'completed';
    this.var23 = 'completed';
  }

  nextForm2() {
    this.var1  = false;
    this.var2 = true;
    this.var3 = false;

    this.var21 = 'completed';
    this.var22 = 'warning';
    this.var23 = 'completed';
  }

  nextForm3() {
    this.var1 = false;
    this.var2 = false;
    this.var3 = true;

    this.var21 = 'completed';
    this.var22 = 'completed';
    this.var23 = 'warning';
  }

  constructor(public service: PollutantListService ) { }

  ngOnInit() {
    this.resetForm();
  }

  resetForm(form?: NgForm) {
    if(form != null) {
      form.resetForm();
    }
    this.service.formData = {
      Id: 0,
      Name: '',
      ChemicalFormula: '',
      Unit: '',
      IsCarcinogenic: false,
      OrganicType: '',
      SedimentationSpeed: 0,
      StateOfAggregation: '',
      LegislativeValue: 0
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
