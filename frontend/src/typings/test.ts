import { OutputData } from "@editorjs/editorjs"

export type TestQuestion = {
    question: OutputData | null;
    questionType: QuestionType;
    answerOptions: AnswerOption[];
}

export type AnswerOption = {
    value: string;
    isCorrect: boolean;
}

export type QuestionType = 'radio' | 'checkbox';