export class Question<T>{
    value: T;
    key: string;
    label: string;
    placeholder: string;
    validations: string[];
    controlType: string;
    relatedData: { key: string, value: string }[] = [];

    constructor(options: {
        value?: T,
        key?: string,
        label?: string,
        placeholder?: string,
        validations?: string[],
        order?: number,
        controlType?: string,
        relatedData?: { key: string, value: string }[]
    } = {}) {
        this.value = options.value;
        this.key = options.key || "";
        this.label = options.label || "";
        this.placeholder = options.placeholder || "";
        this.validations = options.validations || [];
        this.controlType = options.controlType || "";
        this.relatedData = options.relatedData || [];
    }
}
