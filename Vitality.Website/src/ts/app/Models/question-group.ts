import {Question } from "./question";

export class QuestionGroup {
    key: string;
    label: string;
    basedOnKey: string;
    basedOnValues: string[];
    helpText: string;
    validationMessage: string;
    questions: Question<any>[];
    isVisible: boolean;
    isCompleted: boolean;
}
