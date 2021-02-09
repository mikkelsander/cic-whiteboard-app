
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Router, Resolve } from '@angular/router';
import { Observable, forkJoin, of, combineLatest, throwError } from 'rxjs';
import { tap, switchMap, take, map, catchError } from 'rxjs/operators';
import { WhiteboardStore } from './whiteboard.store';




@Injectable()
export class WhiteboardResolver implements Resolve<Observable<any>> {

    constructor(private _whiteboardStore: WhiteboardStore,private _router: Router,
    ) { }

    resolve(route: ActivatedRouteSnapshot): Observable<any> {

        return forkJoin([
            this._whiteboardStore.load()
        ])
            .pipe(
                // catchError((err) => {
                //     console.log(err)
                //     return this._router.navigateByUrl('');
                // }),
            );
    }
}
