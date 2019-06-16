import { PollutionSource } from './../_models/pollution-source.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PollutionSourceService {

  formData: PollutionSource;
  pollutionSource: PollutionSource;

  readonly rootURL = 'http://localhost:5000/api/';

  constructor(private http: HttpClient) { }

  postForm(formData: PollutionSource) {
    return this.http.post( this.rootURL + 'pollutionsource', formData);
  }

  getUserInfo(id:number) {
    this.http.get( this.rootURL + 'pollutionsource/'+id)
    .toPromise()
    .then(res => this.pollutionSource = res as PollutionSource);
  }
}
