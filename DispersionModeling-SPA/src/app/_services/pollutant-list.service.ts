import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PollutantList } from '../_models/pollutant-list.model';
import { GPS } from '../_models/gps.model';

@Injectable({
  providedIn: 'root'
})


export class PollutantListService {
  
  formData: PollutantList;
  pollutantList: PollutantList[];
  gpsList: GPS[];
  public gpsPollutantList: GPS[];

  readonly rootURL = 'http://localhost:5000/api/';

  constructor(private http: HttpClient) { }

  postForm(formData: PollutantList) {
    return this.http.post( this.rootURL + 'pollutant', formData);
  }

  refreshPollutantList() {
    this.http.get( this.rootURL + 'pollutant')
    .toPromise()
    .then(res => this.pollutantList = res as PollutantList[]);
  }

  getGpsList() {
    this.http.get( this.rootURL + 'gpslocation')
    .toPromise()
    .then(res => this.gpsList = res as GPS[]);
  }

  getConcentrationForPollutant(id: number) {
    this.http.get( this.rootURL + 'gpslocation/' + id).
    toPromise().
    then(res => this.gpsPollutantList = res as GPS[]);
    
  }

  
}
