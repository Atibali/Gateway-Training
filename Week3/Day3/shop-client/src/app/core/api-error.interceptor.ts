import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
import { catchError, throwError } from 'rxjs';

// Centralize diagnostics without swallowing errors; pages still show user-friendly messages.
export const apiErrorInterceptor: HttpInterceptorFn = (request, next) =>
  next(request).pipe(
    catchError((error: unknown) => {
      if (error instanceof HttpErrorResponse) {
        console.error('HTTP request failed', {
          url: request.url,
          status: error.status,
          message: error.message,
        });
      }

      return throwError(() => error);
    }),
  );
