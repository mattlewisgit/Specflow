import {Question } from "./question";

export class QuestionGroup {
    label: string;
    helpText: string;
    validationMessage: string;
    questions: Question<any>[];
}
