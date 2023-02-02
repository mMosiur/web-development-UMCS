import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Comment } from 'src/app/models/comment';
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

  comment: string = "";

  get cleanedComment() {
    return this.comment.trim();
  }

  constructor(
    route: ActivatedRoute,
    imagesService: ImagesService,
    private http: HttpClient
  ) {
    this.loading = true;
    this.id = route.snapshot.paramMap.get('id') || '';
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

  onAddComment() {
    this.http.post<Comment>("http://localhost:5017/api/image/" + this.id + "/add-comment", {
      comment: this.cleanedComment
    }).subscribe({
      next: (value) => {
        this.imageInfo?.comments.push(value);
        this.comment = "";
      },
      error: (error) => {
        console.warn(error);
      }
    });
  }
}
