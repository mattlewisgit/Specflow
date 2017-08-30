import { Component, Input, OnInit  } from "@angular/core";
import { FormGroup }  from "@angular/forms";

import { QuestionGroup }     from "../../models/question-group";
import { Question }     from "../../models/question";
import { QuestionControlService }    from "../../services/question-control.service";

@Component({
    selector: "question-group",
    templateUrl: "./js/app/components/tellform/question-group.component.html"
})
export class QuestionGroupComponent implements OnInit {
    @Input()
    questionGroup: QuestionGroup;
    @Input()
    form: FormGroup;
    @Input()
    renderingData: {};
    selectedCheckboxes: Array<string> = [];

    constructor(private qcs: QuestionControlService) {
    }

    ngOnInit(): void {
        this.qcs.addFormControls(this.form, this.questionGroup);
    }

    storeSelectedCheckboxValues(event:any, question: Question<any>): void {
        var key = event.target.getAttribute('value');
        var checked = event.target.checked;

        // Add/Remove checkbox value from array
        if (checked) {
            this.selectedCheckboxes.push(key);
        } else {
            var index = this.selectedCheckboxes.indexOf(key, 0);
            if (index > -1) {
                this.selectedCheckboxes.splice(index, 1);
            }
        }

        var maxSelectionsValidator = question.validators.filter(x => x.validatorName === "maxSelectionsValidator")[0];
        if (maxSelectionsValidator != null) {
            maxSelectionsValidator.parameters['selectedCheckboxes'] = this.selectedCheckboxes;
            console.log('limit: ' + maxSelectionsValidator.parameters['maxSelectionsExceeded']);
        }
    }
}
