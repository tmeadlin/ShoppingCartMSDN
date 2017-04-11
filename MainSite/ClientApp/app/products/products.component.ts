import { Component, OnInit } from '@angular/core';
import { Observable } from "rxjs/Rx";

import {ProductService} from "./product.service";
import { CartService } from "../shared/services/cart.service";
import { InternalNotificationService } from "../shared/services/internal-notification.service";

import { Product } from "./models/product";
import { InternalMessage, InternalNotificationType } from "../shared/models/internal-notification";

@Component({
    template: `
        <h3>Add Products To Your Cart</h3>
        
        <div class="row">
            <div class="col-md-4 product-wrapper" *ngFor="let product of products | async">
                <product-info [productInfo]="product"></product-info>
            </div>
        </div>
    `,
    styles: ['.product-wrapper { padding-top: 10px; padding-bottom: 10px; }']
})
export class ProductsComponent implements OnInit{
    products: Observable<Product[]>;

    constructor(private productService: ProductService, private cartService: CartService, private internalNotificationService: InternalNotificationService){}

    ngOnInit(){
        this.products = this.productService.getProducts();
    }
}