import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';

import { AppRoutingModule } from './app-routing.module';
import { ImageComponent } from './components/image/image.component';
import { ImageListComponent } from './components/image-list/image-list.component';
import { HttpClientModule } from '@angular/common/http';
import { AddImageComponent } from './components/add-image/add-image.component';

@NgModule({
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule
  ],
  declarations: [
    AppComponent,
    ImageComponent,
    ImageListComponent,
    AddImageComponent
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
