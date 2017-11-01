import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from '../home/home.component';
import { LoginComponent } from '../login/login.component';
import { RegisterComponent } from '../register/register.component';
import { CreateQuizComponent } from '../create-quiz/create-quiz.component';

export const HOME_ROUTE: string = 'home';
export const LOGIN_ROUTE: string = 'user/login';
export const REGISTER_ROUTE: string = 'user/register';
export const CREATE_QUIZ_ROUTE: string = 'quiz/create';

const appRoutes: Routes = [
    { path: HOME_ROUTE, component: HomeComponent },
    { path: LOGIN_ROUTE, component: LoginComponent },
    { path: REGISTER_ROUTE, component: RegisterComponent },
    { path: CREATE_QUIZ_ROUTE, component: CreateQuizComponent },
];

export class RouterProvider {
    static routerModule = RouterModule.forRoot(
        appRoutes,
        { enableTracing: true } // <-- debugging purposes only
    );
}
