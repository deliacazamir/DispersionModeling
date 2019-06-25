import { Dispersion } from './../_models/dispersion.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DispersionService {
  formDispersionData: Dispersion;
  readonly rootURL = 'http://localhost:5000/api/';

  constructor(private http: HttpClient) { }

  postDispersionForm(formDispersionData: Dispersion) {
    return this.http.post( this.rootURL + 'dispersion', formDispersionData);
  }
}
