export interface User {
    id: string;
    organization: string;
    firstName: string;
    lastName: string;
    emailAddress: string;
    loginName: string;
    loginPassword: string;
    phoneNumber: string;
    country: string;
    city: string;
    userCompanies: any[];
    userCreateDate: Date;
    userLastUpdateDate: Date;
}

