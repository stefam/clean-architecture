import React from 'react';

interface AccountFormProps {
    onSubmit: (name: string, email: string, username: string) => void;
}

const AccountForm = (props: AccountFormProps): JSX.Element => {
    const [name, setName] = React.useState<string>("");
    const [email, setEmail] = React.useState<string>("");
    const [username, setUsername] = React.useState<string>("");

    const submit = (): void => props.onSubmit(name, email, username);

    return (
        <div className="account-form-container">
            <div>
                <label>Name</label>
                <input type="text" max="50" onChange={(e) => setName(e.target.value)} value={name} />
            </div>
            <div>
                <label>Email</label>
                <input type="text" max="50" onChange={(e) => setEmail(e.target.value)} value={email} />
            </div>
            <div>
                <label>GitHub Username</label>
                <input type="text" max="50" onChange={(e) => setUsername(e.target.value)} value={username} />
            </div>
            <div className="actions">
                <button onClick={submit}>Create</button>
            </div>
        </div>
    );
}

export default AccountForm;
