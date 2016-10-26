import { Component } from 'angular2/core'
import { CourseService } from './course.Service'
import { AutoGrowDirective } from './auto-grow.directive'

@Component({
    selector: 'courses',
    templateUrl: '/templates/courses.html',
    providers: [CourseService],
    directives: [AutoGrowDirective]
})
export class CoursesComponent {
    constructor(courseService: CourseService) {
        this.courses = courseService.getCourses();
    }
    
    title = "The title of courses page";
    courses;
}