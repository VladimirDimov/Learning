import { Component } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ITripCreateModel } from "./trip-create.model";
import { ValidationService } from "../../common/validation-service";
import { TripsActions } from "../trips.actions";
import { NgRedux, select } from "ng2-redux/lib";
import { Observable } from "rxjs/Observable";

@Component({
    selector: 'cp-trips-create',
    templateUrl: './trips-create.component.html'
})

export class TripsCreateComponent {
    title: string = 'Create Trip Form';

    private form: FormGroup;

    constructor(
        private formBuilder: FormBuilder,
        private validation: ValidationService,
        private _tripsActions: TripsActions,
        private _ngRedux: NgRedux<any>
    ) { }

    ngOnInit() {
        this.form = this.formBuilder.group({
            'from': ['Sofia', Validators.compose([Validators.required])],
            'to': ['Pernik', Validators.required],
            'availableSeats': [4, Validators.compose([Validators.required])],
            'departureTime': [new Date('2017-06-25'), Validators.required]
        });

        this.validation.formGroup = this.form;
        console.log(this._ngRedux.getState());
    }

    @select(s => {
        return s.tripsReducer.isCreatingTrip
    }) isCreatingTrip: Observable<boolean>;

    onSubmit(model: ITripCreateModel) {
        this._tripsActions.create(model);
        console.log(this._ngRedux.getState());
    }
}