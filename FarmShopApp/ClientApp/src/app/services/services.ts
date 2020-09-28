import { Observable } from 'rxjs';
import { ICategory } from '../models/category';
import { IMedicament } from '../models/medicament';
import { IResponse } from '../models/response';

export abstract class StorageService {
    abstract GetCategoryList(page?: number): Observable<IResponse<ICategory[]>>;
    abstract GetMedicamentList(idCategory: string, page?: number): Observable<IResponse<IMedicament[]>>;
}
