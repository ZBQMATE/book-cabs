import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { CabType } from 'src/app/shared/models/cabType';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class CabtypeService {

  constructor(private apiService: ApiService) { }
  getList(): Observable<CabType[]>{
    return this.apiService.getAll('CabType/list')
  }

  addItem(itemModel: CabType): Observable<boolean> {
    return this.apiService.create('CabType/add', itemModel).pipe(
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
    return this.apiService.remove('CabType/delete', itemModel).pipe(
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

  updateItem(itemModel: CabType): Observable<boolean> {
    return this.apiService.alter('CabType/update', itemModel).pipe(
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
