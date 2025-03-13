export class User {
    id: number;
    empId: string
    img: string;
    username: string;
    password: string;
    firstName: string;
    lastName: string;
    role: any;
    token?: string;
    
    constructor() {
      this.id = 0;
      this.img = '';
      this.username = '';
      this.password = '';
      this.firstName = '';
      this.lastName = '';
      this.empId = '';
      this.role = null; // You need to replace 'Role.Default' with the default role value
      // this.token = ''; // Optionally initialize token if it's not always provided
    }
  }