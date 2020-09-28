import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ICategory } from '../models/category';
import { IMedicament } from '../models/medicament';
import { IResponse } from '../models/response';
import { StorageService } from './services';

@Injectable({
    providedIn: 'root'
})
export class RemoteStorageService extends StorageService {
    baseURL = 'http://farm-shop.public.keenetic.pro/api/';

    constructor(private _http: HttpClient) {
        super();
    }

    private httpGet<T>(url: string, page = 0): Observable<T> {
        const params = new HttpParams()
        .set('page', page.toString());

        return this._http.get(`${this.baseURL}${url}`, { params }) as Observable<T>;
    }

    GetCategoryList(page?: number): Observable<IResponse<ICategory[]>> {
        return this.httpGet<IResponse<ICategory[]>>('category', page);
    }

    GetMedicamentList(idCategory: string, page?: number): Observable<IResponse<IMedicament[]>> {
        return this.httpGet<IResponse<IMedicament[]>>(`/category/${idCategory}/medicament`, page);
    }
}
