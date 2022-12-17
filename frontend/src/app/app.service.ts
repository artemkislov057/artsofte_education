import { Injectable } from "@angular/core";

@Injectable()
export class AppService {
    private currentCourseId: string = '';
    private currentModuleId: string = '';

    getCurrentCourseId() {
        return this.currentCourseId;
    }

    setCurrentCourseId(newId: string) {
        this.currentCourseId = newId;
    }

    getcurrentModuleId() {
        return this.currentModuleId;
    }

    setcurrentModuleId(newId: string) {
        this.currentModuleId = newId;
    }
}