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
import { StepperOverviewComponent } from './stepper-overview/stepper-overview.component';
import { AuthGuard } from './_guards/auth.guard';

@NgModule({
   declarations: [
      AppComponent,
      routingComponents,
      NavComponent,
      StepperOverviewComponent
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      HttpClientModule,
      FormsModule,
      AgmCoreModule.forRoot({apiKey: 'insert key here'}),
      MDBBootstrapModule.forRoot()
   ],
   providers: [
      AuthService,
      CreateMapService,
      AuthGuard
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
