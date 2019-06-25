import { Injectable } from '@angular/core';
import { CreateMap } from '../_models/create-map.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CreateMapService {
  formData: CreateMap;
  readonly rootURL = 'http://localhost:5000/api/';

  constructor(private http: HttpClient) { }

  postForm(formData: CreateMap) {
    return this.http.post( this.rootURL + 'Form', formData);
  }
}
