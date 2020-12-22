import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CarBookings } from 'src/app/shared/models/carBookings';
import { Cars } from 'src/app/shared/models/cars';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class CarsService {

  constructor(private apiService: ApiService) { }

  getCars(): Observable<Cars[]>{
    return this.apiService.getAll('CabType/list')
   }

  getCarBookings(id:number):Observable<CarBookings[]>{

    return this.apiService.getAll('Booking/CabBooking',id)

  }
  
}
