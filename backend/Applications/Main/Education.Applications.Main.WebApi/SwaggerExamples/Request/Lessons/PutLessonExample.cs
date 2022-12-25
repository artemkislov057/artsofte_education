using Education.Applications.Main.WebApi.Dto.Lessons;
using Education.Applications.Main.WebApi.Dto.Lessons.Contents.Literature;
using Education.Applications.Main.WebApi.Dto.Lessons.Contents.Presentation;
using Education.Applications.Main.WebApi.Dto.Lessons.Contents.Test;
using Education.Applications.Main.WebApi.Dto.Lessons.Contents.Text;
using Education.Applications.Main.WebApi.Dto.Lessons.Contents.Video;
using Education.Applications.Main.WebApi.SwaggerExamples.Dto;
using Swashbuckle.AspNetCore.Filters;

namespace Education.Applications.Main.WebApi.SwaggerExamples.Request.Lessons;

public class PutLessonExample : IMultipleExamplesProvider<PostPutLessonDto>
{
    public IEnumerable<SwaggerExample<PostPutLessonDto>> GetExamples()
    {
        yield return SwaggerExample.Create("Video",
            new PostPutLessonDto("Video Lesson",
                LessonTypeDto.Video,
                LessonContentDtoExamples.Video,
                LessonContentDtoExamples.AdditionalText
            )
        );

        yield return SwaggerExample.Create("Presentation",
            new PostPutLessonDto("Presentation Lesson",
                LessonTypeDto.Presentation,
                LessonContentDtoExamples.Presentation,
                LessonContentDtoExamples.AdditionalText
            )
        );

        yield return SwaggerExample.Create("Literature",
            new PostPutLessonDto("Literature Lesson",
                LessonTypeDto.Literature,
                LessonContentDtoExamples.Literature,
                LessonContentDtoExamples.AdditionalText
            )
        );

        yield return SwaggerExample.Create("Text",
            new PostPutLessonDto("Text Lesson",
                LessonTypeDto.Text,
                LessonContentDtoExamples.Text,
                LessonContentDtoExamples.AdditionalText
            )
        );

        yield return SwaggerExample.Create("Test",
            new PostPutLessonDto("Test Lesson",
                LessonTypeDto.Test,
                LessonContentDtoExamples.Test,
                LessonContentDtoExamples.AdditionalText
            )
        );
    }
}