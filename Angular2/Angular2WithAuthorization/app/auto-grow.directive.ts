import { Directive, ElementRef, Renderer } from 'angular2/core'

@Directive({
    selector: '[autoGrow]',
    host: {
        '(focus)': 'onFocus()',
        '(blur)': 'onBlur()'
    }
})

export class AutoGrowDirective {
    constructor(private el: ElementRef, private renderer: Renderer) {
    }

    onFocus() {
        debugger;
        this.renderer.setElementStyle(this.el, 'background-color', 'red');
    }

    onBlur() {
        debugger;
        this.renderer.setElementStyle(this.el, 'width', '120');
    }
}