import { Benefit } from "./benefit";
import { Image } from "./../image";
import { Permutation } from "./permutation";

export class QuoteResultRenderingData {
    alternativeCallToAction: string;
    alternativeCallToActionText: string;
    benefits: Array<Benefit>;
    callToAction:string;
    callToActionText: string;
    editIcon: Image;
    introductionText:string;
    helpText: string;
    permutations: Array<Permutation>;
    personalisedGreetingText: string;
    primaryImage:Image;
    printText: string;
    quoteReferenceText: string;
    quoteValidText: string;
    referenceId: string;
    serviceOutagePage: string;
    tooltipText: string;
    tooltipButtonText: string;
    tooltipImage:string;
    marketingMessages: Array<string>;
    marketingMessageTimeOut: number;
    marketingLoadingSubtitle: string;
}
