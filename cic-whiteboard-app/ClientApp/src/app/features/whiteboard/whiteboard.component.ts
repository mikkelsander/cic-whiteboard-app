import { Component, OnInit } from '@angular/core';
import { tap } from 'rxjs/operators';
import { AuthService } from 'src/app/auth/services/auth.service';
import { Post } from 'src/app/models/post';
import { User } from 'src/app/models/user';
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



  dragStart(event: DragEvent, post: Post) {
    console.log(event)
    console.log(post)

    // let elem = document.createElement('div');
    // elem.id = 'drag-ghost';
    // elem.style.position = 'absolute';
    // elem.style.top = '-1000px';
    // elem.style.height = '30px'
    // elem.style.background = 'black';
    // elem.style.color = 'white';
    // elem.style.padding = '5px 10px 5px 10px'
    // elem.style.verticalAlign = 'center';
    // elem.style.textAlign = 'center';
    // elem.textContent = 'Post'
    // document.body.appendChild(elem);

    // event.dataTransfer.setDragImage(elem, -20, 0);

    event.dataTransfer.dropEffect = 'move';
    event.dataTransfer.setData('postId', post.id.toString());
  }

  dragEnd(event: DragEvent) {
    event.preventDefault();

    // let list = document.getElementsByClassName('highlight') as HTMLCollection

    // for (var i = 0; i < list.length; i++) {
    //     list[i].classList.remove('highlight');
    // }

    // const ghost = document.getElementById("drag-ghost");
    // if (ghost.parentNode) {
    //     ghost.parentNode.removeChild(ghost);
    // }
}

  dragOver(event: DragEvent) {
      event.preventDefault();
      event.dataTransfer.dropEffect = 'move';
  }

  drop(event: DragEvent) {
    event.preventDefault();

   const postId = Number(event.dataTransfer.getData('postId'));

    let posts = [...this.posts];
    let index = this.posts.findIndex(p => p.id === postId);

    posts[index].offsetX = event.offsetX;
    posts[index].offsetY = event.offsetY;
    
    this.posts = [...posts];

    this._whiteboardStore.movePost(postId, event.offsetX, event.offsetY,).subscribe();
  }


  signOut() {
    this._authService.signOutUser();
    this._authService.redirectToSignInPage();
  }

}
