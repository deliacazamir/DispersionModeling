import { StationType } from './../_models/station-type.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { STP } from '../_models/stp.model';
import { PollutantList } from '../_models/pollutant-list.model';
import { Dispersion } from '../_models/dispersion.model';
import { UDM } from '../_models/udm.model';

@Injectable({
  providedIn: 'root'
})
export class StationTypeService {
  
  stationData: StationType;
  list: StationType[];

  stpData: STP;
  stpList: STP[];
  modifiedStpList: STP[] = [];
  pollutantsIdsList: number[] = [];

  formData: PollutantList;
  pollutantList: PollutantList[];

  formDispersionData: Dispersion;
  dispersionList: Dispersion[];

  udmData: UDM;

  inputsForAlgorithmList: any;

  readonly rootURL = 'http://localhost:5000/api/';

  constructor(private http: HttpClient) { }

  postDispersionForm(formDispersionData: Dispersion) {
    return this.http.post( this.rootURL + 'dispersion', formDispersionData);
  }

  postForm(stationData: StationType) {
    return this.http.post( this.rootURL + 'StationType', stationData);
  }

  postUDMForm(udmData: UDM) {
    return this.http.post( this.rootURL + 'UserDispersionModel', udmData);
  }


  refreshList() {
    this.http.get( this.rootURL + 'StationType')
    .toPromise()
    .then(res => this.list = res as StationType[]);
  }

  getDispersionListForUser(id: number) {
    this.http.get( this.rootURL + 'Dispersion/' + id)
    .toPromise()
    .then(res => this.dispersionList = res as Dispersion[]);
  }

  refreshListStp(id: number) {
    this.http.get( this.rootURL + 'StationTypePollutant/'+id)
    .toPromise()
    .then(res => this.stpList = res as STP[]);
  }

  getPollutantList() {
    this.http.get( this.rootURL + 'pollutant')
    .toPromise()
    .then(res => this.pollutantList = res as PollutantList[]);
  }

  // selectFromStpList(id: number) {
  //   this.stpList.forEach(element => {
    
  //     if( element.StationTypeID == id)
  //     {
  //       this.modifiedStpList.push(element);
  //       this.pollutantsIdsList.push(element.PollutantID);
  //     }
  //   });

  //   return this.modifiedStpList;
  // }

  
}