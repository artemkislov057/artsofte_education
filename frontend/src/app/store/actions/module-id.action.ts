import { Action } from "@ngrx/store";

export enum ModuleIdActions {
    Set_Module_Id = '[CourseId] Set_Module_Id',
}

export class SetModuleId implements Action {
    public readonly type = ModuleIdActions.Set_Module_Id;
    constructor(public payload: string) {  }
}

export type ModuleIdActionsType = SetModuleId;