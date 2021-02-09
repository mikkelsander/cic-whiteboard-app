import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Post } from '../models/post';
import { UserReaction } from '../models/user-reaction';
import { UserComment } from '../models/user-comment';


@Injectable()
export class PostsHttpService
{
    private baseUrl: string;

    constructor(private _httpClient: HttpClient)
    {
        this.baseUrl = environment.API_BASE_URL + "/posts";
    }

    getAllPosts(): Observable<Post[]> {
        return this._httpClient.get<Post[]>(this.baseUrl);
    }

    createPost(post: Post): Observable<Post> {
        return this._httpClient.post<Post>(this.baseUrl, post);
    }

    editPost(post: Post): Observable<Post> {
        return this._httpClient.put<Post>(this.baseUrl + '/' + post.id, post);
    }

    deletePost(postId: number): Observable<any> {
        return this._httpClient.delete<any>(this.baseUrl + '/' + postId);
    }

    postReaction(reaction: UserReaction): Observable<UserReaction> {
        return this._httpClient.post<UserReaction>(this.baseUrl + '/' + reaction.postId + '/reactions', reaction);
    }

    postComment(comment: UserComment): Observable<UserComment> {
        return this._httpClient.post<UserComment>(this.baseUrl + '/' + comment.postId + '/comments', comment);
    }

    deleteComment(comment: UserComment): Observable<UserComment> {
        return this._httpClient.delete<UserComment>(this.baseUrl + '/' + comment.postId + '/comments/' + comment.id);
    }

}
