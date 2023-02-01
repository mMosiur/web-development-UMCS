import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ImageInfo } from 'src/app/models/image-info';
import { ImagesService } from 'src/app/services/images.service';

@Component({
  selector: 'app-image',
  templateUrl: './image.component.html',
  styleUrls: ['./image.component.css']
})
export class ImageComponent {

  id: string;
  loading: boolean;
  imageInfo?: ImageInfo;
  imageUrl?: string;

  constructor(
    private route: ActivatedRoute,
    imagesService: ImagesService
  ) {
    this.loading = true;
    this.id = this.route.snapshot.paramMap.get('id') || '';
    imagesService.getImageInfo(this.id)
      .subscribe(
        {
          next: (value) => {
            this.imageInfo = value;
            this.imageUrl = "http://localhost:5017/api/image/" + this.id;
            this.loading = false;
          },
          error: (error) => {
            console.warn(error);
            this.loading = false;
          }
        });
  }
}
