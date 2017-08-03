﻿import { Component, Input, OnInit  } from "@angular/core";
import { FormGroup }  from "@angular/forms";

import { QuestionGroup }     from "../../models/question-group";
import { QuestionControlService }    from "../../services/question-control.service";

@Component({
    selector: "question-group",
    templateUrl: "./js/app/components/tellform/question-group.component.html"
})
export class QuestionGroupComponent implements OnInit {
    @Input() questionGroup: QuestionGroup;
    @Input() form: FormGroup;
    @Input() renderingData: {};


    constructor(private qcs: QuestionControlService) {
    }

    ngOnInit(): void {
        this.qcs.addFormControls(this.form, this.questionGroup);
    }
}