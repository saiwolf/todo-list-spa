export interface ITodo {
    id: string,
    name: string,
    created: number,
    updated?: number,
    status: TodoStatus,
}

export enum TodoStatus {
    Open = "Open",
    Completed = "Completed",
}

export interface IAddTodo {
    name: string,
}

export interface IUpdateTodo {
    id: string,
    name: string,
    updated: number,
    status: TodoStatus,
}

export interface IDeleteTodo {
    id: string,
}

export interface ITodoUI {
    status: TodoStatus,
    icon: string,
}

export const TodoStatusIcon = (status: TodoStatus): string => {
    switch (status) {
        case TodoStatus.Open:
            return 'bi-patch-question-fill';
        case TodoStatus.Completed:
            return 'bi-patch-check-fill';
        default:
            return 'bi-exclamation-triangle-fill';
    }
}