import { makeAutoObservable, runInAction } from "mobx";
import agent from "../api/agent";
import { User, UserFormValues } from "../models/user";
import { v4 as uuid } from 'uuid';
import { store } from "./store";
import { router } from "../router/Routes";

export default class UserStore {
    currentUser: User | null = null;
    userRegistry = new Map<string, User>();
    selectedUser: User | undefined = undefined;
    editMode = false;
    loading = false;
    loadingInitial = false;


    constructor() {
        makeAutoObservable(this)
    }

    get isLoggedIn() {
        return !!this.currentUser;
    }

    login = async (creds: UserFormValues) => {
        console.log(creds);
        try {
            const user = await agent.Users.login(creds);
            store.commonStore.setToken(user.token);
            runInAction(() => this.currentUser = user)
            router.navigate('/mainPage');
            store.modalStore.closeModal();
        } catch (error) {
            throw error;
        }
    }
    register = async (creds: UserFormValues) => {
        console.log(creds);
        try {
            const user = await agent.Users.register(creds);
            store.commonStore.setToken(user.token);
            runInAction(() => this.currentUser = user)
            router.navigate('/users');
            store.modalStore.closeModal();
        } catch (error) {
            throw error;
        }
    }
    logout = () => {
        store.commonStore.setToken(null);
        this.currentUser = null;
        router.navigate('/')
    }
    userGetter = async () => {
        try {
            const user = await agent.Users.current();
            runInAction(() => this.currentUser = user)
        } catch (error) {
            console.log(error);
        }
    }
    get usersByLastName() {
        console.log(this.userRegistry);
        return Array.from(this.userRegistry.values()).sort((a, b) => (a.userName.toLowerCase() > b.userName.toLowerCase()) ? 1 : ((a.userName.toLowerCase() < b.userName.toLowerCase()) ? -1 : 0));
    }

    get groupedUsers() {
        return Object.entries(
            this.usersByLastName.reduce((users, user) => {
                const role = user.role;
                users[role] = users[role] ? [...users[role], user] : [user];
                return users;
            }, {} as { [key: string]: User[] })
        )
    }
    
    loadUsers = async () => {
        this.setLoadingInitial(true);
        try {
            const users = await agent.Users.list();
            users.forEach(user => {
                this.setUser(user);
            })
            this.setLoadingInitial(false);
        } catch (error) {
            console.log(error);
            this.setLoadingInitial(false);
        }
    }

    setLoadingInitial = (state: boolean) => {
        this.loadingInitial = state;
    }


    createUser = async (user: User) => {
        this.loading = true;
        user.id = uuid();
        try {
            await agent.Users.create(user);
            runInAction(() => {
                this.userRegistry.set(user.id, user);
                this.selectedUser = user;
                this.editMode = false;
                this.loading = false;
            })
        } catch (error) {
            console.log(error);
            runInAction(() => {
                this.loading = false;
            })
        }
    }
    updateUser = async (user: User) => {
        this.loading = true;
        try {
            await agent.Users.update(user);
            runInAction(() => {
                this.userRegistry.set(user.id, user);
                this.selectedUser = user;
                this.editMode = false;
                this.loading = false;
            })
        } catch (error) {
            console.log(error);
            runInAction(() => {
                this.loading = false;
            })
        }
    }
    deleteUser = async (id: string) => {
        this.loading = true;
        try {
            await agent.Users.delete(id);
            runInAction(() => {
                this.userRegistry.delete(id);
                this.loading = false;
            })
        } catch (error) {
            runInAction(() => {
                this.loading = false;
            })
        }
    }
    loadUser = async (id: string) => {
        let user = this.getUser(id);
        if (user) {
            this.selectedUser = user;
            return user;
        }
        else {
            this.setLoadingInitial(true);
            try {
                user = await agent.Users.details(id);
                this.setUser(user);
                runInAction(() => this.selectedUser = user);
                this.selectedUser = user;

                this.setLoadingInitial(false);
                return user;
            } catch (error) {
                console.log(error);
                this.setLoadingInitial(false);
            }
        }
    }

    private setUser = (user: User) => {
        this.userRegistry.set(user.id, user);
    }
    private getUser = (id: string) => {
        return this.userRegistry.get(id);
    }
}