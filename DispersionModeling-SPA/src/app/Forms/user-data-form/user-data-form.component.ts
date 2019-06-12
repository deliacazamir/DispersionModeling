import { PollutantListService } from './../../_services/pollutant-list.service';
import { StationTypeService } from './../../_services/station-type.service';
import { Component, OnInit } from '@angular/core';
import { isSyntheticPropertyOrListener } from '@angular/compiler/src/render3/util';


@Component({
  selector: 'app-user-data-form',
  templateUrl: './user-data-form.component.html',
  styleUrls: ['./user-data-form.component.scss']
})

export class UserDataFormComponent implements OnInit {

  constructor(public service: StationTypeService) { }

  shifter: boolean = false;
  id: number;
  
  ngOnInit() {

    this.service.refreshList();
  }

  selected(){
    console.log(this.id)
    this.shifter = true;
    this.service.refreshListStp(this.id);
  }


}
