export class Life {
    lifeAgeOrBirthDate: { birthDate: string };
    gender: string;
    lifeNumber: number;
    roleType: string;

    constructor(birthDate: string, gender: string, index: number, roleType: string) {
        this.lifeAgeOrBirthDate = { birthDate: birthDate };
        this.gender = gender;
        this.lifeNumber = index;
        this.roleType = roleType;
    }
}
