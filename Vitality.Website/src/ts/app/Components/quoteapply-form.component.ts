import { Component, Inject, OnInit }      from '@angular/core';
import { DOCUMENT } from '@angular/platform-browser';
import 'rxjs/add/operator/switchMap';

import { QuoteApplyForm } from '../models/quoteapplyform';
import { QuoteApplyService } from '../services/quoteapply.service';
import { WindowRef } from './windowref';

@Component({
  selector: 'quoteapply-form',
  templateUrl: './js/app/components/quoteapply-formtemplate.html'
})
export class QuoteApplyFormComponent implements OnInit  {
    quoteApplyForm: QuoteApplyForm;
    viewModel: any;

  constructor(
      private quoteApplyService: QuoteApplyService,
      @Inject(DOCUMENT) private document: any,
      private winRef: WindowRef
  ) {}

  ngOnInit(): void {
      if (!this.document.location.pathname.endsWith("/"))
      {
        this.document.location.pathname = this.winRef.ensureTrailingSlash(this.document.location.pathname);
      }

      this.viewModel = this.winRef.nativeWindow.angularData;
      this.quoteApplyForm =new QuoteApplyForm();
  }
}
