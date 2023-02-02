import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ImageInfo } from '../models/image-info';

@Injectable({
  providedIn: 'root'
})
export class ImagesService {
  constructor(private http: HttpClient) { }

  getImageInfo(id: string): Observable<ImageInfo> {
    return this.http.get<ImageInfo>("http://localhost:5017/api/image/" + id + "/info");
  }
}
