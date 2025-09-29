using FluentAssertions;

namespace SwiftPark1.Tests;

public class StudentTests
{
    private readonly Student student;

    public StudentTests()
    {
        student = new Student();
        student.EnrolOn("test-course-01");
        student.EnrolOn("test-course-02");
    }

    [Fact]
    public void ProgressIsUnavailableForAnUnenrolledStudent()
    {
        var student = new Student();
        var courseId = "test-course-01";

        var progress = () => student.GetProgress(courseId);

        progress.Should().Throw<NotEnrolledException>();
    }

    [Fact]
    public void ProgressIsZeroForANewlyEnrolledStudent()
    {
        var courseId = "test-course-01";

        var progress = student.GetProgress(courseId);

        progress.Should().Be(0);
    }

    [Theory]
    [InlineData("test-course-01", 0.25)]
    [InlineData("test-course-02", 0.2)]
    public void ProgressIsCorrectForStudentWithACompletedLesson(string courseId, double expectedProgress)
    {
        var lessonId = "test-lesson-01";

        student.CompleteLesson(lessonId);

        var progress = student.GetProgress(courseId);
        progress.Should().Be(expectedProgress);
    }

    [Theory]
    [InlineData("test-course-01", 0.75)]
    [InlineData("test-course-02", 0.6)]
    public void ProgressIsCorrectForStudentWithThreeCompletedLessons(string courseId, double expectedProgress)
    {
        var lessonId_1 = "test-lesson-01";
        var lessonId_2 = "test-lesson-02";
        var lessonId_3 = "test-lesson-03";

        student.CompleteLesson(lessonId_1);
        student.CompleteLesson(lessonId_2);
        student.CompleteLesson(lessonId_3);

        var progress = student.GetProgress(courseId);

        progress.Should().Be(expectedProgress);
    }

    [Fact]
    public void CompletingAnAlreadyCompletedLessonDoesNotChangeProgress()
    {
        var courseId = "test-course-01";
        var lessonId = "test-lesson-01";

        student.CompleteLesson(lessonId);

        var progress = student.GetProgress(courseId);
        progress.Should().Be(0.25);

        student.CompleteLesson(lessonId);
        progress = student.GetProgress(courseId);
        progress.Should().Be(0.25);
    }

    [Fact]
    public void CompletingAnUnknownLessonDoesNotChangeProgress()
    {
        var courseId = "test-course-01";
        var lessonId = "test-lesson-unknown";

        student.CompleteLesson(lessonId);

        var progress = student.GetProgress(courseId);
        progress.Should().Be(0);
    }

    [Fact]
    public void CompletingALessonChangesProgressOnMultipleCourses()
    {
        var courseId_1 = "test-course-01";
        var courseId_2 = "test-course-02";
        var lessonId = "test-lesson-01";

        student.CompleteLesson(lessonId);

        var progress_1 = student.GetProgress(courseId_1);
        var progress_2 = student.GetProgress(courseId_2);

        progress_1.Should().Be(0.25);
        progress_2.Should().Be(0.2);
    }
}