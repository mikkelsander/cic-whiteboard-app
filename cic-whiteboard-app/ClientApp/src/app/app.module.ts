import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { AuthGuard } from './auth/guards/auth.guard';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { WhiteboardComponent } from './features/whiteboard/whiteboard.component';
import { AuthModule } from './auth/auth.module';
import { WhiteboardModule } from './features/whiteboard/whiteboard.module';
import { WhiteboardResolver } from './features/whiteboard/whiteboard.resolver';
import { PostsHttpService } from './services/posts.http';
import { UsersHttpService } from './services/users.http';


const appRoutes: Routes = [
  {
      path: 'whiteboard',
      canActivate: [AuthGuard],
      resolve: [WhiteboardResolver],
      component: WhiteboardComponent,
  },
  {
      path: '**',
      redirectTo: 'whiteboard'
  }
];


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(appRoutes),
    
    AuthModule,
    WhiteboardModule
  ],
  providers: [PostsHttpService, UsersHttpService],
  bootstrap: [AppComponent]
})
export class AppModule { }
