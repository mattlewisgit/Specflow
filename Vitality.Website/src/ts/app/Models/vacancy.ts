import { ExtraDataItem } from '../models/extradataitem';

export class Vacancy {
	Advertid: number;
	ClosingDate: string;
	Description: string;
	JobType: string;
	JobLocation: string;
	JobSalary: string;
    JobTitle: string;
	Link: string;
    Title: string;
    ExtraDataItems: Array<ExtraDataItem>;
}