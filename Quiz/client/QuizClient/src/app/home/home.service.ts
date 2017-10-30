import { Injectable } from '@angular/core';
import { HttpRequester } from '../common/http-requester';
import { Observable } from 'rxjs/Observable';
import { HOME_ROUTE } from '../common/routes';
import { Endpoints } from '../common/endpoints';

@Injectable()
export class HomeService {

  constructor(private requester: HttpRequester, private endpoints: Endpoints) { }

  get(): Observable<any> {
    return this.requester.get(this.endpoints.home);
  }
}
