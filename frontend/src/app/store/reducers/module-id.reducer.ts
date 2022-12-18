import { ModuleIdActions, ModuleIdActionsType } from "../actions/module-id.action";
import { initModuleIdState, ModuleIdState } from "../states/module-id.state";


export const ModuleIdReducer =  (
    state = initModuleIdState,
    action: ModuleIdActionsType
): ModuleIdState => {
    switch(action.type) {
        case ModuleIdActions.Set_Module_Id: 
            return {
                ...state,
                moduleId: action.payload
            };
        default:
            return state;
    }
}