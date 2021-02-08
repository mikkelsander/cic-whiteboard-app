import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './auth/guards/auth.guard';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { WhiteboardComponent } from './whiteboard/whiteboard.component';
import { AuthModule } from './auth/auth.module';
import { WhiteboardModule } from './whiteboard/whiteboard.module';


const appRoutes: Routes = [
  {
    path: 'home',
    component: HomeComponent,
  },
  {
      path: 'whiteboard',
      canActivate: [AuthGuard],
      component: WhiteboardComponent,
      // loadChildren: () => import('./whiteboard/whiteboard.module').then(m => m.WhiteboardModule)
  },
  {
      path: '**',
      redirectTo: 'home'
  }
];


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(appRoutes),
    
    AuthModule,
    WhiteboardModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
