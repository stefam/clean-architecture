import * as http from "../common";
import { WeatherForecastDto } from "./models";

export const getWeatherForecast = async (): Promise<WeatherForecastDto[]> => {
    return await http.get<WeatherForecastDto[]>('api/weatherforecast');
}