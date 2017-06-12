import {Question } from "./question";

export class QuestionGroup {
    label: string;
    helpText: string;
    validationMessage: string;
    questions: Question<any>[];

    constructor(options: {
        label?: string,
        helpText?: string,
        validationMessage?: string,
        questions?: Question<any>[]} = {})
    {
        this.label = options.label || "";
        this.helpText = options.helpText || "";
        this.validationMessage = options.validationMessage;
        this.questions = options.questions;
    }
}

