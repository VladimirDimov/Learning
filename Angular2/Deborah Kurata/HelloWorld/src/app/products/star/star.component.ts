import { Component, OnChanges, Input, Output, EventEmitter } from '@angular/core'

@Component({
    moduleId: module.id,
    selector: 'ai-star',
    templateUrl: 'star.component.html',
    styleUrls: ['star.component.css']
})

export class StarComponent implements OnChanges {

    @Input()
    rating: number = 0;

    @Output()
    ratingClicked: EventEmitter<string> = new EventEmitter<string>();

    starWidth: number;

    starContainerWidth: number = 230;

    ngOnChanges(): void {
        this.starWidth = this.rating * this.starContainerWidth / 5;
    }

    onRatingClicked() {
        this.ratingClicked.emit('rating was clicked!' + this.rating);
    }
}