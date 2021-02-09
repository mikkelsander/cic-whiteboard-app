import { UserComment } from "./user-comment";
import { UserReaction } from "./user-reaction";

export interface Post {
    id: number;
    userId?: number;

    title: string;
    content: string;

    top?: number;
    left?: number;

    comments: UserComment[];
    reactions: UserReaction[];
}