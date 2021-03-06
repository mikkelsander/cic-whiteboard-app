import { UserComment } from "./user-comment";
import { UserReaction } from "./user-reaction";

export interface Post {
    id: number;
    userId?: number;

    title: string;
    content: string;

    offsetX?: number;
    offsetY?: number;

    comments: UserComment[];
    reactions: UserReaction[];
}