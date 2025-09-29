namespace SwiftPark1;

public class Student
{
    private readonly List<string> enrolledCourses = [];
    private readonly HashSet<string> completedLessons = [];

    public Student()
    {
    }

    public void CompleteLesson(string lessonId)
    {
        completedLessons.Add(lessonId);
    }

    public void EnrolOn(string courseId)
    {
        enrolledCourses.Add(courseId);
    }

    public double GetProgress(string courseId)
    {
        if (!enrolledCourses.Contains(courseId))
        {
            throw new NotEnrolledException();
        }

        var numberOfLessons = CourseDirectory.LessonsIn(courseId);
        var completedCourseLessons = completedLessons.Where(l => CourseDirectory.LessonIsIn(courseId, l));

        return (double)completedCourseLessons.Count() / numberOfLessons;
    }
}

public class NotEnrolledException : Exception
{
}

public static class CourseDirectory
{
    private static readonly Dictionary<string, List<string>> Courses = new()
    {
        {"test-course-01", new() {"test-lesson-01", "test-lesson-02", "test-lesson-03", "test-lesson-04"}},
        {"test-course-02", new() {"test-lesson-01", "test-lesson-02", "test-lesson-03", "test-lesson-04", "test-lesson-05"}},
    };

    public static int LessonsIn(string courseId)
    {
        return Courses[courseId].Count;
    }

    public static bool LessonIsIn(string courseId, string lessonId)
    {
        return Courses[courseId].Contains(lessonId);
    }
}