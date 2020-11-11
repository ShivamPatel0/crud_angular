import { Component, OnInit } from '@angular/core';
import { BookDetailsComponent } from '../book-details/book-details.component';
import { Observable } from "rxjs";
import { BooksService } from "../books.service";
import { Book } from "../book";
import { Router } from '@angular/router';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css']
})
export class BookListComponent implements OnInit {
  books: Observable<Book[]>;
  constructor(private bookService: BooksService,
    private router: Router) { }

  ngOnInit() {
    this.reloadData();
  }

  reloadData() {
    this.books = this.bookService.getBookList();
    console.log(this.books);
  }

  deleteBook(id: number) {
    if(window.confirm('Are you sure you want to delete this record?')){
      this.bookService.deleteBook(id)
      .subscribe(
        data => {
          console.log(data);
          this.reloadData();
        },
        error => console.log(error));
    }    
  }

  bookDetails(id: number) {
    this.router.navigate(['details', id]);
  }

  bookUpdate(id: number) {
    this.router.navigate(['update', id]);
  }

}
