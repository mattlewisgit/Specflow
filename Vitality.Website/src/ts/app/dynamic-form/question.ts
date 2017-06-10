export class Question<T>{
    value: T;
    key: string;
    label: string;
    validations: string[];
    controlType: string;
    choices: { key: string, value: string }[] = [];

    constructor(options: {
        value?: T,
        key?: string,
        label?: string,
        validations?: string[],
        order?: number,
        controlType?: string,
        choices?: { key: string, value: string }[]
    } = {}) {
        this.value = options.value;
        this.key = options.key || "";
        this.label = options.label || "";
        this.validations = options.validations || [];
        this.controlType = options.controlType || "";
        this.choices = options.choices || [];
    }
}
