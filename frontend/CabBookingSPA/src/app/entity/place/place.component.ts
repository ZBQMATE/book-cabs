import { Component, OnInit } from '@angular/core';
import { PlaceService } from 'src/app/core/services/place.service';
import { Place } from 'src/app/shared/models/place';

@Component({
  selector: 'app-place',
  templateUrl: './place.component.html',
  styleUrls: ['./place.component.css']
})
export class PlaceComponent implements OnInit {

  itemModel: Place ={
    id: 0,
    name:'',
  };

  items:Place[];
  constructor(private placeService:PlaceService) { }


  ngOnInit(): void {
    this.placeService.getList().subscribe(

      m=>{this.items =m;}

    );
  }


  addNew(){
    this.placeService.addItem(this.itemModel).subscribe()
  }

  deleteOne(){
    this.placeService.deleteItem(this.itemModel.id).subscribe()
  }

  updateOne(){
    this.placeService.updateItem(this.itemModel).subscribe()
  }


}
