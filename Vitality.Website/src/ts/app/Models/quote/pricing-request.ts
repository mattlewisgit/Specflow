import { PermutationRequest } from "./permutation-request";

export class PricingRequest {
    permutations: PermutationRequest[];

    constructor(permutations: PermutationRequest[]) {
        this.permutations = permutations;
    }
}
