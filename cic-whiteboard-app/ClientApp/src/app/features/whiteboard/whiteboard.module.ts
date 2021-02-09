import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WhiteboardComponent } from './whiteboard.component';
import { PostComponent } from './components/post/post.component';
import { WhiteboardResolver } from './whiteboard.resolver';
import { WhiteboardStore } from './whiteboard.store';
import { DatePipe } from '@angular/common';


@NgModule({
  declarations: [WhiteboardComponent, PostComponent],
  imports: [
    CommonModule
  ],
  providers: [WhiteboardResolver, WhiteboardStore, DatePipe]
})
export class WhiteboardModule { }
