import { ProductService } from './product.service';
import { Component, OnInit } from '@angular/core';
import { IProduct } from './product';

@Component({
    templateUrl: './product-list.component.html',
    styleUrls: ['./product-list.component.css']
})

export class ProductListComponent implements OnInit {
    pageTitle = 'Product List!';
    imageWidth: number = 50;
    imageMargin = 2;
    showImage = true;
    filteredProducts: IProduct[];
    products: IProduct[] = [];
    errorMessage: string;
    
    _listFilter: string;
    get listFilter(): string {
        return this._listFilter;
    }
    set listFilter(value: string){
        this._listFilter = value;
        this.filteredProducts = this.listFilter ? this.performFilter(this.listFilter) : this.products;
    }
    
    constructor(private _productService: ProductService){
    }

    ngOnInit() : void {
        this._productService.getProducts().subscribe({
            next: products => {
                this.products = products;
                this.filteredProducts = this.products;
            },
            error: err => this.errorMessage = err
        });
    }

    onNotify(message: string): void {}
    
    toggleImage(): void {
        this.showImage = !this.showImage
    }
    
    
    performFilter(filterBy: string): IProduct[]{
        filterBy = filterBy.toLocaleLowerCase();
        return this.products.filter((product: IProduct) => 
                product.productName.toLocaleLowerCase().indexOf(filterBy) !== -1);
    }
    
    onRatingClicked(message: string) : void {
        this.pageTitle = 'Product List: ' + message;
    }
}