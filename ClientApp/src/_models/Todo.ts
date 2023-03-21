/**
 * Interface definition for Todo model.
 */
export interface ITodo {
    id: string,
    name: string,
    created: number,
    updated?: number,
    status: TodoStatus,
}

/**
 * Definition for TodoStatus enum.
 */
export enum TodoStatus {
    Open = "Open",
    Completed = "Completed",
}

/**
 * AddTodo DTO interface
 */
export interface IAddTodo {
    name: string,
}

/**
 * UpdateTodo DTO interface
 */
export interface IUpdateTodo {
    id: string,
    name: string,
    updated: number,
    status: TodoStatus,
}

/**
 * DTO interface for Todo deletion.
 * 
 * Does not have a corresponding DTO on API backend.
 */
export interface IDeleteTodo {
    id: string,
}

/**
 * Interface for mapping Todo Status with a status icon.
 */
export interface ITodoUI {
    status: TodoStatus,
    icon: string,
}

/**
 * Function that maps a Todo Status with a status icon.
 * @param status Todo Status
 * @returns string containing CSS Class representing todo status.
 */
export const TodoStatusIcon = (status: TodoStatus): string => {
    switch (status) {
        case TodoStatus.Open:
            return 'bi-x status-open';
        case TodoStatus.Completed:
            return 'bi-check2 status-done';
        default:
            return 'bi-exclamation-triangle-fill';
    }
}