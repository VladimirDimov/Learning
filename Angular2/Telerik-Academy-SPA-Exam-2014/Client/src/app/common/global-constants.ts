import { Injectable } from '@angular/core';

@Injectable()
export class GlobalConstants {
    public static serverUrl: string = 'http://localhost:1337';
    public static BearerTokenCookie: string = 'bearer_token';
}