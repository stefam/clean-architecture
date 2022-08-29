import React from 'react';

const Counter = (): JSX.Element => {
    const [state, setState] = React.useState<any>({ currentCount: 0 });

    const incrementCounter = (): void => {
        setState({
            currentCount: state.currentCount + 1
        });
    }

    return (
        <div>
            <h1>Counter</h1>
            <p>This is a simple example of a React component.</p>
            <p aria-live="polite">Current count: <strong>{state.currentCount}</strong></p>
            <button className="btn btn-primary" onClick={incrementCounter}> Increment </button>
        </div>
    );
}

export default Counter;
