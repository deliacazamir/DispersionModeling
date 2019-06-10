import { StationTypeService } from './../../_services/station-type.service';
import { Component, OnInit } from '@angular/core';
// import {MatSelectModule} from '@angular/material/select';

@Component({
  selector: 'app-user-data-form',
  templateUrl: './user-data-form.component.html',
  styleUrls: ['./user-data-form.component.scss']
})
export class UserDataFormComponent implements OnInit {

  constructor(public service: StationTypeService) { }

  ngOnInit() {
    this.service.refreshList();
  }

}
