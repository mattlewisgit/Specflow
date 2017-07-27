export class OpeningHours {
    weekDay: string;
    startHour: number;
    startMinute: number;
    endHour: number;
    endMinute: number;

    constructor(weekDay: string, startHour: number, startMinute: number, endHour: number, endMinute: number) {
        this.weekDay = weekDay;
        this.startHour = startHour;
        this.startMinute = startMinute;
        this.endHour = endHour;
        this.endMinute = endMinute;
    }
}
