import { createContext, useContext } from "react";
import CommonStore from "./commonStore";
import CompanyStore from "./companyStore";
import ModalStore from "./modalStore";
import UserStore from "./userStore";

interface Store {
    userStore: UserStore
    commonStore: CommonStore
    modalStore: ModalStore
    companyStore: CompanyStore
}

export const store: Store = {
    userStore: new UserStore(),
    commonStore: new CommonStore(),
    modalStore: new ModalStore(),
    companyStore: new CompanyStore()

}

export const StoreContext = createContext(store);

export function useStore() {
    return useContext(StoreContext);
}