namespace SchoolDatabase.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string Title { get; set; }
        public List<Mark> Marks { get; set; } = new();
        public List<SubjectTeacher> SubjectTeachers { get; set; } = new();
    }
}