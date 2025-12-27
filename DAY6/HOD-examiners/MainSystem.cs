using System;
using System.Collections.Generic;

namespace Management;

public class MainSystem
{
    public static void Main(string[] args)
    {
        // semesters
        var sem1 = new Semester("1");
        var sem2 = new Semester("2");

        // subjects
        var maths = new SubjectExam("Maths", sem1.SemId);
        var physics = new SubjectExam("Physics", sem1.SemId);
        var dsa = new SubjectExam("DSA", sem2.SemId);

        // examiners
        var ex1 = new Examiner("Dr. Mehta", "CSE", "EX01");
        var ex2 = new Examiner("Prof. Rao", "Science", "EX02");

        // scheduler
        var scheduler = new ExamScheduler();

        scheduler.ScheduleExam(maths, ex1, new DateTime(2025, 1, 10));
        scheduler.ScheduleExam(physics, ex2, new DateTime(2025, 1, 12));
        scheduler.ScheduleExam(dsa, ex1, new DateTime(2025, 1, 15));

        scheduler.ShowSchedule();
    }
}
