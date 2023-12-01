import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { CANDIDATE_TOKEN } from 'src/app/service/constant';
import { getItem, signOut } from 'src/app/service/localstorage';

export const authGuard: CanActivateFn = (route, state) => {
  const router = inject(Router)
  const token = getItem(CANDIDATE_TOKEN)
  if (token !== null) {
    return true
  }
  signOut()
  router.navigate(['/candidate/sign-in'])
  return false;
};
