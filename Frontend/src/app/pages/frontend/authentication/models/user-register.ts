export class UserRegister {
    firstName : string = "";
    lastName : string = "";
    email : string = "";
    userName : string = "";
    phoneNumber : string = "";
    isActive: boolean = true;
    password : string = "";
    canEditProfile: boolean = true;
    
    dateOfBirth : Date | null = null;
    genderId : number | null = null;
}
