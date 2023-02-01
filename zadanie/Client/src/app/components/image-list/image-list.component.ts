import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ImageInfo } from 'src/app/models/image-info';

@Component({
  selector: 'app-image-list',
  templateUrl: './image-list.component.html',
  styleUrls: ['./image-list.component.css']
})
export class ImageListComponent {

  images: ImageInfo[] = [];

  constructor(http: HttpClient) {
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
}
