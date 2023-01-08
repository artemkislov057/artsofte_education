import { OutputData } from "@editorjs/editorjs";
import { TestQuestion } from "../test";

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
    "value": OutputData | VideoValue | TestValue | PresentationValue;
    "additionalText"?: OutputData;
}

export type VideoValue = {
    "videoType": string;
    "src": string;
}

export type TestValue = {
    "questions": TestQuestion[];
}

export type PresentationValue = {
    "slides": Slide[];
}

export type Slide = {
    "imageSrc": string;
    "description": string;
    "voiceSrc": string;
}