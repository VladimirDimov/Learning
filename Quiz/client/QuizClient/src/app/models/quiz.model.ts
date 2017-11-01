import { QuestionModel } from "./question.model";

export class QuizModel {
    public title: string;
    public description: string;
    public questions: QuestionModel[]
}