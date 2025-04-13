namespace SchoolDatabase.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public ICollection<SubjectTeacher> SubjectTeachers { get; set; } = new List<SubjectTeacher>();
    }
}