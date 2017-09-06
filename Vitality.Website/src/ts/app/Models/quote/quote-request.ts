import { PermutationRequest } from "./permutation-request";

export class QuoteRequest {
    feedSettings: {};
    permutations: PermutationRequest[];

    constructor(permutations: PermutationRequest[]) {
        this.feedSettings = {};
        this.permutations = permutations;
    }
}
