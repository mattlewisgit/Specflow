import {FieldValidator } from "./field-validator";
export class Question<T>{
    value: T;
    basedOnKey: string;
    basedOnValue: number;
    key: string;
    label: string;
    placeholder: string;
    validators: FieldValidator[];
    onValueChange : any;
    controlType: string;
    isVisible: boolean;
    relatedData: { key: string, value: string }[] = [];
}
