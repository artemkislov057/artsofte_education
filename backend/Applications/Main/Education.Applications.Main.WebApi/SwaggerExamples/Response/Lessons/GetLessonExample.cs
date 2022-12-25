using Education.Applications.Main.WebApi.Dto.Lessons;
using Education.Applications.Main.WebApi.Dto.Lessons.Contents.Literature;
using Education.Applications.Main.WebApi.Dto.Lessons.Contents.Presentation;
using Education.Applications.Main.WebApi.Dto.Lessons.Contents.Test;
using Education.Applications.Main.WebApi.Dto.Lessons.Contents.Text;
using Education.Applications.Main.WebApi.Dto.Lessons.Contents.Video;
using Education.Applications.Main.WebApi.SwaggerExamples.Dto;
using Swashbuckle.AspNetCore.Filters;

namespace Education.Applications.Main.WebApi.SwaggerExamples.Response.Lessons;

public class GetLessonExample : IMultipleExamplesProvider<GetLessonDto[]>
{
    public IEnumerable<SwaggerExample<GetLessonDto[]>> GetExamples()
    {
        yield return SwaggerExample.Create("Video", new[]
        {
            new GetLessonDto(1, "Video Lesson",
                LessonTypeDto.Video,
                LessonContentDtoExamples.Video,
                LessonContentDtoExamples.AdditionalText
            )
        });

        yield return SwaggerExample.Create("Presentation", new[]
        {
            new GetLessonDto(2, "Presentation Lesson",
                LessonTypeDto.Presentation,
                LessonContentDtoExamples.Presentation,
                LessonContentDtoExamples.AdditionalText
            )
        });

        yield return SwaggerExample.Create("Literature", new[]
        {
            new GetLessonDto(3, "Literature Lesson",
                LessonTypeDto.Literature,
                LessonContentDtoExamples.Literature,
                LessonContentDtoExamples.AdditionalText
            )
        });

        yield return SwaggerExample.Create("Text", new[]
        {
            new GetLessonDto(4, "Text Lesson",
                LessonTypeDto.Text,
                LessonContentDtoExamples.Text,
                LessonContentDtoExamples.AdditionalText
            )
        });

        yield return SwaggerExample.Create("Test", new[]
        {
            new GetLessonDto(5, "Test Lesson",
                LessonTypeDto.Test,
                LessonContentDtoExamples.Test,
                LessonContentDtoExamples.AdditionalText
            )
        });
    }
}