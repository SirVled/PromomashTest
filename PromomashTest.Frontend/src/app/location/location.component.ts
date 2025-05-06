import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { trigger, transition, style, animate } from '@angular/animations';
import { Router } from '@angular/router';

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
export class LocationComponent {
  countries = ['USA', 'Canada', 'Germany'];
  provincesMap: { [key: string]: string[] } = {
    USA: ['California', 'Texas', 'Florida'],
    Canada: ['Ontario', 'Quebec', 'Alberta'],
    Germany: ['Bavaria', 'Berlin', 'Hesse']
  };

  private router = inject(Router);
  selectedCountry: string = '';
  selectedProvince: string = '';

  get provinces() {
    return this.provincesMap[this.selectedCountry] || [];
  }

  goBack(): void {
    this.router.navigate(['/register']);
  }

  onSave() {
    if (!this.selectedCountry || !this.selectedProvince) return;
    console.log('Saved:', this.selectedCountry, this.selectedProvince);
  }
}