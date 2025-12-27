namespace Management;

public class Exam
{
    public SubjectExam Subject { get; set; }
    public Examiner Examiner { get; set; }
    public DateTime ExamDate { get; set; }

    public Exam(SubjectExam subject, Examiner examiner, DateTime examDate)
    {
        Subject = subject;
        Examiner = examiner;
        ExamDate = examDate;
    }

    public override string ToString()
    {
        return $"{Subject.SubjectName} | {ExamDate:d} | Examiner: {Examiner.Name}";
    }
}
