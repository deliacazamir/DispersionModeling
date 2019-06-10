import { StationType } from './../_models/station-type.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class StationTypeService {
  stationData: StationType;
  readonly rootURL = 'http://localhost:5000/api/';
  list: StationType[];

  constructor(private http: HttpClient) { }

  postForm(stationData: StationType) {
    return this.http.post( this.rootURL + 'StationType', stationData);
  }

  refreshList() {
    this.http.get( this.rootURL + 'StationType')
    .toPromise()
    .then(res => this.list = res as StationType[]);
  }
}