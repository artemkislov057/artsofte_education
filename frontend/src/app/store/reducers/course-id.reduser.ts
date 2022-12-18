import { CourseIdActions, CourseIdActionsType } from "../actions/course-id.action";
import { initCourseIdState, CourseIdState } from "../states/course-id.state";

export const CourseIdReducer =  (
    state = initCourseIdState,
    action: CourseIdActionsType
): CourseIdState => {
    switch(action.type) {
        case CourseIdActions.Set_Course_Id: 
            return {
                ...state,
                courseId: action.payload
            };
        default:
            return state;
    }
}