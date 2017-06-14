import {FieldValidator } from "./field-validator";
export class Question<T>{
    value: T;
    key: string;
    label: string;
    placeholder: string;
    validators: FieldValidator[];
    controlType: string;
    relatedData: { key: string, value: string }[] = [];
}
