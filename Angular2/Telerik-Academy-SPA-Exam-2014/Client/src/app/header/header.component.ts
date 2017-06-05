import { Component } from '@angular/core';

@Component({
    moduleId: module.id,
    selector: 'cp-header',
    templateUrl: 'header.component.html'
})

export class HeaderComponent {
    pageTitle: string = 'Header';
}