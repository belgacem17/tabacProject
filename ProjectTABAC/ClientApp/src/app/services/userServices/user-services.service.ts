import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { User ,RouteInfo} from 'src/models/Entities';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class UserServicesService {
  private apiURL = "https://localhost:44317/api"
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };
  RouterUser:RouteInfo[];
  constructor(private httpClient: HttpClient) { }

  ConnectUser(email,password): Observable<User> {
    return this.httpClient.get<User>(this.apiURL + '/User/' + email+"/"+password)
      .pipe(
     
        catchError(this.errorHandler)
      );
  }
  getUsers(): Observable<User[]> {
    return this.httpClient.get<User[]>(this.apiURL + '/User').pipe(
        catchError(this.errorHandler)
      );
  }
 
  getUser(id): Observable<User> {
    return this.httpClient.get<User>(this.apiURL + '/User/' + id)
      .pipe(
        catchError(this.errorHandler)
      );
  }
 
  createUser(User): Observable<User[]> {
    return this.httpClient.post<User[]>(this.apiURL + '/User/', JSON.stringify(User), this.httpOptions)
      .pipe(
        catchError(this.errorHandler)
      );
  }
 
  updateUser(id, User): Observable<User> {
    return this.httpClient.put<User>(this.apiURL + '/User/' + id, JSON.stringify(User), this.httpOptions)
      .pipe(
        catchError(this.errorHandler)
      );
  }
 
  deleteUser(id) {
    return this.httpClient.delete<User>(this.apiURL + '/User/' + id, this.httpOptions)
      .pipe(
        catchError(this.errorHandler)
      );
  }
 
  errorHandler(error) {
    let errorMessage = '';
 
    if (error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
      if(error.status!=200)
      {
        alert("Vérifier les donnees")
      }
    }
    return throwError(errorMessage);
  }
  
}
 

