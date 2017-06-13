import {Question } from "./question";

export class QuestionGroup {
    label: string;
    conditionToHide: string;
    helpText: string;
    validationMessage: string;
    questions: Question<any>[];
}
