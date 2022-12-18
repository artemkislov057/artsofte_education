import { Action } from "@ngrx/store";

export enum CourseIdActions {
    Get_Course_Id = '[CourseId] Get_Course_Id',
    Set_Course_Id = '[CourseId] Set_Course_Id',
}

export class GetCourseId implements Action {
    public readonly type = CourseIdActions.Get_Course_Id;
}

export class SetCourseId implements Action {
    public readonly type = CourseIdActions.Set_Course_Id;
    constructor(public payload: string) {  }
}

export type CourseIdActionsType = GetCourseId | SetCourseId;