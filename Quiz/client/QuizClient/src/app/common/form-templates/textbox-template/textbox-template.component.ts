import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, ControlValueAccessor, FormControl } from '@angular/forms';

@Component({
  selector: 'textbox-template',
  templateUrl: './textbox-template.component.html',
  styleUrls: ['./textbox-template.component.css']
})
export class TextboxTemplateComponent implements OnInit {


  constructor() {
  }

  ngOnInit() {
    if (this.form == null) {
      this.isFormField = false;
    } else {
      this.control = this.form.controls[this.name] as FormControl;
    }
  }

  isFormField: boolean = true;

  @Input() form: FormGroup;
  @Input() name: string;
  @Input() label: string;
  @Input('type') iputType: string = 'text';
  @Input() s: number = 6;

  public control: FormControl;
}
