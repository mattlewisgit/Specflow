export class Life {
    lifeAgeOrBirthDate: { age: number };
    gender: string;
    lifeNumber: number;
    roleType: string;

    constructor(calculatedAge: number, gender: string, index: number, roleType: string) {
        this.lifeAgeOrBirthDate = { age: calculatedAge };
        this.gender = gender;
        this.lifeNumber = index;
        this.roleType = roleType;
    }
}
