using System;
using System.Collections.Generic;
using System.Linq;

public class LearningManager
{
    private List<Course> courses = new();
    private List<Enrollment> enrollments = new();
    private List<StudentProgress> progressList = new();
    private int enrollmentCounter = 1;

    public void AddCourse(string code, string name, string instructor,
                          int weeks, double price, List<string> modules)
    {
        if (!courses.Any(c => c.CourseCode == code))
        {
            courses.Add(new Course
            {
                CourseCode = code,
                CourseName = name,
                Instructor = instructor,
                DurationWeeks = weeks,
                Price = price,
                Modules = modules
            });
        }
    }

    public bool EnrollStudent(string studentId, string courseCode)
    {
        var course = courses.FirstOrDefault(c => c.CourseCode == courseCode);
        if (course == null || enrollments.Any(e => e.StudentId == studentId && e.CourseCode == courseCode))
            return false;

        enrollments.Add(new Enrollment
        {
            EnrollmentId = enrollmentCounter++,
            StudentId = studentId,
            CourseCode = courseCode,
            EnrollmentDate = DateTime.Now,
            ProgressPercentage = 0
        });
        return true;
    }

    public bool UpdateProgress(string studentId, string courseCode, string module, double score)
    {
        var progress = progressList.FirstOrDefault(p => p.StudentId == studentId && p.CourseCode == courseCode);
        if (progress == null)
        {
            progress = new StudentProgress { StudentId = studentId, CourseCode = courseCode };
            progressList.Add(progress);
        }

        progress.ModuleScores[module] = score;
        progress.LastAccessed = DateTime.Now;

        var totalModules = courses.First(c => c.CourseCode == courseCode).Modules.Count;
        progressList.First(p => p.StudentId == studentId && p.CourseCode == courseCode)
                    .ModuleScores.TryGetValue(module, out double s);

        var percentage = progress.ModuleScores.Values.Sum() / totalModules;
        enrollments.First(e => e.StudentId == studentId && e.CourseCode == courseCode).ProgressPercentage = percentage;
        return true;
    }

    public Dictionary<string, List<Course>> GroupCoursesByInstructor()
    {
        return courses.GroupBy(c => c.Instructor)
                      .ToDictionary(g => g.Key, g => g.ToList());
    }

    public List<Enrollment> GetTopPerformingStudents(string courseCode, int count)
    {
        return enrollments.Where(e => e.CourseCode == courseCode)
                          .OrderByDescending(e => e.ProgressPercentage)
                          .Take(count)
                          .ToList();
    }
}
