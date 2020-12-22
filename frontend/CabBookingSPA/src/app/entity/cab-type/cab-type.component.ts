import { Component, OnInit } from '@angular/core';
import { CabtypeService } from 'src/app/core/services/cabtype.service';
import { CabType } from 'src/app/shared/models/cabType';

@Component({
  selector: 'app-cab-type',
  templateUrl: './cab-type.component.html',
  styleUrls: ['./cab-type.component.css']
})
export class CabTypeComponent implements OnInit {

  itemModel: CabType ={
    id: 0,
    name:'',
  };

  items:CabType[];
  constructor(private cabService:CabtypeService) { }

  ngOnInit(): void {
    this.cabService.getList().subscribe(

      m=>{this.items =m;}

    );
  }


  addNew(){
    this.cabService.addItem(this.itemModel).subscribe()
  }

  deleteOne(){
    this.cabService.deleteItem(this.itemModel.id).subscribe()
  }

  updateOne(){
    this.cabService.updateItem(this.itemModel).subscribe()
  }

}
