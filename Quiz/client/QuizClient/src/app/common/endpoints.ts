export const SERVER_ENDPOINT = 'http://localhost:64380';
export const REGISTER_ENDPOINT = '/api/account/register';

export class Endpoints {
    public server: string = 'http://localhost:64380';
    public register: string = this.server + '/api/account/register';
    public login: string = this.server + '/token';
    public home: string = this.server + '/home';
}