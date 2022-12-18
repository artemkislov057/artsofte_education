import { RouterReducerState } from "@ngrx/router-store"
import { CourseIdState, initCourseIdState } from "./course-id.state";
import { initModuleIdState, ModuleIdState } from "./module-id.state";

export type AppState = {
    router?: RouterReducerState;
    courseId: CourseIdState;
    moduleId: ModuleIdState;
}

export const initAppSate: AppState = {
    courseId: initCourseIdState,
    moduleId: initModuleIdState,
}

export const getInitState = () => {
    return initAppSate;
}