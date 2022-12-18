import { RouterReducerState } from "@ngrx/router-store"
import { CourseIdState, initCourseIdState } from "./course-id.state";

export type AppState = {
    router?: RouterReducerState;
    courseId: CourseIdState;
}

export const initAppSate: AppState = {
    courseId: initCourseIdState,
}

export const getInitState = () => {
    return initAppSate;
}