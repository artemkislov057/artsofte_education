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
}