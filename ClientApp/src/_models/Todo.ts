export interface ITodo {
    id: string,
    name: string,
    created: number,
    updated?: number,
    status: TodoStatus,
}

export enum TodoStatus {
    Open,
    Pending,
    Deleted,
    Completed,
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