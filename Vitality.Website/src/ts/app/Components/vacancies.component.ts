import { Component, Inject, OnInit }      from '@angular/core';
import { DOCUMENT } from '@angular/platform-browser';

import { Vacancy } from '../Models/vacancy';
import { Vacancies } from '../Models/vacancies';
import { VacanciesService } from '../Services/vacancies.service';
import { WindowRef } from './windowRef';

@Component({
  selector: 'vacancy-list',
  templateUrl: './js/app/Components/vacancyListTemplate.html'
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

	constructor(
        private vacanciesService: VacanciesService,
        @Inject(DOCUMENT) private document: any,
        private winRef: WindowRef
	) {}

	ngOnInit(): void {
        this.getVacancies();
        this.path = this.document.location.pathname + "/";

        this.headline = this.winRef.nativeWindow.angularData.headline;
        this.locationsLabel = this.winRef.nativeWindow.angularData.locationsDropdownLabel;
        this.allLocations = this.winRef.nativeWindow.angularData.allLocationsText;
        this.departmentsLabel = this.winRef.nativeWindow.angularData.departmentsDropdownLabel;
        this.allDepartments = this.winRef.nativeWindow.angularData.allDepartmentsText;
        this.findoutMore = this.winRef.nativeWindow.angularData.findoutMoreText;
        this.noVacanciesFoundText = this.winRef.nativeWindow.angularData.noVacanciesFoundText;
        this.vacancyLocation = this.winRef.nativeWindow.angularData.locationText;
        this.vacancySalary = this.winRef.nativeWindow.angularData.salaryText;
        this.vacancyClosesOn = this.winRef.nativeWindow.angularData.closesOnText;

	    console.log('url:' + this.winRef.nativeWindow.angularData.FeedSettings);
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
        this.vacancies.forEach(s => this.addLocation(s, locs));

		this.locations = locs;
	}

	// add location to array
	addLocation(vacancy:Vacancy, locs: Array<string>) {
		// check location not already added
		if (locs.indexOf(vacancy.Joblocation) < 1)
		{
			locs.push(vacancy.Joblocation);
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
        this.vacancies.forEach(s => this.addDepartment(s, depts));

        this.departments = depts;
    }

    // add department to array
    addDepartment(vacancy: Vacancy, depts: Array<string>) {
        // check department not already added
        if (depts.indexOf(vacancy.Jobdepartment) < 1) {
            depts.push(vacancy.Jobdepartment);
        }
    }

    /// filters vacancy list based on selected department
    filtersChanged(loc: string, dept: string) {

        // reset filter
        this.filteredVacancies = this.vacancies;

        if (loc != this.allLocations) {
            this.filteredVacancies = this.filteredVacancies.filter(p => p.Joblocation === loc);
        }

        if (dept != this.allDepartments) {
            this.filteredVacancies = this.filteredVacancies.filter(p => p.Jobdepartment === dept);
        }
    }
}
