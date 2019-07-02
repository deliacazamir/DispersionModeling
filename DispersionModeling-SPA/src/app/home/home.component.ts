import { GPS } from './../_models/gps.model';
import { logging } from 'protractor';
import { Component, OnInit } from '@angular/core';
import { AgmOverlays } from "agm-overlays";
import { PollutantListService } from 'src/app/_services/pollutant-list.service';



@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {


  private map: google.maps.Map = null;
  private heatmap: google.maps.visualization.HeatmapLayer = null;
  LatLong : google.maps.LatLng = null;
  
  locationChosen = false;
  longitude = -71.200324;
  latitude = 18.952135;
  zoom = 5;
  mapType = "satellite";
  idLocation : GPS;
  idPollutant: number;  
  currentGpsInfo: GPS[];
  myWeightedData:any[];


  onMapLoad(mapInstance: google.maps.Map) {
    
    this.map = mapInstance;
    this.LatLong = new google.maps.LatLng(this.latitude,this.longitude);
    this.map.setCenter(this.LatLong);
    this.map.setZoom(this.zoom);

    this.myWeightedData = [
      {location: new google.maps.LatLng(40.922326,-72.637078), weight: 5},
      {location: new google.maps.LatLng(40.922326,-72.637078), weight: 5},
      {location: new google.maps.LatLng(18.165273,-66.722583), weight: 5},
      {location: new google.maps.LatLng(18.393103,-67.180953), weight: 5},
      {location: new google.maps.LatLng(18.455913,-67.14578), weight: 5},
      new google.maps.LatLng(18.49352,-67.135883)
      ];
      
    this.heatmap = new google.maps.visualization.HeatmapLayer({
        map: this.map,
        radius:100,
        data: this.myWeightedData
    });
 
}

  constructor(private service: PollutantListService) {
  }

  ngOnInit() {
    this.service.refreshPollutantList();
    
    this.selected();
  }

  setMapType(mapTypeId: string) {
    this.map.setMapTypeId(mapTypeId)    
  }

  onChoseLocation(event){
    this.latitude = event.coords.lat;
    this.longitude = event.coords.lng;
    this.locationChosen = true;
  }

  selected(){

    console.log("S-a selectat poluant id:",this.idPollutant);

    try{
    this.service.getConcentrationForPollutant(1);

        this.service.gpsPollutantList.forEach(element => 
          {
             this.myWeightedData.push(
            {location:new google.maps.LatLng(element.Latitude,element.Longitude), weight: element.Concentration}
           );
          
         console.log(element.Concentration);
         console.log(element.Latitude);
         console.log(element.Longitude);
       
     });

     this.heatmap = new google.maps.visualization.HeatmapLayer({
      map: this.map,
      radius:100,
      data: this.myWeightedData
    });

    } catch (E) {console.log(E);}

  }

  selectedLocation()
  {
    console.log(this.idLocation);
    this.LatLong = new google.maps.LatLng(this.idLocation.Latitude,this.idLocation.Longitude);
    this.map.setCenter(this.LatLong);
  }
 
}
