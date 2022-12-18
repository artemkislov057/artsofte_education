import { routerReducer } from "@ngrx/router-store";
import { ActionReducerMap } from "@ngrx/store";
import { AppState } from "../states/app.state";
import { CourseIdReducer } from "./course-id.reduser";

export const appReducer: ActionReducerMap<AppState, any> = {
    courseId: CourseIdReducer,
    router: routerReducer,
}