import { Component, OnInit } from '@angular/core';
import { BookinghistoryService } from 'src/app/core/services/bookinghistory.service';
import { BookingHistory } from 'src/app/shared/models/bookingHistory';

@Component({
  selector: 'app-booking-history',
  templateUrl: './booking-history.component.html',
  styleUrls: ['./booking-history.component.css']
})
export class BookingHistoryComponent implements OnInit {

  itemModel: BookingHistory ={
    id: 0,
    email: "",
    fromPlaceId: 0,
    toPlaceId: 0,
    pickupAddress: "",
    cabTypeId: 0,
    contactNo: "",
    charge: 0,
    feedback: "",
  };

  items:BookingHistory[];
  constructor(private bookingHistoryService:BookinghistoryService) { }

  ngOnInit(): void {
    this.bookingHistoryService.getList().subscribe(

      m=>{this.items =m;}

    );
  }

  addNew(){
    this.bookingHistoryService.addItem(this.itemModel).subscribe()
  }

  deleteOne(){
    this.bookingHistoryService.deleteItem(this.itemModel.id).subscribe()
  }

  updateOne(){
    this.bookingHistoryService.updateItem(this.itemModel).subscribe()
  }


}
