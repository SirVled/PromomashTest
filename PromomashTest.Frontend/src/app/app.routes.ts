import { Routes } from '@angular/router';
import { RegisterComponent } from './register/register.component';
import { LocationComponent } from './location/location.component';
import { canAccessStep } from './register/step.guard';

export const routes: Routes = [
  {
    path: 'register',
    component: RegisterComponent
  },
  {
    path: 'register/location',
    component: LocationComponent,
    canActivate: [canAccessStep(['register'])]
  },
  {
    path: '',
    redirectTo: 'register',
    pathMatch: 'full'
  },
  { path: '', redirectTo: 'register', pathMatch: 'full' }
];
