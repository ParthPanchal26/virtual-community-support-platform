import { NgFor, NgIf } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'app-student-list',
  standalone: true,
  imports: [NgFor, NgIf],
  templateUrl: './student-list.component.html',
  styleUrl: './student-list.component.css'
})
export class StudentListComponent {
  students:any = localStorage.getItem('StudentDetails');
  studentDetails:any = JSON.parse(this.students);

  handleDelete(i:any) {

    this.studentDetails[i].name = '';
    this.studentDetails[i].sem_class = '';
    this.studentDetails[i].er_no = '';

    localStorage.setItem("StudentDetails", JSON.stringify(this.studentDetails));
     
  }
}