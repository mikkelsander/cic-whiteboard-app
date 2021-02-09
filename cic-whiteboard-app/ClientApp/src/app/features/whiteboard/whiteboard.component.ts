import { Component, OnInit } from '@angular/core';
import { tap } from 'rxjs/operators';
import { AuthService } from 'src/app/auth/services/auth.service';
import { Post } from 'src/app/models/post';
import { User } from 'src/app/models/user';
import { UserReaction } from 'src/app/models/user-reaction';
import { PostReactionEvent } from './components/post/post.component';
import { WhiteboardStore } from './whiteboard.store';

@Component({
  selector: 'app-whiteboard',
  templateUrl: './whiteboard.component.html',
  styleUrls: ['./whiteboard.component.scss']
})
export class WhiteboardComponent implements OnInit {

  public posts: Post[] = [];
  public users: User[] = [];
  public currentUser: User;

  constructor(private _whiteboardStore: WhiteboardStore, private _authService: AuthService) { }

  ngOnInit() {
    this._whiteboardStore.state$
      .pipe(
        tap(state => {
          this.posts = state.posts;
          this.users = state.users;
          this.currentUser = state.currentUser;
        })
      ).subscribe();
  }

  signOut() {
    this._authService.signOutUser();
    this._authService.redirectToSignInPage();
  }

}
