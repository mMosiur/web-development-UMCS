import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ImageComponent } from './components/image/image.component';
import { ImageListComponent } from './components/image-list/image-list.component';
import { AddImageComponent } from './components/add-image/add-image.component';
import { LogInComponent } from './components/log-in/log-in.component';
import { RegisterComponent } from './components/register/register.component';

const routes: Routes = [
  { path: '', redirectTo: '/images', pathMatch: 'full' },
  { path: 'image/:id', component: ImageComponent },
  { path: 'images', component: ImageListComponent },
  { path: 'add-image', component: AddImageComponent },
  { path: 'auth/login', component: LogInComponent },
  { path: 'auth/register', component: RegisterComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
