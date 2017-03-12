import { Component, OnInit } from '@angular/core';
import { HeroService } from './hero.service';
import { Hero } from './hero';

@Component({
    selector: 'my-dashboard',
    styleUrls: ['./app.component.css'],
    templateUrl: './dashboard.component.html',
    providers: [HeroService],
})

export class DashboardComponent {
    constructor(private heroService: HeroService) {
    }

    ngOnInit(): void {
        this.heroService.getHeroes()
            .then(heroes => this.heroes = heroes.slice(1, 5));
    }

    heroes: Hero[];
}