import { Benefit } from "./benefit";
import { Image } from "./../image";
import { Permutation } from "./permutation";

export class QuoteResultRenderingData {
    benefits: Array<Benefit>;
    callToActionText: string;
    editIcon:Image;
    helpText: string;
    permutations: Array<Permutation>;
    printText: string;
    quoteReferenceText: string;
    quoteValidText: string;
    referenceId: string;
    serviceOutagePage: string;
    tooltipText: string;
    tooltipButtonText: string;
    marketingMessages: Array<string>;
    marketingMessageTimeOut: number;
    marketingLoadingSubtitle: string;
}
