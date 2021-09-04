export class Client {
    Id?: number;
    Name: string;
    BirthDate: Date;
    /**
     *
     */
    constructor(
        name: string,
        birthDate: Date
    ) {
        this.Name = name;
        this.BirthDate = birthDate        
    }
}