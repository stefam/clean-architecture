import * as http from "../common";
import { CreateAccountCommand } from "./models";

export const create = async (account: CreateAccountCommand): Promise<string> => {
    return await http.post<typeof account, string>("api/accounts", account);
}
