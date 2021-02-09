export interface UserReaction {
    id: number;
    userId: number;
    postId: number;
    type: ReactionType;
}

export enum ReactionType {
    Like = 0,
}