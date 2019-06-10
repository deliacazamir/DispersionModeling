import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PollutionSource } from '../_models/pollution-source.model';

@Injectable({
  providedIn: 'root'
})
export class PollutionSourceService {
  formData: PollutionSource;
  readonly rootURL = 'http://localhost:5000/api/';

  constructor(private http: HttpClient) { }

  postForm(formData: PollutionSource) {
    return this.http.post( this.rootURL + 'pollutionsource', formData);
  }
}
