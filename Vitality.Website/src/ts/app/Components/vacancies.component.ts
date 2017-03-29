import { Component, OnInit }      from '@angular/core';
import { Router } from '@angular/router';

import { Vacancy } from '../Models/vacancy';
import { Vacancies } from '../Models/vacancies';
import { VacanciesService } from '../Services/vacancies.service';

@Component({
  selector: 'vacancies',
  templateUrl: './app/Components/vacancyList.html'
})
export class VacanciesComponent implements OnInit  {
	title = 'Latest Vacancies';	
	vacancies:Array<Vacancy>;			// vacancies returned from feed
	filteredVacancies:Array<Vacancy>;	// vacancies filtered by location
	locations:Array<string>;			// job locations array
	allLocations = "All locations";		// all job locations dropdown value
	vacancy:Vacancy;
	location:string;

	constructor(
		private router: Router,
		private vacanciesService: VacanciesService
	) {}
	
	ngOnInit(): void {
		this.getVacancies();		
	}
	  
	getVacancies(): void {
		this.vacanciesService.getVacancies().then(v => this.initialisePage(v));		
	}	

	initialisePage(vac:Vacancies): void {
		this.vacancies = vac.Vacancies;
		this.getLocations();
		this.locationChanged(this.allLocations);
		this.location = this.allLocations;
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

	/// filters vacancy list based on selected location
	locationChanged(loc:string) {
		this.filteredVacancies = loc === this.allLocations ? this.vacancies : this.vacancies.filter(e => e.Joblocation == loc);
	}

	// used if we want to display job details on same page
	onSelect(vacancy: Vacancy): void {
    	this.vacancy = vacancy;
  	}

	// used if we want to display job details on same page
	gotoDetail(): void {
    	this.router.navigate(['/vacancies', this.vacancy.Advertid]);
  }
}
