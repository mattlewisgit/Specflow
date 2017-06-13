import {Question } from "./question";

export class QuestionGroup {
    label: string;
    basedOnKey: string;
    basedOnValues: string[];
    helpText: string;
    validationMessage: string;
    questions: Question<any>[];
}
