import { Component, Input, OnInit } from '@angular/core';
import { ICategory } from '../../models/category';
import { IMedicament } from '../../models/medicament';
import { StorageService } from '../../services/services';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.scss']
})
export class CategoryComponent  implements OnInit {
  @Input() category: ICategory;
  medicamentList: IMedicament[] = [];
  panelOpenState = false;
  visible = true;
  page = 0;

  constructor(private _storageService: StorageService) { }

  ngOnInit() {
    this.load(this.page);
  }

  prev() {
    if (this.page > 0) {
      this.page--;
    }

    this.load(this.page);
  }

  next() {
    if (this.medicamentList?.length > 0) {
      this.page++;
      this.load(this.page);
    }
  }

  load(page: number) {
    this._storageService.GetMedicamentList(this.category.id, page)
      .subscribe(response => {
        if (response.isSuccess) {
          this.medicamentList = response.data;
        }

        this.visible = page === 0
                      && response.isSuccess
                      && this.medicamentList?.length > 0;
      });
  }
}
