import { Component, Inject, OnInit }      from '@angular/core';
import { DOCUMENT } from '@angular/platform-browser';

import { Vacancy } from '../models/vacancy';
import { Vacancies } from '../models/vacancies';
import { VacanciesService } from '../services/vacancies.service';
import { WindowRef } from './windowref';

@Component({
  selector: 'vacancy-list',
  templateUrl: './js/app/components/vacancylisttemplate.html'
})
export class VacanciesComponent implements OnInit  {
	vacancies: Array<Vacancy>;			// vacancies returned from feed
	filteredVacancies: Array<Vacancy>;	// vacancies filtered by location
    vacancy: Vacancy;
    locations: Array<string>;            // job locations array
    departments: Array<string>;            // departments array
    location: string;
    department: string;
    viewModel: any;

	constructor(
        private vacanciesService: VacanciesService,
        @Inject(DOCUMENT) private document: any,
        private winRef: WindowRef
	) {}

    ngOnInit(): void {
        if (!this.document.location.pathname.endsWith("/"))
        {
            this.document.location.pathname = this.winRef.ensureTrailingSlash(this.document.location.pathname);
        }

        this.viewModel = this.winRef.nativeWindow.angularData;
        this.vacanciesService.setFeedSettings(this.viewModel.FeedSettingsEndpoint, this.viewModel.FeedSettingsType, this.viewModel.FeedSettingsMockDataFileUrl);

        this.getVacancies();
        this.viewModel.Path = this.winRef.ensureTrailingSlash(this.document.location.pathname);
	}

	getVacancies(): void {
		this.vacanciesService.getVacancies().then(v => this.initialisePage(v));
	}

    initialisePage(vac: Vacancies): void {
		this.vacancies = vac.Vacancies;
        this.getLocations();
        // set initial value
        this.location = this.viewModel.AllLocationsText;

        this.getDepartments();
        // set initial value
        this.department = this.viewModel.AllDepartmentsText;

        this.filtersChanged(this.viewModel.AllLocationsText, this.viewModel.AllDepartmentsText);
	}

	// populates locations array
	getLocations(): void {
		var locs = new Array();
		// add default location
        locs.push(this.viewModel.AllLocationsText);

		// add locations from feed
        this.viewModel.Locations.forEach((s:any) => this.addLocation(s.trim(), locs));

		this.locations = locs;
	}

	// add location to array
	addLocation(loc:string, locs: Array<string>) {
		// check location not already added
		if (locs.indexOf(loc) < 1)
		{
            locs.push(loc.replace(/&amp;/g, '&'));
		}
	}

	// used if we want to display job details on same page
	onSelect(vacancy: Vacancy): void {
    	this.vacancy = vacancy;
    }

    // populates departments array
    getDepartments(): void {
        var depts = new Array();
        // add default department
        depts.push(this.viewModel.AllDepartmentsText);

        // add departments from feed
        this.viewModel.Departments.forEach((s:any) => this.addDepartment(s.trim(), depts));

        this.departments = depts;
    }

    // add department to array
    addDepartment(dept: string, depts: Array<string>) {
        // check department not already added
        if (depts.indexOf(dept) < 1) {
            depts.push(dept.replace(/&amp;/g, '&'));
        }
    }

    /// filters vacancy list based on selected department
    filtersChanged(loc: string, dept: string) {

        // reset filter
        this.filteredVacancies = this.vacancies;

        // remove expired jobs
        var now = new Date();
        var minDate = "0001-01-01T00:00:00";
        this.filteredVacancies = this.filteredVacancies.filter(p => p.ClosingDate === minDate || new Date(p.ClosingDate) > now);

        if (loc != this.viewModel.AllLocationsText) {
            this.filteredVacancies = this.filteredVacancies.filter(p => p.JobLocation === loc);
        }

        if (dept != this.viewModel.AllDepartmentsText) {
            this.filteredVacancies = this.filteredVacancies.filter(p => this.matchesJobDepartment(p, dept));
        }
    }

    matchesJobDepartment(vacancy: Vacancy, department: string): boolean {
        var depts: Array<string> = [];
        vacancy.ExtraDataItems.filter(p => p.Category === "Department").map(m => depts.push(m.Value));

        return depts.indexOf(department) > -1;
    }
}
