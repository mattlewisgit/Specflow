import {Question } from "./question";

export class QuestionGroup {
    label: string;
    validationMessage: string;
    questions: Question<any>[];

    constructor(options: {
        label?: string,
        validationMessage?: string,
        questions?: Question<any>[]} = {})
    {
        this.label = options.label || "";
        this.validationMessage = options.validationMessage;
        this.questions = options.questions;
    }
}

