import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { BehaviorSubject, map, Observable, of } from 'rxjs';
import { User } from '../models/user';
import { HttpClient } from '@angular/common/http';
import * as CryptoJS from 'crypto-js';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrk = environment.apiUrl;
  userInformation : any;

  private currentUserSubject: BehaviorSubject<User>;
  public currentUser: Observable<User>;
  
  constructor(private http: HttpClient) { 
    const currentUserString = localStorage.getItem('encryptedUser');
    const bytes = currentUserString ? CryptoJS.AES.decrypt(currentUserString, '3X8e%7Wm3n03') : null;
    const currentUserJSON = bytes ? JSON.parse(bytes.toString(CryptoJS.enc.Utf8)) : null;
    this.currentUserSubject = new BehaviorSubject<User>(currentUserJSON);
    this.currentUser = this.currentUserSubject.asObservable();
  }

  public get currentUserValue(): User {
    return this.currentUserSubject.value;
  }

  login(email: string, password: string, remember: boolean) {
    return this.http
      .post<any>(`${environment.securityUrl}/Account/login`, {
        email,
        password,
        remember
      })
      .pipe(
        map((user) => {
          // store user details and jwt token in local storage to keep user logged in between page refreshes
          
          const encryptedUser = CryptoJS.AES.encrypt(JSON.stringify(user), '3X8e%7Wm3n03').toString();
          localStorage.setItem('encryptedUser', encryptedUser);
          this.currentUserSubject.next(user);
          return user;
        })
      );
  }

  logout() {
    localStorage.removeItem('encryptedUser');
    this.currentUserSubject.next(null!);
    this.userInformation = null;
    return of({ success: false });
  }

  verifyToken(token:string) : Observable<any> {
    let payload = {
       "userName":"string",
      'token':token
    }
    return this.http.post<any>(`${environment.securityUrl}/Account/verifyToken`,payload)
  }
}