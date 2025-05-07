import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class RegisterService {
  private completedSteps = new Set<string>();

  completeStep(step: string) {
    this.completedSteps.add(step);
  }

  isStepCompleted(step: string): boolean {
    return this.completedSteps.has(step);
  }

  allowStep(step: string, dependencies: string[]): boolean {
    return dependencies.every(dep => this.completedSteps.has(dep));
  }
}