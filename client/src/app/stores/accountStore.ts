import { makeAutoObservable } from "mobx";

export default class AccountStore {
    isAdmin: boolean = false;

    constructor() {
        makeAutoObservable(this);
    }
}