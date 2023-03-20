import { useEffect, useState } from 'react';
import { ITodo } from '../_models/Todo';

import { TodoItem } from './TodoItem';
import { Container, ListGroup } from 'reactstrap';

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
        <>
            <h2 className="text-center fw-bolder">Todos</h2>
            <hr />
            {isLoading ? (
                <p><em>Loading...Please wait...</em></p>
            ) : (
                <TodoFC todos={todos} />
            )}
        </>
    );
}

const TodoFC = ({ todos }: { todos: ITodo[]}): JSX.Element => {
    return (
        <Container>
            <ListGroup flush>
                {todos.map((todo, index) => (
                    <TodoItem key={index} todo={todo} />
                ))}
            </ListGroup>
        </Container>
    )
}

