import {
  HttpInterceptorFn,
} from '@angular/common/http';
import { AuthService } from '../services/auth.service';
import { inject } from '@angular/core';

export const JwtInterceptor : HttpInterceptorFn = (req, next) => {

  const authService = inject(AuthService);
  if(authService.currentUserValue.token==null) {
    return next(req);
  }
  
  const newReq = req.clone({
    setHeaders: {
      Authorization: `Bearer ${authService.currentUserValue.token}`,
    }
  })
  return next(newReq);
}
