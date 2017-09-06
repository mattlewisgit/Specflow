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

    constructor(private qcs: QuestionControlService) {
    }

    ngOnInit(): void {
        this.qcs.addFormControls(this.form, this.questionGroup);
    }

    storeSelectedCheckboxValues(event:any, question: Question<any>): void {
        var key = event.target.getAttribute('value');
        var checked = event.target.checked;

        question.selectedValues = question.selectedValues || new Array<string>();

        // Add/Remove checkbox value from array
        if (checked) {
            question.selectedValues.push(key);
        } else {
            var index = question.selectedValues.indexOf(key, 0);
            if (index > -1) {
                question.selectedValues.splice(index, 1);
            }
        }

        // TODO: remove this line once working
        console.log('question = ' + question.selectedValues.toString());        
    }
}
