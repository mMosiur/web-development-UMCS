import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { ImageInfo } from '../models/image-info';

@Injectable({
  providedIn: 'root'
})
export class ImagesService {
  constructor(private http: HttpClient) { }

  getImageInfo(id: string): Observable<ImageInfo> {
    return this.http
      .get<ImageInfo>("http://localhost:5017/api/image/" + id + "/info")
      .pipe(map((ii) => {
        ii.tags.push("Person", "Engineer", "Screenshot");
        ii.comments.push("This is a very nice pic", "Go Maksym!", "Why is that a screenshot?", "I like it");
        return ii;
      }));
  }
}
