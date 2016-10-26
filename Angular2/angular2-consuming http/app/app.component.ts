import { Component } from 'angular2/core';
import { AppService } from './app.service';
import { Person } from './person.interface';
import { Observable } from 'rxjs/Observable';

@Component({
    selector: 'my-app',
    templateUrl: '/app/app.html',
    directives: [],
    providers: [AppService],
})

export class AppComponent {
    constructor(private appService: AppService) {
        // Empty constructor
    }

    people;

    post;

    getPeople() {
        this.appService.getPeople()
            .subscribe(
            data => this.people = data,
            err => console.log(err));
    }

    addPerson(name: string) {
        this.appService.addPerson(name)
            .subscribe(
                res => this.post = res,
                err => console.log(err),
                () => console.log("Done!")
            );
    }
}