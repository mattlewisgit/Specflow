import { BenefitOption } from "./benefit-option";
import { Image } from "./../image";

export class Benefit {
    benefitOptions: Array<BenefitOption>;
    code: string;
    editTitle: string;
    editTooltip:string;
    helpTextVisible:boolean;
    icon: Image;
    id: string;
    isEditable: boolean;
    isEditing: boolean;
    isModule: boolean;
    selectedOption: string;
    title: string;
    tooltip: string;
}
