import { Component } from "@angular/core";
import { select, NgRedux } from "ng2-redux/lib";
import { Observable } from "rxjs/Observable";
import { IStatsModel } from "./stats.model";
import { StatsActions } from "./stats.actions";

@Component({
    selector: 'cp-stats',
    templateUrl: './stats.component.html'
})

export class StatsComponent {
    title: string = 'Stats Component';

    constructor(private actions: StatsActions) {
        actions.get();
    }

    @select(s => {
        return <IStatsModel>s.statsReducer;
    }) statsReducer: Observable<IStatsModel>;

    stats: IStatsModel;
}