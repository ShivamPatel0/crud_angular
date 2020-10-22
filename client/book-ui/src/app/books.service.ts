import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { Book } from '../app/book';
import { catchError, retry, tap } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class BooksService {
  private baseUrl = 'https://localhost:44312/api/books';
  book: Book[] = [];
  constructor(private http: HttpClient) { }

  getBook(id: number): Observable<any> {
    return this.http.get(`${this.baseUrl}/GetBook/${id}`);
  }

  createBook(employee: Object): Observable<Object> {
    return this.http.post(`${this.baseUrl}/AddBooks`, employee);
  }

  updateBook(id: number, value: any): Observable<Object> {
    return this.http.post(`${this.baseUrl}/UpdateBooks`, value);
  }

  deleteBook(id: number): Observable<any> {
    return this.http.post(`${this.baseUrl}/DeleteBooks/${id}`, { responseType: 'text' });
  }

  getBookList(): Observable<any> {
    return this.http.get(`${this.baseUrl}/GetBooks`);
  }
}
