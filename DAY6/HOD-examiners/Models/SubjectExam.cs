namespace Management;

public class SubjectExam
{
    public string SubjectName { get; set; }
    public string SemId { get; set; }

    public SubjectExam(string subjectName, string semId)
    {
        SubjectName = subjectName;
        SemId = semId;
    }

    public override string ToString()
    {
        return $"{SubjectName} (Sem: {SemId})";
    }
}
