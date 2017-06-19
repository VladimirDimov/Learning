import { Component, OnInit } from '@angular/core';
import { UsersService } from "../services/users.service";
import { IUserInfoModel } from "../models/user-info.model";

@Component({
    selector: 'cp-userInfo',
    templateUrl: './user-info.component.html',
})

export class UserInfoComponent implements OnInit {

    constructor(private _usersService: UsersService)
    { }

    ngOnInit() {
        this._usersService.getUserInfo()
            .subscribe((data: IUserInfoModel) => {
                this.userInfo = data;
            }, err => {
                console.log(err);
            })
    }

    userInfo: IUserInfoModel;
}