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

  nextForm1() {
    this.var1 = true;
    this.var2 = false;
    this.var3 = false;
  }

  nextForm2() {
    this.var1  = false;
    this.var2 = true;
    this.var3 = false;
  }

  nextForm3() {
    this.var1 = false;
    this.var2 = false;
    this.var3 = true;
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
