import {Injectable} from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Rx';

import {Product} from "./models/product";
import {ProductsMock} from "../mocks/products.mock";

@Injectable()
export class ProductService {

    constructor(private http: Http){}

    getProducts(): Observable<Product[]> {
        return this.http.get('/api/Products')
            .map((response: Response) => response.json() as Product[]);
    }
}