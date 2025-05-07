import { CanActivateFn, ActivatedRouteSnapshot, Router } from '@angular/router';
import { inject } from '@angular/core';
import { RegisterService } from './services/register.service';

export function canAccessStep(requiredSteps: string[]): CanActivateFn {
  return (route: ActivatedRouteSnapshot) => {
    const registerService = inject(RegisterService);
    const router = inject(Router);

    const currentStep = route.routeConfig?.path;

    if (currentStep && registerService.allowStep(currentStep, requiredSteps)) {
      return true;
    }

    router.navigate(['/register']);
    return false;
  };
}