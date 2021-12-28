import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { NavComponent } from './nav/nav.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
      AppComponent,
      NavComponent
  ],
  imports: [
    BrowserModule, 
    AppRoutingModule,
    HttpClientModule,
    TooltipModule.forRoot(),
    FormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
