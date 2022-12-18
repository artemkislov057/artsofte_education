import { createSelector } from "@ngrx/store";
import { AppState } from "../states/app.state";
import { ModuleIdState } from "../states/module-id.state";

const selectModuleId = (state: AppState) => state.moduleId;

export const ModuleIdSelector = createSelector(
    selectModuleId,
    (state: ModuleIdState) => state.moduleId,
)