import { Container, Row, Col, ListGroup, ListGroupItem } from 'reactstrap';
import { ITodo, TodoStatusIcon } from '../_models/Todo';
import '~bootstrap-icons/font/bootstrap-icons.css';

type TodoItemProps = {
    todo: ITodo
};

export function TodoItem(props: TodoItemProps): JSX.Element {
    const { todo } = props;

    return (            
        <ListGroupItem className="todo-item mb-2 p-3 rounded text-white d-flex align-items-center">
            <i className={`bi ${TodoStatusIcon(todo.status)}`} style={{ fontSize: '1.5rem' }}></i>&emsp;
            {todo.name}
        </ListGroupItem>
    );
}