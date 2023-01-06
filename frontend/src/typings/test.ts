import { OutputData } from "@editorjs/editorjs"

export type TestQuestion = {
    question: OutputData | null;
    questionType: QuestionType;
    answerOptions: AnswerOption[];
}

export type AnswerOption = {
    value: string;
    isCorrectAnswer: boolean;
}

export type QuestionType = 'RadioButton' | 'Checkboxes';