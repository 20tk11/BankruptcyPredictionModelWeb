import { makeAutoObservable, runInAction } from "mobx";
import agent from "../api/agent";
import { User, UserFormValues } from "../models/user";
import { v4 as uuid } from 'uuid';
import { store, useStore } from "./store";
import { router } from "../router/Routes";
import { Company } from "../models/company";

export default class CompanyStore {

    companyRegistry = new Map<string, Company>();
    selectedUserId: string | undefined = undefined;
    selectedCompany: Company | undefined = undefined;
    editMode = false;
    loading = false;
    loadingInitial = false;


    constructor() {
        makeAutoObservable(this)
    }
    setSelectedUser = (id: string) => {
        this.selectedUserId = id;
    }
    get companiesByLastName() {
        console.log(this.companyRegistry);
        return Array.from(this.companyRegistry.values()).sort((a, b) => (a.name.toLowerCase() > b.name.toLowerCase()) ? 1 : ((a.name.toLowerCase() < b.name.toLowerCase()) ? -1 : 0));
    }

    loadCompanies = async (id: string) => {
        this.setLoadingInitial(true);
        try {
            const companies = await agent.Companies.list(id);
            companies.forEach(company => {
                this.setCompany(company);
            })
            this.setLoadingInitial(false);


        } catch (error) {
            console.log(error);
            this.companyRegistry.clear();
            this.setLoadingInitial(false);

        }
    }
    private setCompany = (company: Company) => {
        this.companyRegistry.set(company.id, company);
    }
    setLoadingInitial = (state: boolean) => {
        this.loadingInitial = state;
    }


    createCompany = async (userid: string, company: Company) => {
        this.loading = true;
        company.id = uuid();
        try {
                await agent.Companies.create(userid, company);
                runInAction(() => {
                    this.companyRegistry.set(company.id, company);
                    this.selectedCompany = company;
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
    updateCompany = async (userid: string, company: Company) => {
        this.loading = true;
        try {

            agent.Companies.update(userid, company);
            runInAction(() => {
                this.companyRegistry.set(company.id, company);
                this.selectedCompany = company;
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
    deleteCompany = async (id: string) => {
        console.log("trinimas");
        this.loading = true;
        try {
            await agent.Companies.delete(id);
            runInAction(() => {
                this.companyRegistry.delete(id);
                this.loading = false;
            })
        } catch (error) {
            runInAction(() => {
                this.loading = false;
            })
        }
    }
    loadCompany = async (userid: string, id: string) => {
        let company = this.getCompany(id);
        if (company) {
            this.selectedCompany = company;
            console.log(company)

            return company;
        }
        else {
            this.setLoadingInitial(true);

            try {
                company = await agent.Companies.details(userid, id);
                this.setCompany(company);

                runInAction(() => {
                    this.selectedCompany = company
                });
                this.selectedCompany = company;
                this.setLoadingInitial(false);
                return company;


            } catch (error) {
                console.log(error);
                this.setLoadingInitial(false);
            }
        }
    }

    private getCompany = (id: string) => {
        return this.companyRegistry.get(id);
    }
}