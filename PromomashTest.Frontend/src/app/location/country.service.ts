import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Province {
  id: number;
  name: string;
}

export interface Country {
  id: number;
  name: string;
  provinces: Province[];
}

@Injectable({ providedIn: 'root' })
export class CountryService {
  constructor(private http: HttpClient) {}

  getCountries(): Observable<Country[]> {
    return this.http.get<Country[]>(`/api/countries`);
  }

  getProvinces(countryId: number) : Observable<Province[]> {
    return this.http.get<Province[]>(`/api/Provinces/getProvinces?countryId=${countryId}`);
  }
}