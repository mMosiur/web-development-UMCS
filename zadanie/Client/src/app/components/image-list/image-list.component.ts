import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ImageInfo } from 'src/app/models/image-info';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-image-list',
  templateUrl: './image-list.component.html',
  styleUrls: ['./image-list.component.css']
})
export class ImageListComponent {

  images: ImageInfo[] = [];

  constructor(http: HttpClient, private authService: AuthService) {
    http.get<ImageInfo[]>('http://localhost:5017/api/image/all')
      .subscribe({
        next: (images) => {
          this.images = images;
        },
        error: (err) => {
          console.error(err);
        }
      });
  }

  function() {
    if(this.authService.isUserLoggedIn) {
      console.log("User already logged in: " + this.authService.username);
      return;
    }
    const v = this.authService.login("string", "string").subscribe({
      next: () => {
        console.log("Logged in: " + this.authService.username);
      },
      error: (err) => {
        console.warn("Log in error");
      }
    });
  }
}
