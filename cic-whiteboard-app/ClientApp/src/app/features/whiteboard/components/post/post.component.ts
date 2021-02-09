import { ChangeDetectionStrategy, Component, EventEmitter, Input, OnChanges, OnInit, Output } from '@angular/core';
import { User } from 'oidc-client';
import { pipe } from 'rxjs';
import { tap } from 'rxjs/operators';
import { Post } from 'src/app/models/post';
import { UserComment } from 'src/app/models/user-comment';
import { ReactionType, UserReaction } from 'src/app/models/user-reaction';
import { WhiteboardStore } from '../../whiteboard.store';

export interface PostReactionEvent {
  postId: number;
  type: ReactionType;
}

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss'],
})
export class PostComponent implements OnInit {

  @Input() post: Post;

  public comments: UserComment[] = [];
  public likes: UserReaction[] = [];

  constructor(private _whiteboardStore: WhiteboardStore) { }

  ngOnInit() {
    this._whiteboardStore.state$
      .pipe(
        tap(state => {
          this.comments = this.post.comments.map(c => <UserComment>{...c, user: state.users.find(u => u.id === c.userId) })
        })
      ).subscribe()

    this.filterLikeReactions();
  }

  likePost() {
    this._whiteboardStore.createReaction(this.post.id, ReactionType.Like)
      .pipe(
        tap(() => this.filterLikeReactions())
      )
      .subscribe();
  }


  private filterLikeReactions() {
    this.likes = this.post.reactions.filter(r => r.type == ReactionType.Like);
  }

}
