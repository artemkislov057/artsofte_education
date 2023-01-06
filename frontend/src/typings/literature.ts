export type LiteratureLesson = {
    "name": string,
    "type": string,
    "value": {
      "elements": BookItem[]
    }
}

export type BookItem = {
    "name": string;
    "description": string;
    "coverSrc": string;
    "purchaseLinks": string[];
}