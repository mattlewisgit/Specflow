import { Component, Input, OnInit } from "@angular/core";
import { FormGroup }        from "@angular/forms";

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
        this.qcs.addFormControls(this.form, this.questionGroup.questions);
    }

    get isValid() {
        for (let entry of this.questionGroup.questions) {
            let control = this.form.controls[entry.key];
            if (!control.valid && !control.pristine) {
                return false;
            }
        }
        return true;
    }

    makeVisible(basedOnKey: string, basedOnValues: string[]): boolean {
        if (!basedOnKey || !basedOnValues) {
            return true;
        }
        let control = this.form.controls[basedOnKey];
        for (let basedOnValue of basedOnValues) {
            if (control.value === basedOnValue) {
                return true;
            }
        }
        return false;
    }


    // Only used for children Dobs
    makeControlVisible(basedOnKey: string, basedOnValue: number): boolean {
        if (!basedOnKey) {
            return true;
        }
        const control = this.form.controls[basedOnKey];
        return +control.value >= basedOnValue;
    }
}
