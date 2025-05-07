import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface RegisterUserRequest {
  email: string;
  password: string;
  countryId: number;
  provinceId: number;
}

@Injectable({ providedIn: 'root' })
export class UserService {
  constructor(private http: HttpClient) {}

  registerUser(data: RegisterUserRequest): Observable<void> {
    return this.http.post<void>('/api/users/register', data);
  }
}