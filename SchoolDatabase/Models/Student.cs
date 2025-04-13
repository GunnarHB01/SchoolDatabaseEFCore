namespace SchoolDatabase.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GroupId { get; set; }
        public Group? Group { get; set; }
        public List<Mark> Marks { get; set; } = new();
    }

}