import React from 'react';

const FetchData = (): JSX.Element => {
    const [state, setState] = React.useState<any>({ forecasts: [], loading: true });

    const populateWeatherData = async () => {
        const response = await fetch('api/weatherforecast');
        const data = await response.json();
        setState({ forecasts: data, loading: false });
    }

    React.useEffect(() => {
        populateWeatherData();
    }, []);

    const renderForecastsTable = (forecasts: any): JSX.Element => {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>Temp. (C)</th>
                        <th>Temp. (F)</th>
                        <th>Summary</th>
                    </tr>
                </thead>
                <tbody>
                    {forecasts.map((forecast: any) =>
                        <tr key={forecast.date}>
                            <td>{forecast.date}</td>
                            <td>{forecast.temperatureC}</td>
                            <td>{forecast.temperatureF}</td>
                            <td>{forecast.summary}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    let contents = state.loading
        ? <p><em>Loading...</em></p>
        : renderForecastsTable(state.forecasts);

    return (
        <div>
            <h1 id="tabelLabel" >Weather forecast</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {contents}
        </div>
    );
}

export default FetchData;