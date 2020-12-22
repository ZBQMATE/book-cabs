import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CarsService } from '../core/services/cars.service';
import { CarBookings } from '../shared/models/carBookings';

@Component({
  selector: 'app-cars',
  templateUrl: './cars.component.html',
  styleUrls: ['./cars.component.css']
})
export class CarsComponent implements OnInit {

  carId: number;
  carBookings: CarBookings[];

  constructor( private route: ActivatedRoute,
    private carsService: CarsService) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(
      p=>{
        this.carId= +p.get('id');
        this.carsService.getCarBookings(this.carId).subscribe(
          m=>{
            this.carBookings=m;
            console.log(this.carBookings);
          }
        )
      }
    )
  }

}
