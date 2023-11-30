import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { ADMIN_TOKEN } from 'src/app/service/constant';
import { getItem } from 'src/app/service/localstorage';

export const authGuard: CanActivateFn = (route, state) => {
  // const currentPage = route.url[0].path;
  const router = inject(Router)

  const token = getItem(ADMIN_TOKEN)

  if (token !== null) {
    return true
  }
  router.navigate(['/admin/sign-in'])
  // alert('Access denied')
  return false;
};
