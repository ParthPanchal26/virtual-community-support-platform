import { Routes } from '@angular/router';
import { StudentListComponent } from './student-list/student-list.component';
import { HomeComponentComponent } from './home-component/home-component.component';
import { AddStudentComponent } from './add-student/add-student.component';

export const routes: Routes = [
    {
        path: "",
        component: HomeComponentComponent
    }, 
    {
        path: 'students-list',
        component: StudentListComponent
    },
    {
        path: 'add-student',
        component: AddStudentComponent
    }
];
