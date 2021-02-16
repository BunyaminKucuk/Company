import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from '../../../environments/environment.prod';
//import { PaginatedResult, Pagination } from '../_paginationModels/pagination';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  baseURL = environment.baseUrl;

  constructor(private http: HttpClient) { }



  // CREATE
  post<T>(extension: string, model: T | any): Observable<T | T[]> {
    return this.http.post<T | T[]>(`${this.baseURL}/${extension}`, model);
  }

  getall<T>(extension: string | any): Observable<T | T[]> {
    return this.http.get<T | T[]>(`${this.baseURL}/${extension}`);
  }


  // READ
  //get<T>(extension: string | any, pagination: Pagination,): Observable<PaginatedResult<T[]>> {
  //  let params = new HttpParams();
  //  if (pagination.currentPage != null && pagination.itemsPerPage != null) {
  //    params = params.append('pageNumber', pagination.currentPage.toString());
  //    params = params.append('pageSize', pagination.itemsPerPage.toString())
  //  }
  //  const paginatedResult: PaginatedResult<T[]> = new PaginatedResult<T[]>();
  //  return this.http.get<T[]>(`${this.baseURL}/${extension}`, { observe: 'response', params }).pipe(
  //    map(response => {

  //      paginatedResult.result = response.body
  //      if (response.headers.get('Pagination') != null) {
  //        paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'))
  //      }
  //      return paginatedResult;
  //    })
  //  );
  //}

  getbyId<T>(extension: string | any,id): Observable<T | T[]> {
    return this.http.get<T | T[]>(`${this.baseURL}/${extension}/${id}`);
  }

  // UPDATE
  update<T>(extension: string, model: T | any): Observable<T | T[]> {
    return this.http.put<T | T[]>(`${this.baseURL}/${extension}`, model);
  }


   // DELETE 
   delete<T>(extension: string| any ,id): Observable<T | T[]> {
     return this.http.delete<T | T[]>(`${this.baseURL}/${extension}/${id}`);
   }

   //// DELETE 
  //delete<T>(model: T | any, objToDelete): Observable<T | T[]> {
  //  return this.http.delete<T | T[]>(`${this.baseURL}/${model.tableName}/${objToDelete.id}`);
  //}
}
