import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';

interface AddImageRequest {
  title: string;
  description: string;
  file: File | null;
  spaceSeparatedTags: string;
}

interface AddImageResponse {
  imageId: string;
}

@Component({
  selector: 'app-add-image',
  templateUrl: './add-image.component.html',
  styleUrls: ['./add-image.component.css']
})
export class AddImageComponent {

  constructor(private http: HttpClient, private router: Router) { }

  request: AddImageRequest = {
    title: "",
    description: "",
    spaceSeparatedTags: "",
    file: null
  }

  onSubmit() {
    console.log(this.request);
    const formData = new FormData();
    if (!this.request.file) {
      return;
    }
    formData.append("title", this.request.title);
    formData.append("description", this.request.description);
    formData.append("spaceSeparatedTags", this.request.spaceSeparatedTags);
    formData.append("file", this.request.file, this.request.file.name);
    this.http.post("http://localhost:5017/api/image", formData)
      .subscribe({
        next: (data) => {
          const id = (data as AddImageResponse).imageId;
          this.router.navigate(["/image/" + id]);
        },
        error: (error) => {
          console.warn(error);
        }
      });
  }

  handleFileInput(target: EventTarget | null) {
    const files = (target as HTMLInputElement).files;
    if (!files || files.length === 0) {
      this.request.file = null;
      return;
    }
    this.request.file = files[0];
  }
}
