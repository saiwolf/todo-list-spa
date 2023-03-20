import { useEffect, useState } from 'react';
import { ITodo } from '../_models/Todo';

export function TodoList() {
    const [isLoading, setLoading] = useState<boolean>(true);
    const [todos, setTodos] = useState<ITodo[]>([]);

    useEffect(() => {
        const fetchTodos = async () => {
            let response = await fetch('api/todos');
            let data = await response.json();
            setTodos(data);
            setLoading(false);
        }

        fetchTodos();
    }, [])

    return (
        isLoading ? (
            <p><em>Loading...Please wait...</em></p>
        ) : (
                <TodoFC todos={todos} />
        )
    );
}

const TodoFC = ({ todos }: { todos: ITodo[]}): JSX.Element => {
    return (
        <>
            {todos.map((todo, index) => (
                <p key={index}>Name: {todo.name} - Status: {todo.status}</p>
            ))}
        </>
    )
}

