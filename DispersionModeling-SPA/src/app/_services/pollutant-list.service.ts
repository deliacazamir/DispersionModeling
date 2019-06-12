import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PollutantList } from '../_models/pollutant-list.model';

@Injectable({
  providedIn: 'root'
})
export class PollutantListService {
  formData: PollutantList;
  pollutantList: PollutantList[];

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
}
