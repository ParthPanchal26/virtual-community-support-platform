import { NgFor, NgIf } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [FormsModule, NgIf, NgFor],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'sandbox';
  score = 5;
  name = "Parth Panchal";
  inputType = "number";
  bookname = "";
  books: any = [];
  count = 0;

  buttonClick() {
    this.count++
  }

  addBook() {
    if (this.bookname.trim()) {
      this.books.push(this.bookname);
      this.bookname = ''
      console.log(this.books);
    }
  }
}
