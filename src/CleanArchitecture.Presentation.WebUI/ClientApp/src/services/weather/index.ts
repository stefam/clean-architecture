export const getWeatherForecast = async () => {
    const response = await fetch('api/weatherforecast');
    return await response.json();
}