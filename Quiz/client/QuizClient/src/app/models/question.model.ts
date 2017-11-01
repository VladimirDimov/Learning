import { OptionModel } from "./option.model";

export class QuestionModel {
    public text: string;
    public type: QuestionTypes;
    public options: OptionModel;
}