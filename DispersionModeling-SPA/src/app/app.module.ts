import { PollutionSourceService } from './_services/pollution-source.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AgmCoreModule ,GoogleMapsAPIWrapper } from '@agm/core';
import { AgmOverlays } from "agm-overlays";
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { AppRoutingModule, routingComponents } from './app-routing.module';


import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { AuthService } from './_services/auth.service';

import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { CreateMapService } from './_services/create-map.service';
import { AuthGuard } from './_guards/auth.guard';
import { PollutantListService } from './_services/pollutant-list.service';
import { PollutionSourceFormComponent } from './Forms/pollution-source-form/pollution-source-form.component';
import { DispersionModelFormComponent } from './Forms/dispersion-model-form/dispersion-model-form.component';
import { UserDataFormComponent } from './Forms/user-data-form/user-data-form.component';
import { NO_ERRORS_SCHEMA } from '@angular/compiler/src/core';
import { NgxHeatMapModule } from 'ngx-heatmap';

@NgModule({
   declarations: [
      AppComponent,
      routingComponents,
      NavComponent,
      PollutionSourceFormComponent,
      DispersionModelFormComponent,
      UserDataFormComponent
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      HttpClientModule,
      FormsModule,
      MDBBootstrapModule.forRoot(),
      BrowserAnimationsModule,
      ToastrModule.forRoot(),
      AgmOverlays,
      AgmCoreModule.forRoot({ apiKey:'',libraries:['visualization','places', 'drawing', 'geometry']}),
      NgxHeatMapModule
   ],
 
   providers: [
      AuthService,
      CreateMapService,
      AuthGuard,
      PollutantListService,
      PollutionSourceService,
      GoogleMapsAPIWrapper
   ],
   bootstrap: [
      AppComponent
   ]
   
})
export class AppModule { }
