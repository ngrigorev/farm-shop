import { Component, OnInit } from '@angular/core';
import { ICategory } from '../../models/category';
import { StorageService } from '../../services/services';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent  implements OnInit {
  categoryList: ICategory[] = [];

  constructor(private _storageService: StorageService) { }

  ngOnInit() {
    this._storageService.GetCategoryList()
      .subscribe(response => {
        if (response.isSuccess) {
          this.categoryList = response.data;
        }
    });
  }
}
