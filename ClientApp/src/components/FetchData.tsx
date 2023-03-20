import { useEffect, useState } from 'react';

export interface IForecast {
    date: number,
    temperatureC: number,
    temperatureF: number,
    summary: string,
}

export function FetchData(): JSX.Element {
    const [forecasts, setForecasts] = useState<IForecast[]>([]);
    const [isLoading, setIsLoading] = useState(true);

    useEffect(() => {
        const populateWeatherData = async () => {
            const response = await fetch('/api/weatherforecast');
            const data: IForecast[] = await response.json();
            
            setForecasts(data);
            setIsLoading(false);
        }

        populateWeatherData()
            .catch(console.error);
    }, []);

    const renderForecastsTable = (forecasts: IForecast[]) => {
        return (
            <div className="col-6 mx-auto">
                <div className="table-responsive">
                    <table className="table table-striped table-bordered w-auto align-middle" aria-labelledby='tableLabel'>
                        <thead>
                            <tr>
                                <th>Date</th>
                                <th>Temp. (C)</th>
                                <th>Temp. (F)</th>
                                <th>Summary</th>
                            </tr>
                        </thead>
                        <tbody>
                            {forecasts.map((forecast, index) => (
                                <tr className="text-center" key={index}>
                                    <td>{new Date(forecast.date).toLocaleDateString()}</td>
                                    <td className="text-end">{forecast.temperatureC}</td>
                                    <td className="text-end">{forecast.temperatureF}</td>
                                    <td>{forecast.summary}</td>
                                </tr>
                            ))}
                        </tbody>
                    </table>
                </div>
            </div>
        )
    }

    return (
        <>
            <h1 id="tableLabel">Weather Forecast</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {isLoading
                ? <p><em>Loading...</em></p>
                : renderForecastsTable(forecasts)
            }
        </>
    )
}

export default FetchData;