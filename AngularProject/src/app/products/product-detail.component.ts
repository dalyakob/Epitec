import { ProductService } from './product.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IProduct } from './product';
import { ThrowStmt } from '@angular/compiler';

@Component({
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {
  pageTitle: string = 'Product Detail';
  product: IProduct;
  imageWidth = 300;
  imageMargin = 20;
  errorMessage: string;

  constructor(private route: ActivatedRoute,
              private router: Router,
              private service: ProductService) { }

  ngOnInit(): void {
    let id = +this.route.snapshot.paramMap.get('id');
    this.service.getProducts().subscribe(
       product => this.product = (product.filter(x => x.productId == id))[0]
    );
  }
  onBack(): void {
    this.router.navigate(['/products']);
  }
}
