import { Component, OnInit } from '@angular/core';
import { BookingService } from 'src/app/core/services/booking.service';
import { Booking } from 'src/app/shared/models/booking';

@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html',
  styleUrls: ['./booking.component.css']
})
export class BookingComponent implements OnInit {

  itemModel: Booking ={
    id: 0,
    email: "",
    fromPlaceId: 0,
    toPlaceId: 0,
    pickupAddress: "",
    cabTypeId: 0,
    contactNo: "",
  };

  items:Booking[];
  constructor(private bookingService:BookingService) { }

  ngOnInit(): void {
    this.bookingService.getList().subscribe(

      m=>{this.items =m;}

    );
  }

  addNew(){
    this.bookingService.addItem(this.itemModel).subscribe()
  }

  deleteOne(){
    this.bookingService.deleteItem(this.itemModel.id).subscribe()
  }

  updateOne(){
    this.bookingService.updateItem(this.itemModel).subscribe()
  }

}
