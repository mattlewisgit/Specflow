import { PermutationRequest } from "./permutation-request";

export class QuoteRequest {
    permutations: PermutationRequest[];

    constructor(permutations: PermutationRequest[]) {
        this.permutations = permutations;
    }
}
