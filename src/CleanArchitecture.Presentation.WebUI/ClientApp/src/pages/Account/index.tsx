import React from 'react';
import { CreateAccountCommand } from '../../services/account/models';
import * as _api from '../../services/account';
import AccountForm from './components/AccountForm';

const Account = (): JSX.Element => {
    const onCreate = React.useCallback(async (name: string, email: string, username: string): Promise<void> => {
        const account: CreateAccountCommand = {
            Name: name,
            Email: email,
            GitHubUsername: username
        };

        await _api.create(account);
    }, []);

    return (
        <article>
            <AccountForm onSubmit={onCreate} />
        </article>
    );
}

export default Account;
