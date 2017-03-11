import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Hero } from './hero';
import { HeroDetailComponent } from './hero-detail.component';
import { HeroService } from './hero.service';

@Component({
  selector: 'my-heroes',
  templateUrl: './heroes.component.html',
  styleUrls: ['./app.component.css'],
  providers: [HeroService]
})

export class HeroesComponent {
  constructor(private heroService: HeroService) { }

  ngOnInit() {
    this.heroService.getHeroes()
      .then(h => this.heroes = h);
  }

  title = 'Tour of Heroes!';

  hero: Hero = {
    id: 1,
    name: 'Windstorm'
  };

  heroes: Hero[];

  selectedHero: Hero;

  public onSelect(hero: Hero) {
    this.selectedHero = hero;
  }
}
