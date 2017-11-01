import { Component, OnInit } from '@angular/core';
import { QuizModel } from '../models/quiz.model';

@Component({
  selector: 'app-create-quiz',
  templateUrl: './create-quiz.component.html',
  styleUrls: ['./create-quiz.component.css'],

})
export class CreateQuizComponent implements OnInit {

  constructor() { }

  ngOnInit() {
    this.model = new QuizModel();
  }

  model: QuizModel;
}
