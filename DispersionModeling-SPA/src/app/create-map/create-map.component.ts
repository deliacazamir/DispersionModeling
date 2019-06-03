import { Component, OnInit } from '@angular/core';
import { CreateMapService } from '../_services/create-map.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-create-map',
  templateUrl: './create-map.component.html',
  styleUrls: ['./create-map.component.scss']
})

export class CreateMapComponent implements OnInit {
  var1 = true;
  var2 = false;
  var3 = false;

  nextForm1(){
    this.var1  = false;
    this.var2 = true;
  }

  nextForm2(){
    this.var2 = false;
    this.var3 = true;
  }

  constructor(public service: CreateMapService) { }

  ngOnInit() {
    this.resetForm();
  }

  resetForm(form?: NgForm) {
    if(form != null) {
      form.resetForm();
    }
    this.service.formData = {
      Id: 0,
      SourceName: '',
      Description: ''
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
