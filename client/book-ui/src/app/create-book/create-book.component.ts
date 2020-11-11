import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BooksService } from "../books.service";
import { Book } from "../book";

@Component({
  selector: 'app-create-book',
  templateUrl: './create-book.component.html',
  styleUrls: ['./create-book.component.css']
})
export class CreateBookComponent implements OnInit {
  book: Book = new Book();
  submitted = false;
  constructor(private bookService: BooksService,
    private router: Router) { }

  ngOnInit() {
    this.submitted = false;
    this.book = new Book();
    this.book.book = '';
    this.book.author = '';
  }

  newBook(): void {

  }

  save() {
    this.bookService
      .createBook(this.book).subscribe(data => {
        console.log(data)
        this.book = new Book();
        this.gotoList();
      },
        error => console.log(error));
  }

  onSubmit() {
    if (this.book.book.length == 0) {
      alert('Please enter book name.')
    }
    else if (this.book.author.length == 0) {
      alert('Please enter author name.')
    }
    else {
      this.submitted = true;
      this.save();
    }
  }

  gotoList() {
    this.router.navigate(['/books']);
  }

}
