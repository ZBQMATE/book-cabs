import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Booking } from 'src/app/shared/models/booking';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class BookingService {

  constructor(private apiService: ApiService) { }
  getList(): Observable<Booking[]>{
    return this.apiService.getAll('Booking/list')
  }

  addItem(itemModel: Booking): Observable<boolean> {
    return this.apiService.create('Booking/add', itemModel).pipe(
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
    return this.apiService.remove('Booking/delete', itemModel).pipe(
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

  updateItem(itemModel: Booking): Observable<boolean> {
    return this.apiService.alter('Booking/update', itemModel).pipe(
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
