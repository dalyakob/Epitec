import { IProduct } from './product';
import {Injectable} from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

@Injectable({
    providedIn: 'root'    
})
export class ProductService{
    private productUrl = 'api/products/products.json';
    constructor(private http: HttpClient){}
    
    getProducts(): Observable<IProduct[]>{
        return this.http.get<IProduct[]>(this.productUrl).pipe(
            tap(data => console.log('All: ' + JSON.stringify(data))),
            catchError(this.handleError)
        );
    }
    handleError(err: HttpErrorResponse) {
        let errorMessage = '';
        if(err.error instanceof ErrorEvent){
            errorMessage = `An error occured: ${err.error.message}`;
        }
        else{
            errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
        }
        console.log(errorMessage);
        return throwError(errorMessage);
    } 
}