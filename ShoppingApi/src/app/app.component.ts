import { Component , OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { createWiresService } from 'selenium-webdriver/firefox';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'shopping2';
  results = [];
  products  = '';
  cart = []
addToCart = function (item){
  this.cart.push(item);

}
  constructor(private http: HttpClient) {
  }
  ngOnInit() : void {

    interface Product {
      name:string;
      category:string;
      price:number;
    }
    this.http.get<Product>('/api/Products').subscribe(data => {
      for(let i in data)   this.results.push(data[i]);
    //this.results = data ;
    });
  }

}
