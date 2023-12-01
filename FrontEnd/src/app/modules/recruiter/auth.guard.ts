import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { RECRUITER_TOKEN } from 'src/app/service/constant';
import { getItem } from 'src/app/service/localstorage';

export const authGuard: CanActivateFn = (route, state) => {
  const router = inject(Router)
  const token = getItem(RECRUITER_TOKEN)
  if (token !== null) {
    return true
  }
  router.navigate(['/recruiter/sign-in'])
  return false;
};
