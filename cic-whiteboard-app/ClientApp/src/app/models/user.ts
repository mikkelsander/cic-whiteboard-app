export interface User {
    id: number;
    name: string;
    userRole: UserRole;
    azureActiveDirectoryId: string;
}

export enum UserRole{
    User = 0,
    Moderator = 1,
}