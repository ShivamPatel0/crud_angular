import { Component, OnInit, Input } from '@angular/core';
import { Book } from '../book';
import { BooksService } from '../books.service';
import { BookListComponent } from '../book-list/book-list.component';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-book-details',
  templateUrl: './book-details.component.html',
  styleUrls: ['./book-details.component.css']
})
export class BookDetailsComponent implements OnInit {
  id: number;
  book: Book;

  constructor(private route: ActivatedRoute, private router: Router,
    private bookService: BooksService) { }

  ngOnInit() {
    this.book = new Book();

    this.id = this.route.snapshot.params['id'];

    this.bookService.getBook(this.id)
      .subscribe(data => {
        console.log(data)
        this.book = data;
      }, error => console.log(error));
  }

  list() {
    this.router.navigate(['books']);
  }

}
