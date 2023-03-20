import { RouteObject } from 'react-router-dom';
import { TodoList } from './_components/TodoList';

const AppRoutes: RouteObject[] = [
    {
        index: true,
        element: <TodoList />
    }
];

export default AppRoutes;