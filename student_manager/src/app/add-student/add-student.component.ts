import { NgIf } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-add-student',
  standalone: true,
  imports: [FormsModule, NgIf, RouterModule],
  templateUrl: './add-student.component.html',
  styleUrl: './add-student.component.css'
})
export class AddStudentComponent {

  constructor(private router: Router) {}

  studentDetails = {
    name: '',
    sem_class: '',
    er_no: ''
  }

  isSubmitted = false;

  handleSubmit() {
    this.isSubmitted = true;

    const students = JSON.parse(localStorage.getItem('StudentDetails') || '[]');
    students.push(this.studentDetails);
    localStorage.setItem('StudentDetails', JSON.stringify(students));

    this.router.navigate(['/students-list'])

  }
}
