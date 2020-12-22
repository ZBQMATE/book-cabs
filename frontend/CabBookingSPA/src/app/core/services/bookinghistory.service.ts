import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { BookingHistory } from 'src/app/shared/models/bookingHistory';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class BookinghistoryService {

  constructor(private apiService: ApiService) { }

  getList(): Observable<BookingHistory[]>{
    return this.apiService.getAll('BookingHistory/list')
  }

  addItem(itemModel: BookingHistory): Observable<boolean> {
    return this.apiService.create('BookingHistory/add', itemModel).pipe(
      map((response) => {
        if (response) {
          console.log(response);
        
          return true;
        }
        console.log(response);
        return false;
      })
    );
  }

  deleteItem(itemModel: number): Observable<boolean> {
    return this.apiService.remove('BookingHistory/delete', itemModel).pipe(
      map((response) => {
        if (response) {
          console.log(response);
          
          return true;
        }
        console.log(response);
        return false;
      })
    );
  }

  updateItem(itemModel: BookingHistory): Observable<boolean> {
    return this.apiService.alter('BookingHistory/update', itemModel).pipe(
      map((response) => {
        if (response) {
          console.log(response);
          
          return true;
        }
        console.log(response);
        return false;
      })
    );
  }

  
}
