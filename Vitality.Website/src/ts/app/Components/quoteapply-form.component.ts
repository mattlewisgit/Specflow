import { Component, Inject, OnInit, Input }      from "@angular/core";
import { FormArray, FormBuilder, FormGroup, Validators } from "@angular/forms";

import { DOCUMENT } from "@angular/platform-browser";
import "rxjs/add/operator/switchMap";

import { QuoteApplication } from "../models/quoteapplication";
import { QuoteApplyService } from "../services/quoteapply.service";
import { WindowRef } from "./windowref";

@Component({
    selector: "quoteapply-form",
    templateUrl: "./js/app/components/quoteapply-formtemplate.html"
})
export class QuoteApplyFormComponent implements OnInit {
    quoteApplyForm: FormGroup;
    quoteApplication: QuoteApplication;
    viewModel: any;
    submitted: boolean;

    constructor(
        private fb: FormBuilder,
        private quoteApplyService: QuoteApplyService,
        @Inject(DOCUMENT) private document: any,
        private winRef: WindowRef) {}


    ngOnInit(): void {
        if (!this.document.location.pathname.endsWith("/")) {
            this.document.location.pathname = this.winRef.ensureTrailingSlash(this.document.location.pathname);
        }
        this.viewModel = this.winRef.nativeWindow.angularData;
        this.createForm();
    }

    createForm() {
        this.quoteApplyForm = this.fb.group({
            title: [this.viewModel.Salutations[0].Value, <any>[Validators.required]],
            firstName: ["", <any>[Validators.required]],
            lastName: ["", <any>[Validators.required]],
            contactNumber: ["", <any>[Validators.required]],
            email: ["", <any>[Validators.required]],
            dateOfBirth: ["", <any>[Validators.required]]
        });
    }

    apply(model : QuoteApplication, isValid: boolean): void {
        this.submitted = true;
        this.quoteApplication = model;
    }
}
