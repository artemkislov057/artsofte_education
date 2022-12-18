import { createSelector } from "@ngrx/store";
import { AppState } from "../states/app.state";
import { CourseIdState } from "../states/course-id.state";

const selectCourseId = (state: AppState) => state.courseId;

export const CourseIdSelector = createSelector(
    selectCourseId,
    (state: CourseIdState) => state.courseId,
)