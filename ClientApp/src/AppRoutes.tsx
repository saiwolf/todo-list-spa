import { RouteObject } from 'react-router-dom';
import { Counter, FetchData, Home } from './components';

const AppRoutes: RouteObject[] = [
    {
        index: true,
        element: <Home />
    },
    {
        path: '/counter',
        element: <Counter />
    },
    {
        path: '/fetch-data',
        element: <FetchData />
    }
];

export default AppRoutes;