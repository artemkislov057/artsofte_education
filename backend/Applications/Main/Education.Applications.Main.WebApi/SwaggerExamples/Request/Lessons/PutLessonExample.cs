﻿using Education.Applications.Main.WebApi.Dto.Lessons;
using Education.Applications.Main.WebApi.Dto.Lessons.Contents.Literature;
using Education.Applications.Main.WebApi.Dto.Lessons.Contents.Presentation;
using Education.Applications.Main.WebApi.Dto.Lessons.Contents.Test;
using Education.Applications.Main.WebApi.Dto.Lessons.Contents.Text;
using Education.Applications.Main.WebApi.Dto.Lessons.Contents.Video;
using Swashbuckle.AspNetCore.Filters;

namespace Education.Applications.Main.WebApi.SwaggerExamples.Request.Lessons;

public class PutLessonExample : IMultipleExamplesProvider<PostPutLessonDto>
{
    public IEnumerable<SwaggerExample<PostPutLessonDto>> GetExamples()
    {
        yield return SwaggerExample.Create("Video",
            new PostPutLessonDto("Video Lesson",
                LessonTypeDto.Video,
                new VideoLessonContentDto
                {
                    VideoType = VideoTypeDto.YouTube,
                    Src = "https://www.youtube.com/watch?v=dQw4w9WgXcQ"
                }
            )
        );

        yield return SwaggerExample.Create("Presentation",
            new PostPutLessonDto("Presentation Lesson",
                LessonTypeDto.Presentation,
                new PresentationLessonContentDto
                {
                    Slides = new[]
                    {
                        new PresentationSlideDto("https://example.com/images/image1", "description1",
                            "https://example.com/voices/voice1"),
                        new PresentationSlideDto("https://example.com/images/image2", "description2",
                            "https://example.com/voices/voice2")
                    }
                }
            )
        );

        yield return SwaggerExample.Create("Literature",
            new PostPutLessonDto("Literature Lesson",
                LessonTypeDto.Literature,
                new LiteratureLessonContentDto
                {
                    Elements = new[]
                    {
                        new LiteratureElementDto("book1", "description1", "https://example.com/images/image1",
                            new[] { "https://example.com/books/1/link1", "https://example.com/books/1/link2" }),
                        new LiteratureElementDto("book2", "description2", "https://example.com/images/image2",
                            new[] { "https://example.com/books/2/link1", "https://example.com/books/2/link2" })
                    }
                })
        );

        yield return SwaggerExample.Create("Text",
            new PostPutLessonDto("Text Lesson",
                LessonTypeDto.Text,
                new TextLessonContentDto
                {
                    Value = "Lesson about something..."
                }));

        yield return SwaggerExample.Create("Test",
            new PostPutLessonDto("Test Lesson",
                LessonTypeDto.Test,
                new TestLessonContentDto
                {
                    Questions = new[]
                    {
                        new TestQuestionDto(
                            "Question with one answer",
                            QuestionTypeDto.RadioButton,
                            new[]
                            {
                                new QuestionAnswerOptionDto("Incorrect answer 1", false),
                                new QuestionAnswerOptionDto("Correct answer", true),
                                new QuestionAnswerOptionDto("Incorrect answer 2", false)
                            }
                        ),
                        new TestQuestionDto(
                            "Multiple Choice Question",
                            QuestionTypeDto.Checkboxes,
                            new[]
                            {
                                new QuestionAnswerOptionDto("Incorrect answer 1", false),
                                new QuestionAnswerOptionDto("Correct answer 1", true),
                                new QuestionAnswerOptionDto("Incorrect answer 2", false),
                                new QuestionAnswerOptionDto("Correct answer 2", true)
                            }
                        )
                    }
                }));
    }
}