import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Place } from 'src/app/shared/models/place';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class PlaceService {

  constructor(private apiService: ApiService) { }

  getList(): Observable<Place[]>{
    return this.apiService.getAll('Place/list')
  }

  addItem(itemModel: Place): Observable<boolean> {
    return this.apiService.create('Place/add', itemModel).pipe(
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
    return this.apiService.remove('Place/delete', itemModel).pipe(
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

  updateItem(itemModel: Place): Observable<boolean> {
    return this.apiService.alter('Place/update', itemModel).pipe(
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
