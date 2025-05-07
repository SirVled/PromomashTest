import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { trigger, transition, style, animate } from '@angular/animations';
import { Router } from '@angular/router';
import { Country, CountryService } from './country.service';
import { RegistrationDataService } from '../register/services/registration.data.service';

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

  constructor(private service: CountryService, private dataService: RegistrationDataService) {}

  ngOnInit(): void {
    this.service.getCountries().subscribe((res) => (this.countries = res));
  }
  
  private router = inject(Router);
  selectedCountry: number = -1;
  selectedProvince: number = -1;

  get provinces() {
    return this.countries.find(x => x.id == this.selectedCountry)?.provinces || [];
  }

  goBack(): void {
    this.router.navigate(['/register']);
  }

  onSave() {
    if (!this.selectedCountry || !this.selectedProvince) return;
    console.log('Saved:', this.selectedCountry, this.selectedProvince);
    
    let formData = this.dataService.getData();
    formData.countryId = this.selectedCountry;
    formData.provinceId = this.selectedProvince;

    console.log(formData);
    alert('Saved Data!');
  }
}