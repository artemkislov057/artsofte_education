using Education.Applications.Main.WebApi.Dto.Lessons;
using Education.Applications.Main.WebApi.Dto.Lessons.Contents.Literature;
using Education.Applications.Main.WebApi.Dto.Lessons.Contents.Presentation;
using Education.Applications.Main.WebApi.Dto.Lessons.Contents.Video;
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
                new VideoLessonContentDto
                {
                    VideoType = VideoTypeDto.YouTube,
                    Src = "https://www.youtube.com/watch?v=dQw4w9WgXcQ"
                }
            )
        });

        yield return SwaggerExample.Create("Presentation", new[]
        {
            new GetLessonDto(2, "Presentation Lesson",
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
        });

        yield return SwaggerExample.Create("Literature", new[]
        {
            new GetLessonDto(3, "Literature Lesson",
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
        });
    }
}