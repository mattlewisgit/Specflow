import { Component, Input, OnInit, Output  } from "@angular/core";
import { FormGroup }  from "@angular/forms";

import { QuestionGroup }     from "../../models/question-group";
import { Question }     from "../../models/question";
import { QuestionControlService }    from "../../services/question-control.service";
@Component({
    selector: "question-group",
    templateUrl: "./js/app/components/quoteapply/question-group.component.html"
})
export class QuestionGroupComponent implements OnInit {
    @Input() questionGroup: QuestionGroup;
    @Input() form: FormGroup;

    constructor(private qcs: QuestionControlService) {
    }

    ngOnInit(): void {
        this.qcs.addFormControls(this.form, this.questionGroup);
    }
}
