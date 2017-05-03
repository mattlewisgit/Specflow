import { Component, Inject, OnInit }      from '@angular/core';
import { DOCUMENT } from '@angular/platform-browser';

import { FeedSettings } from '../models/feedsettings';
import { Vacancy } from '../models/vacancy';
import { Vacancies } from '../models/vacancies';
import { VacanciesService } from '../services/vacancies.service';
import { WindowRef } from './windowref';

@Component({
  selector: 'vacancy-list',
  templateUrl: './js/app/components/vacancylisttemplate.html'
})
export class VacanciesComponent implements OnInit  {
    headline: string;
	vacancies: Array<Vacancy>;			// vacancies returned from feed
	filteredVacancies: Array<Vacancy>;	// vacancies filtered by location
	locations: Array<string>;			// job locations array
    departments: Array<string>;			// departments array
    vacancy: Vacancy;
    locationsLabel: string;
    departmentsLabel: string;
    allLocations: string;
    allDepartments: string;
    location: string;
    department: string;
    findoutMore: string;
    noVacanciesFoundText: string;
    vacancyLocation: string;
    vacancySalary: string;
    vacancyClosesOn: string;
    path: string;
    feedSettings: FeedSettings;
    locationsArray: string;
    departmentsArray: string;


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

        var data = this.winRef.nativeWindow.angularData;

        this.headline = data.headline;
        this.locationsLabel = data.locationsDropdownLabel;
        this.allLocations = data.allLocationsText;
        this.departmentsLabel = data.departmentsDropdownLabel;
        this.allDepartments = data.allDepartmentsText;
        this.findoutMore = data.findoutMoreText;
        this.noVacanciesFoundText = data.noVacanciesFoundText;
        this.vacancyLocation = data.locationText;
        this.vacancySalary = data.salaryText;
        this.vacancyClosesOn = data.closesOnText;
        this.feedSettings = data.feedSettings;
        this.locationsArray = data.locations;
        this.departmentsArray = data.departments;
        this.vacanciesService.setFeedSettings(this.feedSettings);

        this.getVacancies();
        this.path = this.winRef.ensureTrailingSlash(this.document.location.pathname);
	}

	getVacancies(): void {
		this.vacanciesService.getVacancies().then(v => this.initialisePage(v));
	}

    initialisePage(vac: Vacancies): void {
		this.vacancies = vac.Vacancies;
		this.getLocations();
        this.location = this.allLocations;

        this.getDepartments();
        this.department = this.allDepartments;

        this.filtersChanged(this.allLocations, this.allDepartments);
	}

	// populates locations array
	getLocations(): void {
		var locs = new Array();
		// add default location
		locs.push(this.allLocations);

		// add locations from feed
        this.locationsArray.split("|").forEach(s => this.addLocation(s, locs));

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
        depts.push(this.allDepartments);

        // add departments from feed
        this.departmentsArray.split("|").forEach(s => this.addDepartment(s, depts));

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

        if (loc != this.allLocations) {
            this.filteredVacancies = this.filteredVacancies.filter(p => p.JobLocation === loc);
        }

        if (dept != this.allDepartments) {
            this.filteredVacancies = this.filteredVacancies.filter(p => p.JobDepartment === dept);
        }
    }
}
