import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class RegistrationDataService {
  private formData: any = {};

  setData(data: any) {
    this.formData = data;
  }

  getData() {
    return this.formData;
  }

  clear() {
    this.formData = {};
  }
}