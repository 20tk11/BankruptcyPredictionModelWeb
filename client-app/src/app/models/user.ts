export interface User {
    id: string;
    organization?: string;
    firstName: string;
    lastName: string;
    email: string;
    userName: string;
    phoneNumber?: string;
    country?: string;
    city?: string;
    role: string;
    token: string | null;
}

export interface UserFormValues {
    email: string;
    password: string;
    userName?: string;
    firstName?: string;
    lastName?: string;

}

