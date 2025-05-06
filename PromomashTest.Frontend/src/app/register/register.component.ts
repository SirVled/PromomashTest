import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { Router } from '@angular/router';
import { trigger, transition, style, animate } from '@angular/animations';
import { RegisterService } from './register.service';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule, CommonModule, RouterOutlet],
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
  animations: [
    trigger('slideIn', [
      transition(':enter', [
        style({ transform: 'translateX(-100%)', opacity: 0 }),
        animate('400ms ease-out', style({ transform: 'translateX(0)', opacity: 1 }))
      ])
    ])
    ]
})
export class RegisterComponent {
  formData = {
    email: '',
    password: '',
    confirmPassword: '',
    agreed: false
  };

  constructor(private router: Router, private registerService: RegisterService) {}
  passwordsDoNotMatch = false;
  
  private confirmed = false;

  confirmRegistration() {
    this.registerService.completeStep('register');
    this.router.navigate(['/location']);
  }

  isConfirmed(): boolean {
    return this.confirmed;
  }
  onSubmit() {
    this.passwordsDoNotMatch = this.formData.password !== this.formData.confirmPassword;

    if (!this.passwordsDoNotMatch) {
      this.confirmRegistration();
      this.router.navigate(['register', 'location']);
    }
  }
}