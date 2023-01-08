import { Slide } from "./api/courseType"

export type PresentationLesson = {
    "name": string,
    "type": string,
    "value": {
      "slides": Slide[]
    }
}