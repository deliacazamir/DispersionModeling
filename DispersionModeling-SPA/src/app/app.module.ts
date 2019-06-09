import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AgmCoreModule } from '@agm/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

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
      AgmCoreModule.forRoot({apiKey: 'Insert key here'}),
      MDBBootstrapModule.forRoot()
   ],
   providers: [
      AuthService,
      CreateMapService,
      AuthGuard,
      PollutantListService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
