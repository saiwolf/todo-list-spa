import { useEffect, useState } from 'react';
import { ITodo, TodoStatusIcon } from '../_models/Todo';
import '~bootstrap-icons/font/bootstrap-icons.css';

export function TodoList() {
    const [isLoading, setLoading] = useState<boolean>(true);
    const [todos, setTodos] = useState<ITodo[]>([]);

    useEffect(() => {
        const fetchTodos = async () => {
            let response = await fetch('api/todos');
            let data = await response.json();
            setTodos(data);
            setLoading(false);
            //console.log(data);
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
                <p key={index}>Name: {todo.name} -
                    <i className={`bi ${TodoStatusIcon(todo.status)}`}></i>
                </p>
            ))}
        </>
    )
}

