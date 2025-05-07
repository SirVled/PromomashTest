import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { trigger, transition, style, animate } from '@angular/animations';
import { Router } from '@angular/router';
import { Country, CountryService, Province } from './country.service';
import { RegistrationDataService } from '../register/services/registration.data.service';
import { UserService } from './services/user.service';

@Component({
  selector: 'app-location',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './location.component.html',
  styleUrls: ['./location.component.css', '../register/register.component.css'],
  animations: [
  trigger('slideIn', [
    transition(':enter', [
      style({ transform: 'translateX(100%)', opacity: 0 }),
      animate('400ms ease-out', style({ transform: 'translateX(0)', opacity: 1 }))
    ])
  ])
  ]
})
export class LocationComponent implements OnInit  {
  countries: Country[] = [];
  provinces: Province[] = [];
  constructor(
    private service: CountryService,
    private dataService: RegistrationDataService,
    private userService: UserService) {}

  ngOnInit(): void {
    this.service.getCountries().subscribe((res) => (this.countries = res));
  }
  
  private router = inject(Router);
  selectedCountry: number = -1;
  selectedProvince: number = -1;



  goBack(): void {
    this.router.navigate(['/register']);
  }

  onCountryChange(): void {
    this.service.getProvinces(this.selectedCountry).subscribe(res => { this.provinces = res; });;
  }

  onSave() {
    if (!this.selectedCountry || !this.selectedProvince) return;

    let formData = this.dataService.getData();
    formData.countryId = this.selectedCountry;
    formData.provinceId = this.selectedProvince;

    this.userService.registerUser({
      email: formData.email,
      password: formData.password,
      countryId: formData.countryId,
      provinceId: formData.provinceId
    }).subscribe({
      next: (x) => { 
        console.log(x);
          alert('User registered');
          this.dataService.setData({});
          this.goBack();
        },
      error: err => {console.error('Registration failed', err); alert(err.error)}
    });
  }
}