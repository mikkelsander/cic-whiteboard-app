import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../models/user';



@Injectable()
export class UsersHttpService
{
    private baseUrl: string;

    constructor(private _httpClient: HttpClient)
    {
        this.baseUrl = environment.API_BASE_URL + "/users";
    }

    //hack to mock a current user
    getCurrentUser(): Observable<User> {
        return this._httpClient.get<User>(this.baseUrl + '/current');
    }

    getAllUsers(): Observable<User[]> {
        return this._httpClient.get<User[]>(this.baseUrl);
    }
}
