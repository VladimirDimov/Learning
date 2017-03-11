import { Injectable } from '@angular/core';

import { Hero } from './hero';
import { HEROES } from './mocks';

@Injectable()
export class HeroService {
    getHeroes(): Promise<Hero[]> {
        return new Promise(resolve => {
            setTimeout(() => resolve(HEROES), 1500);
        });
    }
}