import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CarsComponent } from './cars/cars.component';
import { BookingHistoryComponent } from './entity/booking-history/booking-history.component';
import { BookingComponent } from './entity/booking/booking.component';
import { CabTypeComponent } from './entity/cab-type/cab-type.component';
import { PlaceComponent } from './entity/place/place.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [

  {
    path:"",
    component:HomeComponent,
  },
  {
    path: 'Cars/:id',
    component: CarsComponent,
  },
  {
    path:"CabType",
    component:CabTypeComponent,
  },
  {
    path:"Place",
    component:PlaceComponent,
  },
  {
    path:"Booking",
    component:BookingComponent,
  },
  {
    path:"BookingHistory",
    component:BookingHistoryComponent,
  },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
