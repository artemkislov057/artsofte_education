import { OutputData } from "@editorjs/editorjs";

export type CourseType = {
    "id": string;
    "name": string;
    "description": string;
    "modules": Module[];
}

export type Module = {
    "id": string;
    "name": string;
    "description": string;
    "lessons": Lesson[];
}

export type Lesson = {
    "id": number;
    "name": string;
    "type": string;
    "value": OutputData;
    "additionalText"?: OutputData;
}