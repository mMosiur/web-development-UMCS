import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { AuthResponse } from '../models/auth-response';
import { AuthRequest } from '../models/auth-request';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  get isUserLoggedIn(): boolean {
    return !!localStorage.getItem('token');
  }

  get username(): string | null {
    return localStorage.getItem('username');
  }

  get token(): string | null {
    return localStorage.getItem('token');
  }

  login(userName: string, password: string): Observable<void> {
    const request: AuthRequest = { username: userName, password: password };
    return this.http.post<AuthResponse>("http://localhost:5017/api/auth/login", request)
      .pipe(map(response => {
        console.log(response);
        if (response.success) {
          localStorage.setItem('username', userName);
          localStorage.setItem('token', response.token!);
          console.log("token saved: " + response.token!);
        }
      }));
  }

  register(userName: string, password: string): Observable<void> {
    const request: AuthRequest = { username: userName, password: password };
    return this.http.post<AuthResponse>("http://localhost:5017/api/auth/register", request)
      .pipe(map(response => {
        console.log(response);
        if (response.success) {
          localStorage.setItem('username', userName);
          localStorage.setItem('token', response.token!);
          console.log("token saved: " + response.token!);
        }
      }));
  }

  logout(): void {
    localStorage.removeItem('username');
    localStorage.removeItem('token');
  }
}
