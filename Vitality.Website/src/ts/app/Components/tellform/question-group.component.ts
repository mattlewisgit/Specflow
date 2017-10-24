import { Component, Input, OnInit } from "@angular/core";
import { FormGroup }  from "@angular/forms";

import { QuestionGroup }     from "../../models/question-group";
import { Question }     from "../../models/question";
import { QuestionControlService } from "../../services/question-control.service";
import { PostcodeService } from "../../services/postcode.service";

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
  
    constructor(private qcs: QuestionControlService, private postcodeService: PostcodeService) {
    }

    ngOnInit(): void {
        this.qcs.addFormControls(this.form, this.questionGroup);
    }

    storeSelectedCheckboxValues(event: any, selectedValue: string, question: Question<any>): void {
        question.value = question.value || new Array<string>();
        const checked = event.target.checked;
        // Add/Remove checkbox value from array
        if (checked) {
            question.value.push(selectedValue);
        } else {
            this.removeOption(selectedValue, question);
        }
        this.qcs.multiSelectOptionsEmitter.emit(question.value.length >= this.questionGroup.basedOnValues[0]);
    }

    removeOption(selectedValue: string, question: Question<any>): void {
        const index = question.value.indexOf(selectedValue, 0);
        if (index > -1) {
            question.value.splice(index, 1);
        }
    }

    btnAction(action: string) {
        switch (action) {
            case "postcodeSearch":
                this.findAddress((this.questionGroup.questions.filter(x => x.key === "billingPostcode")[0]).value);
        default:
        }
    }

    findAddress(postcode: string) {
        this.postcodeService.updatePostcodeEmitter.emit(postcode);
    }
}
