import { Injectable } from '@angular/core';
import { BehaviorSubject, forkJoin, Observable, of } from 'rxjs';
import { tap } from 'rxjs/operators';
import { AuthService } from 'src/app/auth/services/auth.service';
import { Post } from 'src/app/models/post';
import { User } from 'src/app/models/user';
import { UserComment } from 'src/app/models/user-comment';
import { ReactionType, UserReaction } from 'src/app/models/user-reaction';
import { PostsHttpService } from 'src/app/services/posts.http';
import { UsersHttpService } from 'src/app/services/users.http';
import { environment } from 'src/environments/environment';
import * as signalR from '@microsoft/signalr';

class WhiteboardState {
    currentUser: User;
    posts: Post[];
    users: User[];
}

@Injectable()
export class WhiteboardStore {

    public state$: Observable<WhiteboardState>;
    private _state$: BehaviorSubject<WhiteboardState>;

    private connection: signalR.HubConnection;

    constructor(
        private _postsHttpService: PostsHttpService,
        private _usersHttpService: UsersHttpService,
    ) {
        this._state$ = new BehaviorSubject(new WhiteboardState());
        this.state$ = this._state$.asObservable();
        
        this.connection = new signalR.HubConnectionBuilder()
            .withUrl(environment.POST_HUB_URL)
            .withAutomaticReconnect()
            .build();

        this.connect();
    }

    private connect() {
        // console.log("connect");
        this.connection.start();
        this.connection.on('PostUpdated', (postId: number, post: Post) => {
          console.log(post);
        });
        this.connection.onclose((event) => console.log(event))
    }

    /**
     * Initalize store
     *
     * @returns {Observable<any>}
     */
    load(): Observable<any> {
        return forkJoin([this._postsHttpService.getAllPosts(), this._usersHttpService.getAllUsers(), this._usersHttpService.getCurrentUser()])
            .pipe(
                tap(([posts, users, user]) => {
                    this.setState({
                        ...this.state,
                        posts: posts,
                        users: users,
                        currentUser: user,
                    });
                })
            );
    }


    createReaction(postId: number, type: ReactionType) {
        return this._postsHttpService.postReaction(<UserReaction> {
            userId: this.state.currentUser.id,
            postId: postId,
            type: type,
        })
        .pipe(
            // tap(postedReaction => {
            //     let _posts = [...this.state.posts];
            //     let _post = _posts.find(p => p.id === postedReaction.postId);
            //     let _reaction = _post.reactions.find(r => r.id === postedReaction.id);

            //     if (_reaction === undefined) {
            //         _post.reactions.push(postedReaction);
            //     }
            //     else {
            //         _reaction = postedReaction;
            //     }

            //     this.setState({
            //         ...this.state,
            //         posts: _posts
            //     });       
            // })
        );
    }

    createComment(comment: UserComment) {
        return this._postsHttpService.postComment(comment)
        .pipe(
            // tap(postedComment => {
            //     let _posts = [...this.state.posts];
            //     let _post = _posts.find(p => p.id === postedComment.postId);
            //     let _comment = _post.comments.find(c => c.id === postedComment.id);
                
            //     if (_comment === undefined) {
            //         _post.comments.push(postedComment);
            //     }
            //     else {
            //         _comment = postedComment;
            //     }

            //     this.setState({
            //         ...this.state,
            //         posts: _posts
            //     });       
            // })
        );
    }

    private get state(): WhiteboardState {
        return this._state$.getValue();
    }

    private setState(nextState: WhiteboardState) {
        this._state$.next(nextState);
    }
}
