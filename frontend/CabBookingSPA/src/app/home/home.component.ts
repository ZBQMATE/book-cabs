import { Component, OnInit } from '@angular/core';
import { CarsService } from '../core/services/cars.service';
import { Cars } from '../shared/models/cars';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  cars:Cars[];
  constructor(private carsService:CarsService) { }

  ngOnInit(): void {
    this.carsService.getCars().subscribe(

      m=>{this.cars =m;}

    );
  }

}
