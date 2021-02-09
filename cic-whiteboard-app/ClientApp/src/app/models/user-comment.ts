import { User } from "./user";

export interface UserComment {
    id: number;
    userId: number,
    postId: number,

    content: string;
    createdTime: Date,
    lastModifiedTime: Date,

    user?: User;
}